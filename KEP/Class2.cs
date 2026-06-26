using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;
using System.IO;

namespace KEP
{

    //Κλάση που καλείται στην φόρμα για να εκτελέσει όλες τις παρακάτω λειτουργίες
    //Χρησιμοποιείται στην περίπτωση που αποθηκεύουμε τα στοιχεία σε εξωτερικό αρχείο
    public class functions
    {
        String connectionString = DatabaseHelper.ConnectionString;
        SQLiteConnection connection;

        public void SaveToFile(string name)
        {
            //Δημιουργία σύνδεσης
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                //Επιλέγονται τα στοιχεία του πολίτη μέσω του sqlite command
                //Με βάση το όνομα που θα πληκτρολογήσουμε
                string query = "SELECT * FROM aitimata WHERE onomateponimo = @name";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            //Δημιουργία αρχείου με το όνομα του πολίτη που έχει την κατάληξη .txt(δηλαδή έγγραφο κειμένου)
                            string filePath = $"Aitima_{name}.txt";

                            //Γράφουμε στο αρχείο τα στοιχεία που διαβάζονται από τη βάση
                            using (StreamWriter writer = new StreamWriter(filePath))
                            {
                                writer.WriteLine("=== Αίτημα Πολίτη ===");
                                writer.WriteLine($"ID: {reader["id"]}");
                                writer.WriteLine($"Ονοματεπώνυμο: {reader["onomateponimo"]}");
                                writer.WriteLine($"Email: {reader["email"]}");
                                writer.WriteLine($"Τηλέφωνο: {reader["til"]}");
                                writer.WriteLine($"Ημερομηνία Γέννησης: {reader["BirthDate"]}");
                                writer.WriteLine($"Είδος Αιτήματος: {reader["EidosAitimatos"]}");
                                writer.WriteLine($"Διεύθυνση: {reader["dieuthinsi"]}");
                                writer.WriteLine($"Ώρα: {reader["ora"]}");
                            }

                            //Messages ανάλογα με το πως πήγε η διαδικασία
                            MessageBox.Show($"Το αρχείο αποθηκεύτηκε: {filePath}");
                        }
                        else
                        {
                            MessageBox.Show("Δεν βρέθηκε αίτημα με το συγκεκριμένο ονοματεπώνυμο.");
                        }

                    }
                }
            }
        }
    }
}
                
     


   
            
        

    

