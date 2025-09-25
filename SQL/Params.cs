using Microsoft.SqlServer.Management.HadrData;
using System.Data.SqlClient;

namespace ScanCode.SQL
{
    internal class Params
    {
        string connectionString;
        string tableName;
        string columnDayBeforeBackup;
        string columnNextBackup;
        string columnOldBackup;
        string columnLinkBackup;
        string columnLinkBackupDaily;

        public Params(string _source)
        {
            connectionString = _source;
            tableName = "Params";
            columnDayBeforeBackup = "DayBeforeBackup";
            columnNextBackup = "NextBackup";
            columnOldBackup = "OldBackup";
            columnLinkBackup = "LinkBackup";
            columnLinkBackupDaily = "LinkBackupDaily";
        }

        //
        // Selectionne la date de la dernière backup
        //
        public DateTime SelectLastBackupDate()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {columnOldBackup} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToDateTime(result) : DateTime.MinValue;
            }
        }

        //
        // Selectionne le lien pour la save des backup daily
        //
        public string SelectLinkBackupDaily()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {columnLinkBackupDaily} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();
                return result.ToString();
            }
        }

        //
        // Selectionne le lien pour la save des backups
        //
        public string SelectLinkBackup()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {columnLinkBackup} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();
                return result.ToString();
            }
        }

        //
        // Selectionne la date de la prochaine backup
        //
        public DateTime SelectNextBackupDate()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {columnNextBackup} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToDateTime(result) : DateTime.MinValue;
            }
        }

        //
        // Selectionne l'intervalle entre 2 backup
        //
        public int SelectIntervalleDay()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {columnDayBeforeBackup} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
            }
        }

        //
        // Maj de la prochaine backup
        //
        public void UpdateNextBackupDate(DateTime nextBackupDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {columnNextBackup} = @nextBackupDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nextBackupDate", nextBackupDate);

                command.ExecuteNonQuery();
            }
        }

        //
        // Maj du lien pour la sauvegarde des backups daily
        //
        public void UpdateLinkbackupDaily(string _inputPath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {columnLinkBackupDaily} = @link";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@link", _inputPath);

                command.ExecuteNonQuery();
            }
        }

        // 
        // Maj du lien pour la sauvegarde des backups
        //
        public void UpdateLinkbackup(string _inputPath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {columnLinkBackup} = @link";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@link", _inputPath);

                command.ExecuteNonQuery();
            }
        }

        //
        // Maj de la date de la dernière backup faite
        //
        public void UpdateOldBackupDate(DateTime oldBackupDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {columnLinkBackup} = @oldBackupDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@oldBackupDate", oldBackupDate);

                command.ExecuteNonQuery();
            }
        }

        //
        // Maj du delai entre deux backup (nb jours)
        //
        public void UpdateDayBeforeBackup(int dayBeforeBackup)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {columnDayBeforeBackup} = @dayBackupDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dayBackupDate", dayBeforeBackup);

                command.ExecuteNonQuery();
            }
        }

        // 
        // Permet de faire une backup de la BDD
        //
        public void PerformBackup(string backupFolderPath, string _nom)
        {
            string backupFileName = Path.Combine(backupFolderPath, $"backup_{_nom}.bak");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string backupQuery = $"BACKUP DATABASE ScanCode TO DISK = '{backupFileName}' WITH INIT, FORMAT, MEDIANAME = 'BackupSet', NAME = 'Full Backup of ScanCode'";

                    using (SqlCommand command = new SqlCommand(backupQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la backup de la base de données : {ex.Message}", "Erreur de Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
