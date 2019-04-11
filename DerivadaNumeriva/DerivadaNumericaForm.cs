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
    public partial class DerivadaNumericaForm : Form
    {
        public DerivadaNumericaForm()
        {
            InitializeComponent();

            textBox3.Enabled = checkBox1.Checked;
            textBox3.Text = string.Format("6");
        }

        static double Truncate(double value, int digits)
        {
            double mult = System.Math.Pow(10.0, digits);
            return System.Math.Truncate(value * mult) / mult;
        }

        private double maximoCasasDecimais(double valor)
        {
            int.TryParse(textBox3.Text, out int maxDeCasas);

            //var novo_valor = Truncate

            ////return Convert.ToDouble(valor.ToString(string.Format("N{0}", maxDeCasas)));
            ////return Convert.ToDouble(valor.ToString(string.Format("N{0}", maxDeCasas)));
            //string 
            //var str = String.Format("{1:F{0}}", maxDeCasas, valor);

            //double.TryParse(textBox3.Text, out double v);
            return Truncate(valor, maxDeCasas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("É preciso definir o valor de f'(x) !");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("É preciso definir o valor de h !");
                return;
            }

            if(checkBox1.Checked)
            {
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("É preciso definir o numero maximo de casas decimais");
                    return;
                }

                double.TryParse(textBox3.Text, out double c);
                if (c <= 0)
                {
                    MessageBox.Show("Numero de casas decimais precisa ser maior que 0");
                    return;
                }
            }

            DerivadaNumerica dn = new DerivadaNumerica();

            // Converter string para double o valor de x.
            double.TryParse(textBox1.Text, out double x);

            // Converter os valores obtidos de h para double.
            var h_array = textBox2.Text.Split('|');
            if(h_array.Length <= 0)
            {
                MessageBox.Show("Erro na conversão de H.");
                return;
            }

            foreach (var hValue in h_array)
            {
                double.TryParse(hValue, out double h);

                /////////////////////////////////////////////////////////////
                var progressiva = dn.resultado_progressiva(x, h);

                ListViewItem lviProg = new ListViewItem();
                lviProg.Text = h.ToString();
                lviProg.SubItems.Add( (checkBox1.Checked) ? maximoCasasDecimais(progressiva).ToString() : progressiva.ToString());

                listView1.Items.Add(lviProg);

                /////////////////////////////////////////////////////////////
                var centrada = dn.resultado_centrada(x, h);

                ListViewItem lviCent = new ListViewItem();
                lviCent.Text = h.ToString();
                lviCent.SubItems.Add((checkBox1.Checked) ? maximoCasasDecimais(centrada).ToString() : centrada.ToString());

                listView2.Items.Add(lviCent);

                /////////////////////////////////////////////////////////////
                var regressiva = dn.resultado_regressiva(x, h);

                ListViewItem lviRegr = new ListViewItem();
                lviRegr.Text = h.ToString();
                lviRegr.SubItems.Add((checkBox1.Checked) ? maximoCasasDecimais(regressiva).ToString() : regressiva.ToString());

                listView3.Items.Add(lviRegr);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox1.Checked;
            textBox3.Text = string.Format("6");
        }
    }
}
