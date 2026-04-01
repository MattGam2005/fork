using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTests
{
    [TestClass]
    public class KontoPlusTests
    {
        [TestMethod]
        public void TestKontoPlusLimit()
        {
            // Arrange
            var kontoPlus = new KontoPlus("Kowalski", 1000, 500);
            
            kontoPlus.Wyplata(1200);

            Assert.IsTrue(kontoPlus.Zablokowane, "Konto powinno być zablokowane po przekroczeniu limitu debetowego.");

            kontoPlus.Wplata(300);

            Assert.IsFalse(kontoPlus.Zablokowane, "Konto powinno zostać odblokowane po spłaceniu debetu.");
        }
    }
}