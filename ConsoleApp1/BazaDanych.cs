using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BazaDanych
    {
        private readonly string nazwaPliku = @"D:\Aplikacja\ConsoleApp1\baza_danych(2).json";
        // Metoda dodająca nowy obiekt do bazy danych
        public void Dodaj<T>(T obiekt)
        {
            List<T> listaObiektow = Odczytaj<T>();
            listaObiektow.Add(obiekt);
            Zapisz(listaObiektow);
        }

        // Metoda usuwająca obiekt z bazy danych
        public void Usun<T>(T obiekt)
        {
            List<T> listaObiektow = Odczytaj<T>();
            listaObiektow.Remove(obiekt);
            Zapisz(listaObiektow);
        }

        // Metoda aktualizująca obiekt w bazie danych
        public void Aktualizuj<T>(T obiekt)
        {
            List<T> listaObiektow = Odczytaj<T>();
            int index = listaObiektow.FindIndex(o => o.Equals(obiekt));
            if (index != -1)
            {
                listaObiektow[index] = obiekt;
                Zapisz(listaObiektow);
            }
        }

        // Metoda odczytująca wszystkie obiekty danego typu z bazy danych
        public List<T> Odczytaj<T>()
        {
            if (!File.Exists(nazwaPliku))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(nazwaPliku);
            var deserialized = JsonConvert.DeserializeObject<List<T>>(json);
            return deserialized ?? new List<T>();
        }

        // Metoda zapisująca listę obiektów do pliku
        private void Zapisz<T>(List<T> listaObiektow)
        {
            string json = JsonConvert.SerializeObject(listaObiektow);
            File.WriteAllText(nazwaPliku, json);
        }

        // Metoda wyświetlająca wszystkie rezerwacje
        public void WyswietlRezerwacje()
        {
            List<Rezerwacja> rezerwacje = Odczytaj<Rezerwacja>();

            if (rezerwacje.Count == 0)
            {
                Console.WriteLine("Obecnie nie posiadasz żadnych rezerwacji.");
                return;
            }

            foreach (var rezerwacja in rezerwacje)
            {
                rezerwacja.WyswietlInformacje();
            }
        }
    }
}

