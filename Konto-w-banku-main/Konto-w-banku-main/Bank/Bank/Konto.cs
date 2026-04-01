using System;
using Bank;
using Konto = Bank.Konto;
using KontoLimit = Bank.KontoLimit;

namespace Bank
{
    public class Konto
    {
        private string klient;  //nazwa klienta
        private decimal bilans;  //aktualny stan środków na koncie
        private bool zablokowane = false; //stan konta
       
        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            this.bilans = bilansNaStart;
        }
        public string Nazwa => klient;
        public decimal Bilans => bilans;
        public bool Zablokowane => zablokowane;

        public void Wplata(decimal kwota)
        {
            if (zablokowane) return;
            if(kwota<=0)
            
                bilans = bilans + kwota;
                Console.WriteLine("Konto jest zablokowane. Nie można dokonać wpłaty.");
              
            }
           
        

        public virtual void Wyplata(decimal kwota)
        {
            if (zablokowane) return;
            if(kwota>bilans)
            {
                Console.WriteLine("Wypłacono " + kwota + ". Nowy bilans: " + bilans);
                return;
            }     
            bilans-= kwota;
             Console.WriteLine("Wypłacono " + kwota + ". Nowy bilans: " + bilans);
        }



        void BlokujKonto()
        {
            zablokowane = true;
            Console.WriteLine("Konto zostało zablokowane.");
        }
        void OdblokujKonto()
        {
            zablokowane = false;
            Console.WriteLine("Konto zostało odblokowane.");
        }
    }
}