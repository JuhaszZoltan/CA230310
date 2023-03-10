using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA230310
{
    internal class Tabla
    {
        public char[,] CharMatrix { get; set; } = new char[16, 16];

        public void Megjelenit()
        {
            for (int s = 0; s < CharMatrix.GetLength(0); s++)
            {
                Console.Write('\t');
                for (int o = 0; o < CharMatrix.GetLength(1); o++)
                    Console.Write(CharMatrix[s, o] == '\0' ? '#' : CharMatrix[s, o]);
                Console.Write('\n');
            }
        }

        private static (int s, int o) IranybaTesz(Irany irany, int s, int o)
            => irany switch
            {
                Irany.Jobb    => (  s, ++o),
                Irany.JobbFel => (--s, ++o),
                Irany.Fel     => (--s,   o),
                Irany.BalFel  => (--s, --o),
                Irany.Bal     => (  s, --o),
                Irany.BalLe   => (++s, --o),
                Irany.Le      => (++s,   o),
                Irany.JobbLe  => (++s, ++o),
                _ => throw new NotImplementedException("error")
            };

        public Tabla(List<Feladvany> feladvanyok)
        {
            foreach (var f in feladvanyok)
            {
                int s = f.Hely.Sor;
                int o = f.Hely.Oszlop;
                foreach (char c in f.Szo)
                {
                    CharMatrix[s, o] = c;
                    (s, o) = IranybaTesz(f.Irany, s, o);
                }
            }
        }
    }
}