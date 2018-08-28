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
    public enum Modos
    {
        NOJUGAR=-1,
        SOLO,
        MOD,
        PVM,
        PVPH,
        PVPR
    }

    public enum Salidas
    {
        FIN=-1,
        LOGRADO=-2,
        PERDER=-3,
        TRAMPAS=-4
    }
    public partial class FNivel : Form 
    {
        protected int nivel=-1;
        public const int MIN_NIV = 3;
        public const int MAX_NIV = 5;
  
        public FNivel () =>  InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            Modos modo=Modos.NOJUGAR;                

            if(radioButton1.Checked) { nivel = 0; }
            if(radioButton2.Checked) { nivel = 1; }
            if(radioButton3.Checked) { nivel = 2; }
            PedirModo(ref modo);
            if (modo != Modos.NOJUGAR)
                Jugar(modo);
            else
                Close();
        }

        protected void PedirModo(ref Modos modo)
        {
            FModo fmodo = new FModo();

            Hide();
            fmodo.ShowDialog();
            modo = fmodo.Modo;
        }
        void Jugar(Modos modo)
        {
            Hide();
            if (modo == Modos.SOLO)
            {
                FMaster fjugar = new FMaster();

                fjugar.InicializarNivel(MIN_NIV + nivel);
                fjugar.ShowDialog();
                nivel = fjugar.Nivel;
            }
            else if (modo == Modos.MOD)
            {
                FModX fmaq = new FModX();

                fmaq.InicializarNivel(MIN_NIV + nivel);
                fmaq.ShowDialog();
                nivel = fmaq.Nivel;
            }
            if (nivel == -1)
                Close();
            else
                Show();
        }

        public int Nivel => nivel;
    }
}
