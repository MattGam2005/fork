namespace PudelkoApp
{
    using System;
    using PudelkoLib;

    public static class PudelkoExtensions
    {
        public static Pudelko CreateCubeFromVolume(this Pudelko pudelko)
        {
            double bok = Math.Cbrt(pudelko.Objetosc());
            return new Pudelko(bok, bok, bok);
        }
    }
}