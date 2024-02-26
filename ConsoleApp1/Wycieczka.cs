using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Wycieczka
    {
        public string Nazwa { get; set; }
        public string Destynacja { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public decimal Cena { get; set; }
        public int MaksymalnaLiczbaUczestnikow { get; set; }

        public Wycieczka(string nazwa, string destynacja, DateTime dataRozpoczecia, DateTime dataZakonczenia, decimal cena, int maksymalnaLiczbaUczestnikow)
        {
            Nazwa = nazwa;
            Destynacja = destynacja;
            DataRozpoczecia = dataRozpoczecia;
            DataZakonczenia = dataZakonczenia;
            Cena = cena;
            MaksymalnaLiczbaUczestnikow = maksymalnaLiczbaUczestnikow;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Nazwa: {Nazwa}");
            Console.WriteLine($"Destynacja: {Destynacja}");
            Console.WriteLine($"Data rozpoczęcia: {DataRozpoczecia}");
            Console.WriteLine($"Data zakończenia: {DataZakonczenia}");
            Console.WriteLine($"Cena: {Cena}");
            Console.WriteLine($"Maksymalna liczba uczestników: {MaksymalnaLiczbaUczestnikow}");
        }
    }
}
