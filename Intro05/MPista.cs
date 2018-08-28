using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro05
{
    public class MPista
    {
        protected string cadena;
        int toc, sit;

        public MPista()
        {
            cadena = "";
            toc = sit = 0;
        }
        public MPista(string pcad, int ptoc, int psit)
        {
            cadena = pcad;
            toc = ptoc;
            sit = psit;
        }

        public string Cadena
        {
            get { return cadena; }
        }
        public int Tocados
        {
            get { return toc; }
        }
        public int Situados
        {
            get { return sit; }
        }
    }
}
