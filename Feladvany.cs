using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA230310
{
    internal class Feladvany
    {
        public string Szo { get; set; }
        public (int Sor, int Oszlop) Hely { get; set; }
        public Irany Irany { get; set; }

        public Feladvany(string sor)
        {
            string[] v = sor.Split('*');
            Szo = v[0];
            Hely = (int.Parse(v[1]), int.Parse(v[2]));
            Irany = (Irany)int.Parse(v[3]);
        }
    }
    internal enum Irany
    {
        Jobb = 1,
        JobbFel = 2,
        Fel = 3,
        BalFel = 4,
        Bal = 5,
        BalLe = 6,
        Le = 7,
        JobbLe = 8,
    }
}
