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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            double.TryParse(textBox1.Text, out double x0);
            double.TryParse(textBox6.Text, out double modulo_funcao_xn);

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("É necessário definir o valor.");
                return;
            }

            MetodoNewtonRaphson newtonRaphson = new MetodoNewtonRaphson();

            double xn = x0;
            double funcao_xn_n = 0;
            double funcao_xn_n_plus_1 = 0;

            for (int i = 0; i < 7; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = i.ToString();
                lvi.SubItems.Add(xn.ToString());

                funcao_xn_n = newtonRaphson.funcao(xn);
                funcao_xn_n = newtonRaphson.Truncate(funcao_xn_n, 5);
                lvi.SubItems.Add(funcao_xn_n.ToString());

                funcao_xn_n_plus_1 = newtonRaphson.funcao_xn_plus_1(xn);
                funcao_xn_n_plus_1 = newtonRaphson.Truncate(funcao_xn_n_plus_1, 5);
                lvi.SubItems.Add(funcao_xn_n_plus_1.ToString());

                xn = funcao_xn_n_plus_1;

                listView1.Items.Add(lvi);

                if (Math.Abs(funcao_xn_n) < modulo_funcao_xn)
                {
                    //textBox4.Text = xn.ToString();
                    textBox4.Text = newtonRaphson.Truncate(newtonRaphson.newton(modulo_funcao_xn, x0), 5).ToString();
                    break;
                }
            }
        }
    }
}
