using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamStay
{
    public class RoomLog
    {
        string nev;
        string azon;
        int szobaszam;
        double ar;
        int hanyfo;
        DateTime erkezes;
        DateTime tavozas;
        string allapot;

        public RoomLog(string nev, string azon, int szobaszam, double ar, int hanyfo, DateTime erkezes, DateTime tavozas, string allapot)
        {
            this.Nev = nev;
            this.Azon = azon;
            this.Szobaszam = szobaszam;
            this.Ar = ar;
            this.Hanyfo = hanyfo;
            this.Erkezes = erkezes;
            this.Tavozas = tavozas;
            this.Allapot = allapot;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Azon { get => azon; set => azon = value; }
        public int Szobaszam { get => szobaszam; set => szobaszam = value; }
        public double Ar { get => ar; set => ar = value; }
        public int Hanyfo { get => hanyfo; set => hanyfo = value; }
        public DateTime Erkezes { get => erkezes; set => erkezes = value; }
        public DateTime Tavozas { get => tavozas; set => tavozas = value; }
        public string Allapot { get => allapot; set => allapot = value; }
    }
}
