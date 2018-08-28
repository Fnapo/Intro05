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
    public partial class FModX : Form
    {
        protected int nivel, numInt, tope;
        protected MPosibles[] mpos;
        protected MPista[] mpis;

        public FModX()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ind1, dato;

            numericUpDown1.Focus();
            if (numericUpDown1.Value + numericUpDown2.Value > nivel)
            {
                label7.Text = "Error HUMANO: " + numericUpDown1.Value + "T y " + numericUpDown2.Value + "S.";
            }
            else
            {
                ind1 = 3 * nivel - numInt;
                CrearPista();
                if (numericUpDown2.Value == nivel)
                {
                    Hide();
                    FMaster.Logrado();
                    nivel = -2;

                    return;
                }
                if (numInt == 0)
                {
                    ErrorHumano();

                    return;
                }
                EliminarPos(ind1);
                label7.Text = "Correcto ... De momento.";
                dato = BuscarPos();
                label6.Text = "Quedan " + numInt + " intentos.";
                if (dato < 0)
                {
                    ErrorHumano();

                    return;
                }
                else
                {
                    label2.Text = mpos[dato].Cadena;
                }
            }
            numericUpDown1.Value = numericUpDown2.Value = 0;
        }

        protected void ErrorHumano()
        {
            int ind2;
            string cadena;
            Boolean vale;

            Hide();
            cadena = PedirCadena();
            if (cadena == "")
            {
                FMaster.Errores(cadena);
                nivel = -4;
            }
            else
            {
                vale = ComprobarPistas(cadena, out ind2);
                if (vale)
                {
                    FMaster.NoLogrado(cadena);
                    nivel = -3;
                }
                else
                {
                    cadena = mpis[ind2].Cadena + " " + mpis[ind2].Tocados + "T " + mpis[ind2].Situados + "S";
                    FMaster.Errores(cadena);
                    nivel = -4;
                }
            }
        }
        protected Boolean ComprobarPistas(string cadena, out int indice)
        { 
            Boolean salida = true;
            int toc, sit;

            for (indice = 0; indice < 3 * nivel; ++indice)
            {
                FMaster.TocaSita(cadena, mpis[indice].Cadena, out toc, out sit);
                if((toc != mpis[indice].Tocados) || (sit != mpis[indice].Situados))
                {
                    salida = false;
                    break;
                }
            }

            return salida;
        }
        public string PedirCadena()
        {
            FMPedir fpedir = new FMPedir(nivel);

            fpedir.ShowDialog();
            if (fpedir.Nivel == -1)
                return "";
            else
                return fpedir.Cadena;
        }

        protected void EliminarPos(int indice)
        {
            int ind1, toc, sit;

            for (ind1 = 0; ind1 < tope; ++ind1)
            {
                if (mpos[ind1].pos)
                {
                    FMaster.TocaSita(mpis[indice].Cadena, mpos[ind1].Cadena, out toc, out sit);
                    mpos[ind1].pos = ((mpis[indice].Tocados == toc) && (mpis[indice].Situados == sit));
                }
            }
        }   

        protected void CrearMPos()
        {
            int ind1;
            //MPosibles nexo = new MPosibles(nivel);

            mpos = new MPosibles[tope];
            for (ind1 = 0; ind1 < tope; ++ind1)
                mpos[ind1] = new MPosibles(nivel);
            for (ind1 = 0; ind1 < tope; ++ind1)
            {
                mpos[ind1].PCadena(ind1);
                mpos[ind1].pos = FMaster.Validar(mpos[ind1].Cadena, nivel);
            }
        }

        protected int BuscarPos()
        {
            int ind1, salida=-1, inicio;
            string cadena = FMaster.CrearMeta(nivel);

            inicio = int.Parse(cadena);
            for(ind1=0; ind1 < tope; ++ind1)
            {
                if (mpos[inicio].pos)
                {
                    salida = inicio;
                    break;
                }
                ++inicio;
                inicio %= tope;
            }

            return salida;
        }

        protected void CrearPista()
        {
            MPista ayuda = new MPista(label2.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);

            mpis[3 * nivel - numInt] = ayuda;
            textBox1.Text += ayuda.Cadena + "  " + ayuda.Tocados + "T " + ayuda.Situados + "S." + "\r\n";
            --numInt;
        }

        private void FModX_FormClosed(object sender, FormClosedEventArgs e)
        {
            nivel = -1;
        }

        protected void CrearMPistas()
        {
            int indice;

            mpis = new MPista[FNivel.MAX_NIV * 3];
            for (indice = 0; indice < FNivel.MAX_NIV * 3; ++indice)
                mpis[indice] = new MPista();
        }

        public void InicializarNivel(int pnivel)
        {
            int dato;

            nivel = pnivel;
            label8.Text += nivel+" dígitos.";
            tope = (int)Math.Pow(10, nivel);
            numericUpDown1.Maximum = nivel;
            numericUpDown2.Maximum = nivel;
            CrearMPos();
            CrearMPistas();
            dato=BuscarPos();
            numInt = 3 * nivel;
            label6.Text = "Quedan " + numInt + " intentos.";
            if (dato < 0)
            {
                nivel = -2;
            }
            label7.Text = "Correcto ... De momento.";
            label2.Text = mpos[dato].Cadena;
        }

        public int Nivel => nivel;
    }
}
