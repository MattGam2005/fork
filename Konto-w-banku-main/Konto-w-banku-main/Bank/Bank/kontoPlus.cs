using System;
using Bank;
using Konto = Bank.Konto;
using KontoLimit = Bank.KontoLimit;


namespace KontoPlus
{
    public class KontoPlus : Konto
    {
        private decimal limitDebetowy;
        private bool limitWykorzyst = false;

        public KontoPlus(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0)
            : base(klient, bilansNaStart)
        {
            this.limitDebetowy = limitDebetowy;
        }

        public override void Wyplata(decimal kwota)
        {
            if (Zablokowane)
            {
                Console.WriteLine("Konto jest zablokowane. Nie można dokonać wypłaty.");
                return;
            }
            decimal srodki;
            if (limitWykorzyst)
            {
                srodki = Bilans;
            }
            else
            {
                srodki = Bilans + limitDebetowy;
            }
            if (kwota > srodki)
            {
                Console.WriteLine("Za duża kwota, przekroczono limit debetowy.");
                return;
            }
            if (kwota > Bilans)
            {
                limitWykorzyst = true;
                base.Wyplata(kwota);
            }
            else
            {
                base.Wyplata(kwota);
            }
        }
    }
}
