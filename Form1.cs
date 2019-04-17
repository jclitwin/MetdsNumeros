using MtdNumerico.Bisseccao;
using MtdNumerico.Newton_Raphson;
using MtdNumerico.PontoFixo;
using MtdNumerico.PosicaoFalsa;
using MtdNumerico.Secante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtdNumerico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DerivadaNumericaForm dnForm = new DerivadaNumericaForm();
            dnForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoBisseccaoForm dnForm = new MetodoBisseccaoForm();
            dnForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MetodoPosicaoFalsaForm dnForm = new MetodoPosicaoFalsaForm();
            dnForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MetodoPontoFixoForm dnForm = new MetodoPontoFixoForm();
            dnForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MetodoNewtonRaphsonForm dnForm = new MetodoNewtonRaphsonForm();
            dnForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MetodoSecantesForm dnForm = new MetodoSecantesForm();
            dnForm.Show();
        }
    }
}
