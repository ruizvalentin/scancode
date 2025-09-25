using System.Data.SqlClient;

namespace ScanCode.SQL
{
    internal class UserScanBarCode
    {
        string connectionString;
        string tableName;
        string columnScanCode;
        string columnDateScan;


        public UserScanBarCode(string _source)
        {
            connectionString = _source;
            tableName = "ScanBarCode";
            columnScanCode = "ScanCode";
            columnDateScan = "DateScan";
        }

        //
        // Permet d'inserer une donnée "barcode" dans la table
        //
        public void insert(string _scanCode, DateTime _date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Requete SQL
                    string query = $"INSERT INTO {tableName} ({columnScanCode},{columnDateScan}) VALUES (@scanCode, @date)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajout des paramètres avec leurs valeurs respectives
                        command.Parameters.AddWithValue("@scanCode", _scanCode);
                        command.Parameters.AddWithValue("@date", _date);

                        // Exécute la commande SQL
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
        // Permet de selectionner toutes les lignes de la table
        //
        public List<string> SelectAll() // return all in list
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
                            data.Add(reader["ScanCode"].ToString() + ";" + reader["DateScan"].ToString());
                        }
                    }
                }
                return data;
            }
        }

    }
}
