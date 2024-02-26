using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pracownik : Osoba
    {
        public string Stanowisko { get; set; }
        public List<Wycieczka> ObslugiwaneWycieczki { get; set; }

        public Pracownik(string imie, string nazwisko, string email, string stanowisko) : base(imie, nazwisko, email)
        {
            Stanowisko = stanowisko;
            ObslugiwaneWycieczki = new List<Wycieczka>();
        }

        // Metoda dodająca wycieczkę do listy obsługiwanych
        public void DodajWycieczke(Wycieczka wycieczka)
        {
            ObslugiwaneWycieczki.Add(wycieczka);
        }

        // Metoda usuwająca wycieczkę z listy obsługiwanych
        public void UsunWycieczke(Wycieczka wycieczka)
        {
            ObslugiwaneWycieczki.Remove(wycieczka);
        }

        // Metoda wyświetlająca informacje o pracowniku
        public new void WyswietlInformacje()
        {
            Console.WriteLine($"Imię: {Imie}");
            Console.WriteLine($"Nazwisko: {Nazwisko}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Stanowisko: {Stanowisko}");
            Console.WriteLine("Obsługiwane wycieczki:");
            foreach (var wycieczka in ObslugiwaneWycieczki)
            {
                Console.WriteLine($"- {wycieczka.Nazwa}");
            }
        }
    }
}
