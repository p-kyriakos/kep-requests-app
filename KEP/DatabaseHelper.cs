using System;
using System.Data.SQLite;
using System.IO;

namespace KEP
{
    internal static class DatabaseHelper
    {
        private const string DatabaseFileName = "aitimatadb.db";

        public static string DatabasePath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFileName); }
        }

        public static string ConnectionString
        {
            get { return $"Data Source={DatabasePath};Version=3;"; }
        }

        public static void Initialize()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createTable = @"
                    CREATE TABLE IF NOT EXISTS aitimata (
                        id INTEGER PRIMARY KEY,
                        onomateponimo TEXT NOT NULL,
                        email TEXT,
                        til TEXT,
                        BirthDate TEXT,
                        EidosAitimatos TEXT,
                        dieuthinsi TEXT,
                        ora TEXT
                    );";

                using (SQLiteCommand command = new SQLiteCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
