using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;

namespace KEP
{

    //Δημιουργία κλάσης 
    //περιέχει ιδιότητες που αντιπροσωπεύουν τα δεδομένα ενός αιτήματος πολίτη.
    //Οι ιδιότητες είναι όλες δημόσιες (public) και μπορούν να διαβαστούν
    //ή να τροποποιηθούν μέσω των getter και setter.
    public class AitimaPoliti
        {
            public string Id { get; set; }
            public string onomateponimo { get; set; }
            public string email { get; set; }
            public string til { get; set; }
            public DateTime BirthDate { get; set; }
            public string EidosAitimatos { get; set; }
            public string dieuthinsi { get; set; }
            public DateTime ora { get; set; }


            //Καλείται από τις φόρμες 2 και 3 προκειμένου να δημιουργηθούν τα αντικείμενα που χρειαζόμαστε
            //μαζί με τα παραπάνω χαρακτηριστικά που έχουμε ορίσει
            public AitimaPoliti()
                { }
            

        }

}

