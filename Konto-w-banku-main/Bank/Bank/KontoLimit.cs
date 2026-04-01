using System;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal limit;
        private bool limitPrzekroczony = false;

        public KontoLimit(Konto konto, decimal limit = 0)
        {
            this.konto = konto;
            this.limit = limit;
        }
        public string Nazwa => this.konto.Nazwa;
        public decimal Bilans => this.konto.Bilans;
        public bool Zablokowane => this.konto.Zablokowane;

        public void Wplata(decimal kwota)
        {
            konto.Wplata(kwota);

            if (limitPrzekroczony && konto.Bilans >= 0)
            {
                limitPrzekroczony = false;
                konto.OdblokujKonto();
            }
        }



        public void Wyplata(decimal kwota)
        {
            if (konto.Zablokowane)

                throw new InvalidOperationException("Konto jest zablokowane.");
          
            if (kwota > konto.Bilans + limit)
            {
                throw new ArgumentException("Limit przekroczony.");
            }
            if (kwota > konto.Bilans)
            {
                konto.Wyplata(konto.Bilans);
                limitPrzekroczony = true;
                konto.BlokujKonto();
            }
            else
            {
                konto.Wyplata(kwota);
            }
        }
    }
}
