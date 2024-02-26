using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
public class Klient : Osoba
{
    public List<Rezerwacja> Rezerwacje { get; set; }

    public Klient(string imie, string nazwisko, string email) : base(imie, nazwisko, email)
    {
        Rezerwacje = new List<Rezerwacja>();
    }

    // Metoda dodająca rezerwację
    public void DodajRezerwacje(Rezerwacja rezerwacja)
    {
        Rezerwacje.Add(rezerwacja);
    }

    // Metoda usuwająca rezerwację
    public void UsunRezerwacje(Rezerwacja rezerwacja)
    {
        Rezerwacje.Remove(rezerwacja);
    }

        // Metoda wyświetlająca informacje o kliencie
        public new void WyswietlInformacje()
        {
        Console.WriteLine("Informacje o kliencie:");
        base.WyswietlInformacje();
        Console.WriteLine("Rezerwacje:");
        foreach (var rezerwacja in Rezerwacje)
        {
            rezerwacja.WyswietlInformacje();
        }
    }
}
}
