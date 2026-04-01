using System;
using Bank;

namespace BanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w banku!");
            Konto.molenda = new Konto("Molenda", 100);

            molenda.Wyplata(50);
            molenda.Wyplata(30);

            Console.WriteLine("Aktualny bilans: " + molenda.Bilans);
        }
    }
}