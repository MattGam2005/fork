using System;
using Bank;


namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w Banku");

            Bank.KontoPlus konto = new Bank.KontoPlus("Kowalski", 1000, 500);

            Console.WriteLine($"Bilans startowy: {konto.Bilans}");

            try
            {
                Console.WriteLine("Wyplłata 120 zł");
                konto.Wyplata(120);
                Console.WriteLine($"Bilans po wypłacie: {konto.Bilans}");

                Console.WriteLine("Wyplłata 900 zł");
                konto.Wyplata(900);
                Console.WriteLine($"Bilans po wypłacie: {konto.Bilans}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            Konto stare = new Konto("Molenda", 100);
            Bank.KontoPlus nowe = new Bank.KontoPlus(stare, 1000);
            Console.WriteLine($"Konwersja udana. Konto dla: {nowe.Nazwa},Dostępne środki: {nowe.Bilans}");

            Console.ReadKey();
        }
    }
}