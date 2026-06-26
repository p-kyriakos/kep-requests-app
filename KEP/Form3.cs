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

namespace KEP
{
    public partial class Form3 : Form
    {
        String connectionString = DatabaseHelper.ConnectionString;
        SQLiteConnection connection;
        public Form3()
        {
            InitializeComponent();
        }

        //Έξοδος από την φόρμα
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Κουμπί ενημέρωσης των στοιχείων που αλλάζουν αφού διαγραφούν πρώτα
        //τα παλαιότερα στοιχεία που είχαν εισαχθεί
        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

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

                //και στη συνέχεια ενημερώνονται οι τιμές που έχουμε δώσει στον πίνακα της βάσης
                String update = @"UPDATE aitimata
                    SET onomateponimo = @name,
                        email = @email,
                        til = @phone,
                        BirthDate = @birthdate,
                        EidosAitimatos = @eidos,
                        dieuthinsi = @dieuthinsi,
                        ora = @ora
                    WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(update, connection))
                {


                    command.Parameters.AddWithValue("id", int.Parse(textBox6.Text));
                    command.Parameters.AddWithValue("name", politis.onomateponimo);
                    command.Parameters.AddWithValue("email", politis.email);
                    command.Parameters.AddWithValue("phone", (politis.til));
                    command.Parameters.AddWithValue("birthdate", politis.BirthDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("eidos", (politis.EidosAitimatos));
                    command.Parameters.AddWithValue("dieuthinsi", (politis.dieuthinsi));
                    command.Parameters.AddWithValue("ora", DateTime.Now);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Το αίτημα ενημερώθηκε");
                    }


                    else
                    {
                        MessageBox.Show("Σφάλμα κατά την υποβολή");
                    }



                    connection.Close();
                }







            }
        }
    }
}

    
