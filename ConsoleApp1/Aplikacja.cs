using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Aplikacja
    {
        private BazaDanych bazaDanych;

        public Aplikacja()
        {
            bazaDanych = new BazaDanych();
        }

        // Metoda uruchamiająca aplikację
        public void Uruchom()
        {
            bool uruchomiona = true;
            while (uruchomiona)
            {
                Console.WriteLine("Witaj w aplikacji obsługi biura podróży!");
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj nową wycieczkę");
                Console.WriteLine("2. Wyświetl wszystkie wycieczki");
                Console.WriteLine("3. Zarezerwuj wycieczkę");
                Console.WriteLine("4. Wyświetl moje rezerwacje");
                Console.WriteLine("5. Wyjdź z aplikacji");

                string? opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        DodajWycieczke();
                        break;
                    case "2":
                        WyswietlWszystkieWycieczki();
                        break;
                    case "3":
                        ZarezerwujWycieczke();
                        break;
                    case "4":
                        WyswietlMojeRezerwacje();
                        break;
                    case "5":
                        uruchomiona = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna opcja. Spróbuj ponownie.");
                        break;
                }
            }
        }

        // Metoda dodająca nową wycieczkę
        private void DodajWycieczke()
        {
            Console.WriteLine("Podaj nazwę wycieczki:");
            string? nazwa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                nazwa = "Nieznana wycieczka"; 
            }

            Console.WriteLine("Podaj destynację:");
            string? destynacja = Console.ReadLine() ?? "Nieznana destynacja"; 
            Console.WriteLine("Podaj datę rozpoczęcia (RRRR-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataRozpoczecia))
            {
                dataRozpoczecia = DateTime.Now; 
            }
            Console.WriteLine("Podaj datę zakończenia (RRRR-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataZakonczenia))
            {
                dataZakonczenia = DateTime.Now;
            }
            Console.WriteLine("Podaj cenę:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal cena))
            {
                cena = 0; 
            }
            Console.WriteLine("Podaj maksymalną liczbę uczestników:");
            if (!int.TryParse(Console.ReadLine(), out int maksymalnaLiczbaUczestnikow))
            {
                maksymalnaLiczbaUczestnikow = 0; 
            }

            Wycieczka nowaWycieczka = new(nazwa, destynacja, dataRozpoczecia, dataZakonczenia, cena, maksymalnaLiczbaUczestnikow); bazaDanych.Dodaj(nowaWycieczka);
            Console.WriteLine("Wycieczka została dodana.");
        }

        // Metoda wyświetlająca wszystkie wycieczki
        private void WyswietlWszystkieWycieczki()
        {
            var wycieczki = bazaDanych.Odczytaj<Wycieczka>();
            Console.WriteLine("Lista wszystkich wycieczek:");
            foreach (var wycieczka in wycieczki)
            {
                wycieczka.WyswietlInformacje();
                Console.WriteLine();
            }
        }

        // Metoda rezerwująca wycieczkę
        private void ZarezerwujWycieczke()
        {
            Console.WriteLine("Podaj swoje imię:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj swoje nazwisko:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj swój adres email:");
            string email = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Dane klienta nie mogą być puste. Proszę spróbować ponownie.");
                return; 
            }

            // Tworzenie obiektu klienta z wprowadzonych danych
            Klient klient = new Klient(imie, nazwisko, email);

            Console.WriteLine("Wybierz numer wycieczki, którą chcesz zarezerwować:");
            WyswietlWszystkieWycieczki();
            int numerWycieczki;
            if (!int.TryParse(Console.ReadLine(), out numerWycieczki))
            {
                Console.WriteLine("Nie wprowadzono numeru, spróbuj ponownie.");
                return; 
            }

            var wycieczki = bazaDanych.Odczytaj<Wycieczka>();
            if (numerWycieczki < 0 || numerWycieczki >= wycieczki.Count)
            {
                Console.WriteLine("Niepoprawny numer wycieczki. Proszę wybrać numer z listy.");
                return; 
            }

            Wycieczka wybranaWycieczka = wycieczki[numerWycieczki];
            Rezerwacja nowaRezerwacja = new Rezerwacja(klient, wybranaWycieczka, "Oczekująca");
            bazaDanych.Dodaj(nowaRezerwacja);
            Console.WriteLine("Wycieczka została zarezerwowana.");
        }


        // Metoda wyświetlająca rezerwacje klienta
        private void WyswietlMojeRezerwacje()
        {
            Console.WriteLine("Podaj swoje imię:");
            string? imie = Console.ReadLine();
            Console.WriteLine("Podaj swoje nazwisko:");
            string? nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj swój adres email:");
            if (string.IsNullOrWhiteSpace(imie)) imie = "Nieznane imię";
            string? email = Console.ReadLine() ?? "brak@email.com";
            if (string.IsNullOrWhiteSpace(nazwisko)) nazwisko = "Nieznane nazwisko";

            Klient klient = new Klient(imie, nazwisko, email);
            var rezerwacje = bazaDanych.Odczytaj<Rezerwacja>();
            Console.WriteLine("Twoje rezerwacje:");
            foreach (var rezerwacja in rezerwacje)
            {
                if (rezerwacja.Klient != null && klient != null &&
                    String.Equals(rezerwacja.Klient.Imie, klient.Imie, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(rezerwacja.Klient.Nazwisko, klient.Nazwisko, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(rezerwacja.Klient.Email, klient.Email, StringComparison.OrdinalIgnoreCase))

                {
                    rezerwacja.WyswietlInformacje();
                    Console.WriteLine();
                }
            }
        }
    }
}
