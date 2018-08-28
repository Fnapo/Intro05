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
    public partial class FPerdido : Form
    {
        public FPerdido()
        {
            InitializeComponent();
        }

        public void Mostrar(string numero)
        {
            label3.Text="Era el "+numero+" ";
        }
    }
}
