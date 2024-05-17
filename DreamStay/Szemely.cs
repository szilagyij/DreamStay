using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamStay
{
      public class Szemely
    {
        string azon;
        string nev;
        DateTime szuletesdatum;
        string email;
        bool vip;

        public Szemely(string azon, string nev, DateTime szuletesdatum, string email, bool vip)
        {
            this.Azon = azon;
            this.Nev = nev;
            this.Szuletesdatum = szuletesdatum;
            this.Email = email;
            this.Vip = vip;
        }

        public string Azon { get => azon; set => azon = value; }
        public string Nev { get => nev; set => nev = value; }
        public DateTime Szuletesdatum { get => szuletesdatum; set => szuletesdatum = value; }
        public string Email { get => email; set => email = value; }
        public bool Vip { get => vip; set => vip = value; }
    }
}
/*
 * 
 * ügyfél azonosítója, neve, születési dátuma, e-mail címe, VIP ügyfél-e
 * */
