using System.Data.SqlClient;

namespace ScanCode.SQL
{
    internal class UserScan
    {
        string connectionString;
        string tableName;
        string columnLastName;
        string columnFirstName;
        string columnIdentificationNumber;
        string columnResult;
        string columnResultBit;
        string columnDateScan;
        string columnTypeEntree;
        string columnCertifMedical;


        public UserScan(string _source)
        {

            connectionString = _source;
            tableName = "UserScan";
            columnLastName = "LastName";
            columnFirstName = "FirstName";
            columnIdentificationNumber = "IdentificationNumber";
            columnResult = "Result";
            columnResultBit = "ResultBit";
            columnDateScan = "DateScan";
            columnTypeEntree = "TypeEntree";
            columnCertifMedical = "CertifMedical";
        }

        //
        // Permet d'inserer une donnée "scan" dans la table
        //
        public void insert(string _lastName, string _firstName, int _identificationNumber, string _result, int _resultBit, string _date, int _typeEntree, string _certif)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Créez la requête SQL paramétrée pour insérer les données dans la table
                    string query = $"INSERT INTO {tableName} ({columnLastName},{columnFirstName},{columnIdentificationNumber},{columnResult},{columnResultBit},{columnDateScan}, {columnTypeEntree}, {columnCertifMedical}) VALUES (@LastName,@FirstName, @IdentificationNumber, @Result, @ResultBit, @Date, @TypeEntree, @CertifMedical)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajoutez les paramètres avec leurs valeurs respectives
                        command.Parameters.AddWithValue("@LastName", _lastName);
                        command.Parameters.AddWithValue("@FirstName", _firstName);
                        command.Parameters.AddWithValue("@IdentificationNumber", _identificationNumber);
                        command.Parameters.AddWithValue("@Result", _result);
                        command.Parameters.AddWithValue("@ResultBit", _resultBit);
                        command.Parameters.AddWithValue("@Date", _date);
                        command.Parameters.AddWithValue("@TypeEntree", _typeEntree);
                        command.Parameters.AddWithValue("@CertifMedical", _certif);

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
        // Permet de sélectionner les scans du jours dans l'ordre DESC
        //
        public List<string> selectFirstLastNameToday()
        {
            List<string> dataList = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM {tableName} WHERE {columnDateScan} >= CONVERT(date, GETDATE()) AND {columnDateScan} < DATEADD(day, 1, CONVERT(date, GETDATE())) ORDER BY {columnDateScan} DESC ;";

                    // Créer une commande SQL pour exécuter la requête
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Exécuter la requête
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Lire les enregistrements à l'intérieur de la boucle while
                            while (reader.Read())
                            {
                                if (reader["FirstName"].ToString() != "Null")
                                {
                                    string element = reader["lastName"].ToString() + ";" + reader["FirstName"].ToString() +";" + reader["IdentificationNumber"].ToString(); // Remplacez "NomDeLaColonne" par le nom de la colonne contenant les éléments souhaités
                                    if (reader["ResultBit"].ToString() == "True")
                                        element += ";Oui";
                                    else
                                        element += ";Non";

                                    dataList.Add(element);
                                }
                            }
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }

            return dataList;
        }

        //
        // Retourne le nombre de scan d'aujourd'hui
        //
        public int selectNbScanToday()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT COUNT(DISTINCT {columnIdentificationNumber}) FROM {tableName} WHERE {columnDateScan} >= CONVERT(date, GETDATE()) AND {columnDateScan} < DATEADD(day, 1, CONVERT(date, GETDATE()));";

                    // Créer une commande SQL pour exécuter la requête
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        count = (int)command.ExecuteScalar();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }

            return count;
        }

        //
        // Permet de sélectionner les scans suivant les params : 
        // _recherche : champs libre
        // _startDate et _endDate : plage de date
        // _licenceStatut : statut de la licence
        //
        public List<string> selectRequest(string _recherche, DateTime _startDate, DateTime _endDate, string _licenceStatut)
        {
            List<string> dataList = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Utilisation d'une requête paramétrée +securisé 
                    string query = $"SELECT {columnLastName}, {columnFirstName}, {columnIdentificationNumber}, {columnDateScan}, {columnResult}, {columnResultBit}, {columnCertifMedical} FROM {tableName} WHERE ({columnDateScan} >= @startDate AND {columnDateScan} <= @endDate)";

                    if (!string.IsNullOrEmpty(_recherche))
                    {
                        query += $" AND ({columnLastName} LIKE @searchText OR {columnFirstName} LIKE @searchText OR {columnIdentificationNumber} LIKE @searchText)";
                    }
                    if (_licenceStatut == "Valide")
                    {
                        query += $" AND {columnResultBit} = 1";
                    }
                    else if (_licenceStatut == "Invalide")
                    {
                        query += $" AND {columnResultBit} = 0";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@searchText", "%" + _recherche + "%");
                    command.Parameters.AddWithValue("@startDate", _startDate);
                    command.Parameters.AddWithValue("@endDate", _endDate);

                    // read and return all in list
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string element = reader["LastName"].ToString() + ";" + reader["FirstName"].ToString() + ";" + reader["IdentificationNumber"].ToString() + ";" + reader["DateScan"].ToString();
                            if (reader["ResultBit"].ToString() == "True")
                                element += ";Valide";
                            else
                                element += ";Invalide";
                            element += ";" + reader["Result"].ToString();
                            element += ";" + reader["CertifMedical"].ToString();

                            dataList.Add(element);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }

            return dataList;
        }

        //
        // Retourne le nombre de scan suivant les paramètres  
        //
        public int selectRequestCount(string _recherche, DateTime _startDate, DateTime _endDate, string _licenceStatut)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Utilisation d'une requête paramétrée +securisé 
                    string query = $"SELECT COUNT(DISTINCT {columnIdentificationNumber}) FROM {tableName} WHERE ({columnDateScan} >= @startDate AND {columnDateScan} <= @endDate)";

                    if (!string.IsNullOrEmpty(_recherche))
                    {
                        query += $" AND ({columnLastName} LIKE @searchText OR {columnFirstName} LIKE @searchText OR {columnIdentificationNumber} LIKE @searchText)";
                    }
                    if (_licenceStatut == "Valide")
                    {
                        query += $" AND {columnResultBit} = 1";
                    }
                    else if (_licenceStatut == "Invalide")
                    {
                        query += $" AND {columnResultBit} = 0";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@searchText", "%" + _recherche + "%");
                    command.Parameters.AddWithValue("@startDate", _startDate);
                    command.Parameters.AddWithValue("@endDate", _endDate);

                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }

            return count;
        }
    }
}
