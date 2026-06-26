using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace KEP
{
    public partial class Form2 : Form
    {
        String connectionString = DatabaseHelper.ConnectionString;
        SQLiteConnection connection;
        public Form2()
        {
            InitializeComponent();

        }

        //Κουμπί υποβολής του αιτήματος
        private void button1_Click(object sender, EventArgs e)
        {
            //Δημιουργία ενός αντικειμένου που τα χαρακτηριστικά του 
            //παίρνουν τις τιμές των textboxes

            AitimaPoliti politis = new AitimaPoliti();
            politis.Id = textBox6.Text;
            politis.onomateponimo = textBox1.Text;
            politis.email = textBox3.Text;
            politis.til = textBox2.Text;
            politis.BirthDate = dateTimePicker1.Value;
            politis.EidosAitimatos = textBox4.Text;
            politis.dieuthinsi = textBox5.Text;

            //Νέα σύνδεση με τη βάση
            connection = new SQLiteConnection(connectionString);
            connection.Open();



            //Καθορίζουμε σε ποιες στήλες θα αποθηκευτούν τα δεδομένα του πολίτη
            //μέσα στον πίνακα της βάσης aitimatadb.db
            String insert = "INSERT INTO aitimata (id, onomateponimo, email, til, BirthDate, EidosAitimatos, dieuthinsi, ora) " +
           "VALUES (@id, @name, @email, @phone, @birthdate, @eidos, @dieuthinsi, @ora)";
            using (SQLiteCommand command = new SQLiteCommand(insert, connection))
            {

                //Εισαγωγή των τιμών
                command.Parameters.AddWithValue("id", int.Parse(textBox6.Text));
                command.Parameters.AddWithValue("name", politis.onomateponimo);
                command.Parameters.AddWithValue("email", politis.email);
                command.Parameters.AddWithValue("phone", (politis.til));
                command.Parameters.AddWithValue("birthdate", politis.BirthDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("eidos", (politis.EidosAitimatos));
                command.Parameters.AddWithValue("dieuthinsi", (politis.dieuthinsi));
                command.Parameters.AddWithValue("ora", DateTime.Now);

                //Μηνύματα μετά το τέλος της διαδικασίας
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Το αίτημα προστέθηκε");
                }


                else
                {
                    MessageBox.Show("Σφάλμα κατά την υποβολή");
                }
                connection.Close();
            }


        }

        //Έξοδος από τη φόρμα
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       
