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
    public partial class FMPedir : Form
    {
        protected int nivel = 0;
        protected NumericUpDown[] numbot;
        protected string cadena;

        public FMPedir(int pnivel)
        {
            nivel = pnivel;
            if (nivel > FNivel.MAX_NIV)
                nivel = FNivel.MAX_NIV;
            else if (nivel < FNivel.MIN_NIV) { nivel = FNivel.MIN_NIV; }
            InitializeComponent();
            Inicializar();
        }

        private void FMPedir_FormClosed(object sender, FormClosedEventArgs e)
        {
            nivel = -1;
        }

        protected void Inicializar()
        {
            int indice;

            numbot = new NumericUpDown[FNivel.MAX_NIV];
            numbot[0] = numericUpDown1;
            numbot[1] = numericUpDown2;
            numbot[2] = numericUpDown3;
            numbot[3] = numericUpDown4;
            numbot[4] = numericUpDown5;
            for (indice = 0; indice < nivel; ++indice)
            {
                numbot[indice].Visible = true;
                numbot[indice].Maximum = 9;
            }
            for (indice = nivel; indice < FNivel.MAX_NIV; ++indice)
            {
                numbot[indice].Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int indice;
            Boolean valida;
            string entrada;

            cadena=entrada = "";
            for (indice = 0; indice < nivel; ++indice)
                entrada += numbot[indice].Value.ToString();
            valida = FMaster.Validar(entrada, nivel);
            if (!valida)
            {
                label2.Text = entrada + " Cadena Incorrecta.";
            }
            else
            {
                cadena = entrada;
                Hide();
            }
        }

        public int Nivel => nivel;
        public string Cadena => cadena;
    }
}

