using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtdNumerico.Bisseccao
{
    public partial class MetodoBisseccaoForm : Form
    {
        public MetodoBisseccaoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            double.TryParse(textBox1.Text, out double erro_abs);
            double.TryParse(textBox2.Text, out double intervalo_a);
            double.TryParse(textBox3.Text, out double intervalo_b);

            MetodoBisseccao metodoBisseccao = new MetodoBisseccao();

            double xn = 0;
            double inter_a = intervalo_a;
            double inter_b = intervalo_b;
            double funcao_a = 0;
            double funcao_b = 0;
            double funcao_xn = 0;
            double erro = 0;

            if (metodoBisseccao.verificar_raiz_intervalo(intervalo_a, intervalo_b) == false)
            {
                MessageBox.Show("Não há raiz!");
                return;
            }

            for (int i = 0; ; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = i.ToString();
                lvi.SubItems.Add(inter_a.ToString());
                lvi.SubItems.Add(inter_b.ToString());

                xn = metodoBisseccao.calcularXN(inter_a, inter_b);
                lvi.SubItems.Add(xn.ToString());

                funcao_a = metodoBisseccao.funcao(inter_a);
                lvi.SubItems.Add(funcao_a.ToString());

                funcao_b = metodoBisseccao.funcao(inter_b);
                lvi.SubItems.Add(funcao_b.ToString());

                funcao_xn = metodoBisseccao.funcao(xn);
                lvi.SubItems.Add(funcao_xn.ToString());

                erro = metodoBisseccao.calcular_erro_absoluto(inter_a, inter_b);
                lvi.SubItems.Add(erro.ToString());

                if (funcao_a * funcao_xn < 0)
                    inter_b = xn;

                if (funcao_b * funcao_xn < 0)
                    inter_a = xn;

                listView1.Items.Add(lvi);

                if (erro <= erro_abs)
                {
                    textBox4.Text = xn.ToString();
                    textBox5.Text = metodoBisseccao.estimar_quantidade_iteracoes(intervalo_a, intervalo_b, erro_abs).ToString();
                    break;
                }
            }
        }
    }
}
