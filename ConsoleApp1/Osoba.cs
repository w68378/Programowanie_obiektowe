using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }

        public Osoba(string imie, string nazwisko, string email)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
        }

        // Metoda wyświetlająca informacje o osobie
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Imię: {Imie}");
            Console.WriteLine($"Nazwisko: {Nazwisko}");
            Console.WriteLine($"Email: {Email}");
        }
    }

}
