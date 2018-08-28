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
    public partial class FError : Form
    {
        public FError()
        {
            InitializeComponent();
        }
        
        public void Mostrar(string cadena)
        {
            if(cadena == "") { cadena = "alguna"; }
            cadena += ".";
            label2.Text += cadena;
        }
    }
}
