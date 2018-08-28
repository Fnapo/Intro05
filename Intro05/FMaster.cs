using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intro05
{
    public partial class FMaster : Form
    {
        protected int nivel, numInt;
        private NumericUpDown[] numbot;
        string oculto;

        public FMaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indice, toc, sit;
            Boolean valida;
            string entrada;

            entrada = "";
            for (indice = 0; indice < nivel; ++indice)
                entrada += numbot[indice].Value.ToString();
            valida = Validar(entrada, nivel);
            if (valida)
            {
                TocaSita(entrada, out toc, out sit);
                textBox1.Text += entrada + "  "+toc+"T "+sit+"S."+"\r\n";
                label3.Text = entrada + " Es una cadena correcta.";
                --numInt;
                label4.Text = "Quedan " + numInt + " intentos.";
                if (sit == nivel)
                {
                    Hide();
                    Logrado();
                    nivel = -2;
                }
                else if (numInt == 0)
                {
                    Hide();
                    nivel = -3;
                    NoLogrado(oculto);
                }
            }
            else
                label3.Text = entrada + " No es una cadena correcta.";
        }
        
        public static void Errores(string cadena)
        {
            FError trampa = new FError();
            FError2 error2 = new FError2();

            trampa.Mostrar(cadena);
            trampa.ShowDialog();
            error2.ShowDialog();
        }
        public static void NoLogrado(string cadena)
        {
            FPerdido perder = new FPerdido();
            FOhhhh ffin = new FOhhhh();

            perder.Mostrar(cadena);
            perder.ShowDialog();
            ffin.ShowDialog();
        }
        public static void Logrado()
        {
            FGanado ganar = new FGanado();
            FBravo bravo = new FBravo();
  
            ganar.ShowDialog();
            bravo.ShowDialog();
        }
        public static void TocaSita(string objetivo, string pista, out int pt, out int ps)
        {
            int ind1, ind2, nivel=objetivo.Length;

            pt = ps = 0;
            for (ind1 = 0; ind1 < nivel; ++ind1)
            {
                for (ind2 = 0; ind2 < nivel; ++ind2)
                {
                    if (pista[ind1] == objetivo[ind2]) //{ ((ind1 == ind2) ? ++ps : ++pt); }
                    {
                        if (ind1 == ind2)
                            ps++;
                        else
                            pt++;
                    }
                }
            }

        }
        private void TocaSita(string pcadena, out int pt, out int ps)
        {
            TocaSita(oculto, pcadena, out pt, out ps);
          /*  int ind1, ind2;

            pt = ps = 0;
            for (ind1 = 0; ind1 < nivel; ++ind1)
            {
                for(ind2=0; ind2 < nivel; ++ind2)
                {
                    if (pcadena[ind1] == oculto[ind2]) //{ ((ind1 == ind2) ? ++ps : ++pt); }
                    {
                        if (ind1 == ind2)
                            ps++;
                        else
                            pt++;
                    }
                }
            }*/

        }
        public static Boolean Validar(string cadena, int pnivel)
        {
            Boolean salida = true;
            int ind1, ind2;
            string uno;

            for(ind1=0; ind1 < pnivel-1; ++ind1)
            {
                if(!salida) { break;  }
                uno = "";
                uno += cadena[ind1];
                if (int.Parse(uno) > 9) { salida = false; }
                for (ind2=ind1+1; ind2 < pnivel; ++ind2)
                {
                    if(!salida) { break; }
                    salida = (cadena[ind1] != cadena[ind2]);
                    uno = "";
                    uno += cadena[ind2];
                    if (int.Parse(uno) > 9) { salida = false; }
                }
            }
            return salida;
        }
        public int Nivel
        {
            get { return nivel; }
        }

        public void InicializarNivel(int pnivel)
        {
            int indice;

            numbot = new NumericUpDown[FNivel.MAX_NIV];
            numbot[0] = numericUpDown1;
            numbot[1] = numericUpDown2;
            numbot[2] = numericUpDown3;
            numbot[3] = numericUpDown4;
            numbot[4] = numericUpDown5;
            nivel = pnivel;
            for(indice=0; indice < nivel; ++indice)
            {
                numbot[indice].Visible = true;
                numbot[indice].Maximum = 9;
            }
            for (indice = nivel; indice < FNivel.MAX_NIV; ++indice)
            {
                numbot[indice].Visible = false;
            }
            CrearOculto();
            numInt = 3 * nivel;
            label4.Text = "Quedan " + numInt + " intentos.";
        }

        public static string CrearMeta(int nivel)
        {
            string meta = "";
            int indice, valor;
            bool[] vale;
            Random azar = new Random();

            if (nivel > FNivel.MAX_NIV)
                nivel = FNivel.MAX_NIV;
            else if (nivel < FNivel.MIN_NIV) { nivel = FNivel.MIN_NIV; }
            vale = new bool[9];
            for (indice = 0; indice < 9; indice++)
                vale[indice] = true;
            for (indice = 0; indice < nivel; ++indice)
            {
                valor = azar.Next(0, 9);
                while (!vale[valor])
                {
                    ++valor;
                    valor %= (9);
                }
                vale[valor] = false;
                meta += valor;
            }

            return meta;
        }

        protected void CrearOculto()
        {
            oculto = CrearMeta(nivel);
                //label1.Text += oculto;
            /*           int indice, valor;
                       bool[] vale;
                       Random azar = new Random();

                       vale = new bool[2 * nivel];
                       oculto = "";
                       for (indice = 0; indice < 2 * nivel; indice++)
                           vale[indice] = true;
                       for (indice = 0; indice < nivel; ++indice)
                       {
                           valor = azar.Next(0, 2 * nivel);
                           while(!vale[valor])
                           {
                               ++valor;
                               valor %= (2 * nivel);
                           }
                           vale[valor] = false;
                           oculto += valor;
                       }*/
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
        }

        private void FMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            nivel = -1;
        }
    }
}
