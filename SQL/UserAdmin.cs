using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ScanCode.SQL
{
    internal class UserAdmin
    {
        string connectionString;
        string tableName;
        string columnUsername;
        string columnPassword;


        public UserAdmin(string _source)
        {
            connectionString = _source;
            tableName = "UserAdmin";
            columnUsername = "Username";
            columnPassword = "Password";
        }

        //
        // Check lors de la connexion d'un admin 
        //
        public bool CheckLoginCredentials(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnUsername} = @username AND {columnPassword} = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", ComputeMD5Hash(password));
 
                int userCount = (int)command.ExecuteScalar();

                return userCount > 0; // Renvoie vrai si les informations de connexion sont valides
            }
        }

        //
        // Permet l'ajout d'un nouveau admin
        //
        public void insertAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string hashedPassword = ComputeMD5Hash(password); // Chiffrer le mot de passe en MD5

                string query = $"INSERT INTO {tableName} ({columnUsername}, {columnPassword}) VALUES (@username, @hashedPassword)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                command.ExecuteNonQuery(); // Exécuter la requête d'insertion
            }
        }

        //
        // Permet de supprimer un compte admin
        //
        public void Delete(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE {columnUsername}=@username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery(); // Exécuter la requête d'insertion
            }
        }

        //
        // Selectionne l'ensemble des admins
        //
        public List<string> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> data = new List<string>();

                connection.Open();
                string query = $"SELECT {columnUsername} FROM {tableName}";

                // Créer une commande SQL pour exécuter la requête
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Exécuter la requête
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Lire les enregistrements à l'intérieur de la boucle while
                        while (reader.Read())
                        {
                            data.Add(reader.GetString(0));
                        }
                    }
                }
                return data;
            }
        }

        //
        // Check si un compte admin comporte déjà le même password
        //
        public bool VerifUserName(string _username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> data = new List<string>();

                connection.Open();
                string query = $"SELECT * FROM {tableName} WHERE {columnUsername} = @username";

                // Créer une commande SQL pour exécuter la requête
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", _username);
                    // Exécuter la requête
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        //
        // Retourne le hash md5 de l'input (password)
        //
        private string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
