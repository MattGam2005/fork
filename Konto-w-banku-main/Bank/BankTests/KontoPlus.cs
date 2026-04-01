using System;


namespace Bank
{
    public class KontoPlus : Konto
    {
        private decimal limitKredytowy;

        public KontoPlus(string klient, decimal bilansNaStart = 0, decimal limitKredytowy = 0): base(klient, bilansNaStart)
        {
            this.limitKredytowy = limitKredytowy;
        }
        public KontoPlus(Konto zwykleKonto, decimal nowyLimit): base(zwykleKonto.Nazwa, zwykleKonto.Bilans)
        {
            this.limitKredytowy = nowyLimit;
            if (zwykleKonto.Zablokowane)
                BlokujKonto();
        }

        public override void Wyplata(decimal kwota)
        {
            if (zablokowane)
                throw new InvalidOperationException("Konto jest zablokowane.");
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.");

            if (kwota > bilans + limitKredytowy)
            {
                throw new InvalidOperationException("Niewystarczające środki na koncie, przekroczono limit debetowy.");
            }

            bilans -= kwota;

            if (bilans < 0)
            {
                BlokujKonto();
            }
        }

        public void OdzyskanieSrodkow(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.");
            if (kwota > limitKredytowy)
                throw new InvalidOperationException("Kwota przekracza limit kredytowy.");
            if (kwota > -bilans)
                throw new InvalidOperationException("Kwota przekracza zadłużenie konta.");

            bilans += kwota;
            if (bilans >= 0) OdblokujKonto();
        }
    }
}