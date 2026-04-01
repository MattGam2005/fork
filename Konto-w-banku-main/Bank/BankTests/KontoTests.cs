using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;


namespace BankTests
{
    [TestClass]
    public sealed class KontoTests
    {

        [TestMethod]
        public void Wplata_PoprawnaKwota_ZwiekszaBilans()
        {
            var konto = new Konto("Jan Kowalski", 100);
            decimal kwota = 50;

            konto.Wplata(kwota);
            Assert.AreEqual(150, konto.Bilans);
        }


      [TestMethod]
       public void Wyplata_Zablokowana()
      {
         var konto = new Konto("Jan Kowalski", 100);
          konto.BlokujKonto();

           Assert.Throws<InvalidOperationException>(() => konto.Wyplata(50));
       }


        [TestMethod]
        public void Wyplata_PoprawnaKwota_ZmniejszaBilans()
        {
            var konto = new Konto("Jan Kowalski", 200);
            konto.Wyplata(50);
            Assert.AreEqual(150, konto.Bilans);

        }
    }
}
