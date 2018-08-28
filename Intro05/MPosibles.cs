using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro05
{
    public class MPosibles
    {
        protected string cadena;
        public Boolean pos = true;
        protected int largo;

        public MPosibles(int pint)
        {
            if (pint > FNivel.MAX_NIV)
                pint = FNivel.MAX_NIV;
            else if (pint < FNivel.MIN_NIV) { pint = FNivel.MIN_NIV; }
            largo = pint;
        }

        public void PCadena(int dato)
        {
            if (dato < 0)
                dato = 0;
            else if (dato >= Math.Pow(10,largo)) { dato = (int)Math.Pow(10,largo) - 1; }
            cadena = dato.ToString();
            while(cadena.Length < largo) { cadena = "0" + cadena; }
        }

        public string Cadena
        {
            get { return cadena; }
        }
         
    }
}
