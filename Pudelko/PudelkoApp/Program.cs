using System;
using System.Collections.Generic;
using PudelkoLib;

class Program
{
    static void Main(string[] args)
    {
        var lista = new List<Pudelko>
        {
            new Pudelko(2, 3, 4),
            new Pudelko(100, 100, 100),
            new Pudelko(2.5, 9.321, 0.1),
            new Pudelko(5, 5, 30)
        };

        Comparison<Pudelko> comp = (p1, p2) =>
        {
            int res = p1.Objetosc().CompareTo(p2.Objetosc());
            if (res == 0)
                res = p1.ToString().CompareTo(p2.ToString());
            return res;
        };

        lista.Sort(comp);

        foreach (var p in lista)
            Console.WriteLine(p);
    }
}