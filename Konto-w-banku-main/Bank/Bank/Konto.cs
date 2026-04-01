using System;

namespace Bank
{
    public class Konto
    {
        protected string klient;  //nazwa klienta
        protected decimal bilans;  //aktualny stan środków na koncie
        protected bool zablokowane = false; //stan konta

        private Konto() { }

        public Konto(string klient, decimal bilansNaStart=0)
        {
            this.klient = klient;
            this.bilans = bilansNaStart;
        }
        public string Nazwa => klient;
        public decimal Bilans => bilans;
        public bool Zablokowane => zablokowane;

        public virtual void Wplata(decimal kwota)
        {
            if (zablokowane)
                throw new InvalidOperationException("Konto jest zablokowane.");
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.");
          
            bilans += kwota;
        }
        public virtual void Wyplata(decimal kwota)
        {
            if (zablokowane)
                throw new InvalidOperationException("Konto jest zablokowane.");
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.");
            if (kwota > bilans)
                throw new InvalidOperationException("Niewystarczające środki na koncie.");
          
            bilans -= kwota;
        }
        public void BlokujKonto()
        {
            zablokowane = true;
        }
         public void OdblokujKonto()
        {
            zablokowane = false;
        }

    }
}
