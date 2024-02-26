using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Rezerwacja
    {
        public Klient Klient { get; set; }
        public Wycieczka Wycieczka { get; set; }
        public string StatusRezerwacji { get; set; }

        public Rezerwacja(Klient klient, Wycieczka wycieczka, string statusRezerwacji)
        {
            try
            {
                Klient = klient ?? throw new ArgumentNullException(nameof(klient));
                Wycieczka = wycieczka ?? throw new ArgumentNullException(nameof(wycieczka));
                StatusRezerwacji = statusRezerwacji ?? throw new ArgumentNullException(nameof(statusRezerwacji));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");

            }
        }

        // Metoda wyświetlająca informacje o rezerwacji
        public void WyswietlInformacje()
        {
            if (Klient != null)
            {
                Console.WriteLine($"Klient: {Klient.Imie} {Klient.Nazwisko}");
            }
            else
            {
                Console.WriteLine("Klient: brak danych"); 
            }
            Console.WriteLine($"Wycieczka: {Wycieczka.Nazwa}");
            Console.WriteLine($"Status rezerwacji: {StatusRezerwacji}");
        }
      }
    }
