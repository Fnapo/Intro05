using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intro05
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            /* FMaster masterm = new FMaster();

             do
             {
                 masterm.InicializarNivel();
                 if (masterm.Nivel != -1) { Application.Run(masterm); }
             }
             while (masterm.Nivel != -1);
             Adios();*/
            Application.Run(new FNivel());
            Application.Run(new FDespedida());
        }
    }  
}
