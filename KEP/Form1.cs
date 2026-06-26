using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Drawing.Text;

namespace KEP
{
    public partial class Form1 : Form
    {
        
        string connectionString = DatabaseHelper.ConnectionString;



        public Form1()
        {
            InitializeComponent();
        }

        //Νέο αίτημα πολίτη με κατεύθυνση στη form 2 όπου εκτελούνται εκεί οι λειτουργίες του
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        //Προβολή όλων των αιτημάτων σε πίνακα
        private void button2_Click(object sender, EventArgs e)
        {

            //Δημιουργία σύνδεσης με τη βάση
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                //Δημιουργία query για να πάρουμε τα δεδομένα που θέλουμε από τη βάση
                string query = "SELECT * FROM aitimata";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    //και τα δεδομένα φορτώνοται σε ένα πίνακα που γίνεται ορατός με το datagridview tool
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }

                }
            }
        }
        //Εμφάνιση συγκεκριμένου αιτήματος ανάλογα με το όνομα του πολίτη που ψάχνουμε
        private void button3_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM aitimata WHERE onomateponimo = @name";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        //Διαγραφή αιτήματος με βάση το όνομα που θα δοθεί
        private void button4_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM aitimata WHERE onomateponimo = @name";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    dataGridView1.DataSource = null;

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Η εγγραφή διαγράφηκε επιτυχώς.");
                    }
                    else
                    {
                        MessageBox.Show("Δεν βρέθηκε εγγραφή με το όνομα που δόθηκε.");
                    }
                }
            }
        }


        
        //Με την κλάση functions η οποία έχει δημιουργηθεί στο Class2.cs την καλούμε
        //στην συγκεκριμένη φόρμα έτσι ώστε να κάνουμε εξαγωγή αιτήματος σε αρχείο txt 
        public void button6_Click(object sender, EventArgs e)
        {
           functions functions = new functions();
           functions.SaveToFile(textBox1.Text);
        }


        //Με το εργαλείο datagridview κάνουμε κλικ σε οποιοδήποτε κελί επιθυμούμε
        //και έτσι εμφανίζονται μέσω της φόρμας 3 τα στοιχεία του αντίστοιχου πολίτη
        //προσυμπληρωμένα στα textboxes και κάνουμε ότι αλλαγή χρειαζόμαστε
        //επιβεβαιώνοντας με το κουμπί ενημέρωση
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Form3 forrm = new Form3();
            forrm.Show();
            if (e.RowIndex >= 0)
            {

                var selectedRow = dataGridView1.Rows[e.RowIndex];
                forrm.textBox6.Text = selectedRow.Cells["id"].Value.ToString();
                forrm.textBox1.Text = selectedRow.Cells["onomateponimo"].Value.ToString();
                forrm.textBox3.Text = selectedRow.Cells["email"].Value.ToString();
                forrm.textBox2.Text = selectedRow.Cells["til"].Value.ToString();
                forrm.dateTimePicker1.Text = selectedRow.Cells["BirthDate"].Value.ToString();
                forrm.textBox4.Text = selectedRow.Cells["EidosAitimatos"].Value.ToString();
                forrm.textBox5.Text = selectedRow.Cells["dieuthinsi"].Value.ToString();


            }

        }
    }
        



    }
   

        
           
        
    

