using System;
using System.Collections;


namespace PudelkoLib
{
    public class UnitTest1
    { 
    
        public void TestMethod1()
        {
            Pudelko p1 = new Pudelko(2, 3, 4);
            Console.WriteLine(p1.ToString());
            Console.WriteLine($"Objętość: {p1.Objetosc()} m³");
        }
    }
}
