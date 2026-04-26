using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;


namespace PudelkoLib
{
    public class Pudelko
    {
        private double a;
        private double b;
        private double c;
        private UnitOfMeasure unit;
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.Meter)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException("Wymiary muszą być większe od zera.");
            this.unit = unit;
            this.a = ConvertToMeters(a, unit);
            this.b = ConvertToMeters(b, unit);
            this.c = ConvertToMeters(c, unit);
        }
        private double ConvertToMeters(double value, UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.Milimeter:
                    return value / 1000;
                case UnitOfMeasure.Centimeter:
                    return value / 100;
                case UnitOfMeasure.Meter:
                    return value;
                default:
                    throw new ArgumentException("Nieznana jednostka miary.");
            }
        }

        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }

        public double Objetosc()
        {
            return a * b * c;
        }
        public override string ToString() => ToString("m", CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            if (format == null) format = "m";

            switch (format.ToLower())
            {
                case "m":
                    return string.Format(formatProvider, "{0:F3} m × {1:F3} m × {2:F3} m", A, B, C);
                case "cm":
                    return string.Format(formatProvider, "{0:F1} cm × {1:F1} cm × {2:F1} cm", A * 100, B * 100, C * 100);
                case "mm":
                    return string.Format(formatProvider, "{0:F0} mm × {1:F0} mm × {2:F0} mm", A * 1000, B * 1000, C * 1000);
                default:
                    throw new FormatException();
            }
        }

        public bool Equals(Pudelko other)
        {
            if (other == null) return false;
            double[] t1 = { A, B, C };
            double[] t2 = { other.A, other.B, other.C };
            Array.Sort(t1);
            Array.Sort(t2);
            return t1[0] == t2[0] && t1[1] == t2[1] && t1[2] == t2[2];
        }

        public override bool Equals(object obj) => Equals(obj as Pudelko);
        public override int GetHashCode() => A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1?.Equals(p2) ?? ReferenceEquals(p2, null);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1 == p2);

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double[] w1 = { p1.A, p1.B, p1.C }; Array.Sort(w1);
            double[] w2 = { p2.A, p2.B, p2.C }; Array.Sort(w2);
            return new Pudelko(w1[0] + w2[0], Math.Max(w1[1], w2[1]), Math.Max(w1[2], w2[2]));
        }

        public double this[int i]
        {
            get {
                if (i == 0) return A;
                if (i == 1) return B;
                if (i == 2) return C;
                throw new IndexOutOfRangeException();
            }
        }
        public static Pudelko Parse(string s)
        {
            string[] parts = s.Split(new[] { " × " }, StringSplitOptions.None);
            double[] vals = new double[3];
            UnitOfMeasure unit = UnitOfMeasure.Meter;

            for (int i = 0; i < 3; i++)
            {
                string[] subParts = parts[i].Trim().Split(' ');
                vals[i] = double.Parse(subParts[0], CultureInfo.InvariantCulture);
                if (subParts[1] == "cm") unit = UnitOfMeasure.Centimeter;
                else if (subParts[1] == "mm") unit = UnitOfMeasure.Milimeter;
            }
            return new Pudelko(vals[0], vals[1], vals[2], unit);
        }
    }
}