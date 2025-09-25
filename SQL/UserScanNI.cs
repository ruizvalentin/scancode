using System.Data.SqlClient;

namespace ScanCode.SQL
{
    internal class UserScanNI
    {
        string connectionString;
        string tableName;
        string columnDateScan;
        string columnLink;


        public UserScanNI(string _source)
        {
            connectionString = _source;
            tableName = "UserScanNI";
            columnDateScan = "DateScan";
            columnLink = "Link";
        }

        //
        // Permet d'inserer un scan sans internet dans la BDD
        //
        public void insert(string _date, string _link)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Rrequête SQL avec les données
                    string query = $"INSERT INTO {tableName} ({columnDateScan},{columnLink}) VALUES (@Date, @Link)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajoute les paramètres avec leurs valeurs respectives
                        command.Parameters.AddWithValue("@Date", _date);
                        command.Parameters.AddWithValue("@Link", _link);

                        // Exécutez la commande SQL
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        //
        // Permet de sélectionner toutes les demandes de scan
        //
        public List<string> SelectAll() // return all in "list"
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> data = new List<string>();

                connection.Open();
                string query = $"SELECT * FROM {tableName}";

                // Créer une commande SQL pour exécuter la requête
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Exécuter la requête
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Lire les enregistrements à l'intérieur de la boucle while
                        while (reader.Read())
                        {
                            data.Add(reader["DateScan"].ToString() + ";" + reader["Link"].ToString());
                        }
                    }
                }
                return data;
            }
        }

        //
        // Permet de supprimer une ligne
        //
        public void Delete(string _date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE {columnDateScan}=@date";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", _date);

                command.ExecuteNonQuery(); // Exécuter la requête d'insertion
            }
        }
    }
}
