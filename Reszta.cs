using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WydawanieReszty
{
    class Reszta
    {
        private decimal[] RodzajeWaluty;
        public decimal PieniadzeDoWydania { get; set; }
        public Reszta(decimal PieniadzeDoWydania)
        {
            this.PieniadzeDoWydania = PieniadzeDoWydania;
            RodzajeWaluty = new decimal[] { 0.01M, 0.02M, 0.05M, 0.10M, 0.20M, 0.50M, 1, 2, 5, 10, 20, 50, 100, 200, 500 };
        }

        public Reszta(decimal PieniadzeDoWydania, params decimal[] _waluta)
        {
            this.PieniadzeDoWydania = PieniadzeDoWydania;
            RodzajeWaluty = _waluta;
        }

        public decimal LiczaWydanReszty()
        {
            decimal temp = PieniadzeDoWydania;
            decimal? liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();
            decimal licznik = 0;

            while (liczbyWieksze > 0)
            {
                temp -= liczbyWieksze.GetValueOrDefault(0);
                licznik++;

                liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();
            }
            return licznik;
        }

        public decimal[] WydanaReszta()
        {
            List<decimal> lista = new List<decimal>();
            decimal temp = PieniadzeDoWydania;
            decimal? liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();
            decimal licznik = 0;

            while (liczbyWieksze > 0)
            {
                temp -= liczbyWieksze.GetValueOrDefault(0);
                licznik++;

                lista.Add(liczbyWieksze.GetValueOrDefault(0));
                liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();

            }
            return lista.ToArray();
        }

        public string[] WydanaResztaStr()
        {
            List<string> lista = new List<string>();
            decimal temp = PieniadzeDoWydania;
            decimal? liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();
            decimal licznik = 0;

            while (liczbyWieksze > 0)
            {
                var x = liczbyWieksze.GetValueOrDefault(0);

                string wynik = "";

                temp -= x;
                licznik++;

                if (x < 1)
                {
                    wynik = Math.Round((x * 100)).ToString() + "gr.";
                }
                else
                {
                    wynik = x.ToString() + "zł."; 
                }


                lista.Add(wynik);
                liczbyWieksze = RodzajeWaluty.Where(n => n <= temp).OrderByDescending(n => n).FirstOrDefault();

            }
            return lista.ToArray();
        }
    }
}
