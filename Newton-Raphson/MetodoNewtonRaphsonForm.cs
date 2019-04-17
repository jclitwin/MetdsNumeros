using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtdNumerico.Newton_Raphson
{
    public partial class MetodoNewtonRaphsonForm : Form
    {
        public MetodoNewtonRaphsonForm()
        {
            InitializeComponent();

            textBox2.Enabled = false;
            textBox2.Text = "";

            textBox3.Enabled = false;
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            double.TryParse(textBox1.Text, out double x0);
            double.TryParse(textBox6.Text, out double modulo_funcao_xn);
            int.TryParse(textBox2.Text, out int iteracoes);
            int.TryParse(textBox3.Text, out int casasdecimais);

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("É necessário definir o valor.");
                return;
            }

            MetodoNewtonRaphson newtonRaphson = new MetodoNewtonRaphson();

            double xn = x0;
            double funcao_xn_n = 0;
            double funcao_xn_n_plus_1 = 0;

            for (int i = 0; (checkBox2.Checked) ? i < iteracoes : true; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = i.ToString();
                lvi.SubItems.Add(xn.ToString());

                funcao_xn_n = newtonRaphson.funcao(xn);
                if (checkBox1.Checked)
                    funcao_xn_n = newtonRaphson.Truncate(funcao_xn_n, casasdecimais);

                lvi.SubItems.Add(funcao_xn_n.ToString());

                funcao_xn_n_plus_1 = newtonRaphson.funcao_xn_plus_1(xn);
                if (checkBox1.Checked)
                    funcao_xn_n_plus_1 = newtonRaphson.Truncate(funcao_xn_n_plus_1, casasdecimais);

                lvi.SubItems.Add(funcao_xn_n_plus_1.ToString());

                xn = funcao_xn_n_plus_1;

                listView1.Items.Add(lvi);

                if (Math.Abs(funcao_xn_n) < modulo_funcao_xn)
                {
                    //textBox4.Text = xn.ToString();
                    textBox4.Text = (checkBox1.Checked) ? newtonRaphson.Truncate(newtonRaphson.newton(modulo_funcao_xn, x0), casasdecimais).ToString() : 
                        newtonRaphson.newton(modulo_funcao_xn, x0).ToString();
                    break;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.Enabled = true;
                textBox2.Text = "";
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.Enabled = true;
                textBox3.Text = "";
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "";
            }
        }
    }
}
