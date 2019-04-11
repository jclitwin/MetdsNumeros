using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtdNumerico.Secante
{
    public partial class MetodoSecantesForm : Form
    {
        public MetodoSecantesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            double.TryParse(textBox4.Text, out double x0);
            double.TryParse(textBox1.Text, out double x1);
            double.TryParse(textBox6.Text, out double error);

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("É necessário definir o valor.");
                return;
            }

            MetodoSecantes metodoSecantes = new MetodoSecantes();

            //if (metodoPontoFixo.verificar_raiz_intervalo(intervalo_a, intervalo_b) == false)
            //{
            //    MessageBox.Show("Não há raiz!");
            //    return;
            //}

            double funcao_xn = 0;
            double x2 = 0;

            for (int i = 0; ; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = i.ToString();
                lvi.SubItems.Add(x0.ToString());

                funcao_xn = metodoSecantes.f(x0);
                lvi.SubItems.Add(funcao_xn.ToString());

                x2 = metodoSecantes.calcular_secante(x0, x1);
                lvi.SubItems.Add(x2.ToString());

                if (Math.Abs(error) < funcao_xn)
                {
                    textBox4.Text = x0.ToString();
                    break;
                }

                listView1.Items.Add(lvi);

                x0 = x1;
                x1 = x2;
            }
        }
    }
}
