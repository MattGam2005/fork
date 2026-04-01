using System;

namespace KontoPlus;

public class KontoPlus : Konto
{
    private decimal limitDebetowy;
    private bool limitWykorzyst = false;

    public KontoPlus(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0) 
    {
        limitDebetowy = limitDebetowy;
    }

    public void Wyplata(decimal kwota)
    {
        if (Zablokowane)
        {
            Console.WriteLine("Konto jest zablokowane. Nie można dokonać wypłaty.");
            return;
        }
        if (kwota <=0)
        {
            Console.WriteLine("Niewystarczające środki na koncie, przekroczono limit debetowy.");
            return;
        }
        if (kwota > Bilans)
        {
            limitWykorzyst = true;
            Console.WriteLine("Wypłacono " + kwota + ". Przekroczono bilans, wykorzystano limit debetowy.");
        }
        else
        {
            Console.WriteLine("Wypłacono " + kwota + ". Nowy bilans: " + Bilans);
        }
    }
}
