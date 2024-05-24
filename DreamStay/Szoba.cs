using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamStay
{
    public class Szoba
    {
        int szobaszam;
        int ferohelyekszama;
        double ar;
        bool foglalte=false;
        double fizetedendo;
        string allapot;

        public Szoba(int szobaszam, int ferohelyekszama, double ar, bool foglalte, double fizetedendo, string allapot)
        {
            this.Szobaszam = szobaszam;
            this.Ferohelyekszama = ferohelyekszama;
            this.Ar = ar;
            this.Foglalte = foglalte;
            this.Fizetedendo = fizetedendo;
            this.Allapot = allapot;
        }

        public int Szobaszam { get => szobaszam; set => szobaszam = value; }
        public int Ferohelyekszama { get => ferohelyekszama; set => ferohelyekszama = value; }
        public double Ar { get => ar; set => ar = value; }
        public bool Foglalte { get => foglalte; set => foglalte = value; }
        public double Fizetedendo { get => fizetedendo; set => fizetedendo = value; }
        public string Allapot { get => allapot; set => allapot = value; }

        //előjegyzett, teljesült, lemondott

    }
}


/*
 * A panziónak 6 szobája van, ennek jellemzői: szobaszám (1-6), 
 * férőhelyek száma (2,3,4), aktuális ár egy főre egy éjszakára (6000-12000 Ft) Ezek adatait is karban kell tartani.
 * */