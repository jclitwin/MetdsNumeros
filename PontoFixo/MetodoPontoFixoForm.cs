using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtdNumerico.PontoFixo
{
    public partial class MetodoPontoFixoForm : Form
    {
        public MetodoPontoFixoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            double.TryParse(textBox2.Text, out double intervalo_a);
            double.TryParse(textBox3.Text, out double intervalo_b);
            double.TryParse(textBox1.Text, out double x0);
            double.TryParse(textBox6.Text, out double modulo_funcao_xn);

            if(string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("É necessário definir o valor.");
                return;
            }

            MetodoPontoFixo metodoPontoFixo = new MetodoPontoFixo();

            if (metodoPontoFixo.verificar_raiz_intervalo(intervalo_a, intervalo_b) == false)
            {
                MessageBox.Show("Não há raiz!");
                return;
            }

            double xn = x0;
            double funcao_xn = 0;
            double funcao_isolada_xn = 0;

            for (int i = 0; ; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = i.ToString();
                lvi.SubItems.Add(xn.ToString());

                funcao_xn = metodoPontoFixo.funcao(xn);
                lvi.SubItems.Add(funcao_xn.ToString());

                funcao_isolada_xn = metodoPontoFixo.funcao_isolada(xn);
                lvi.SubItems.Add(funcao_isolada_xn.ToString());

                

                xn = funcao_isolada_xn;

                listView1.Items.Add(lvi);

                if (Math.Abs(funcao_xn) < modulo_funcao_xn)
                {
                    textBox4.Text = xn.ToString();
                    break;
                }
            }

        }
    }
}
