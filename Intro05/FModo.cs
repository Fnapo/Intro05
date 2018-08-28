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
    public partial class FModo : Form
    {
        protected Modos modo = Modos.NOJUGAR;
        public FModo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked) { modo = Modos.SOLO; }
            if (radioButton2.Checked) { modo = Modos.MOD; }
            Hide();
        }

        private void FModo_FormClosed(object sender, FormClosedEventArgs e)
        {
            modo = Modos.NOJUGAR;
        }

        public Modos Modo => modo;
    }
}
