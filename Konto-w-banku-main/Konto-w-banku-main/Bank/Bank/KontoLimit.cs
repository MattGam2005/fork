using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoLimit : Konto
    {
        private decimal limitDebetowy;
        private bool limitWykorzystany = false;

        public KontoLimit(string klient, decimal bilansNaStart = 0, decimal limit = 100) 
            : base(klient, bilansNaStart)
        {
            this.limitDebetowy = limit;
        }



        //
        public new decimal Bilans => base.Bilans + (limitWykorzystany ? 0 : limitDebetowy);
        /* 
         * public override void Wyplata(decimal kwota)
         {
             if (Zablokowane)
             {
                 Console.WriteLine("Konto jest zablokowane. Nie można dokonać wpłaty.");
                 return;
             }
             kwota = Bilans + kwota;
             Console.WriteLine("Wpłacono " + kwota + ". Nowy bilans: " + Bilans);
         }
        */


        public override void Wyplata(decimal kwota)
        {
            if (Zablokowane)
            {
                Console.WriteLine("Konto jest zablokowane. Nie można dokonać wypłaty.");
                return;
            }


            
            decimal dostepneSrodki;
            
            if (limitWykorzystany)
            {
                dostepneSrodki = Bilans;
            }
            else
            {
                dostepneSrodki = Bilans + limitDebetowy;
            }
           



            if (kwota > dostepneSrodki)
            {
                Console.WriteLine("Za dużo kwota debetowa)");
                return;
            }

            if (kwota > base.Bilans)
            {
                limitWykorzystany = true;
                base.Wyplata(kwota);
                this.BlokujKonto();
            }
            else
            {
                base.Wyplata(kwota);
            }
        }
    }
     
}
