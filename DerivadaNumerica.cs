using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico
{
    public class DerivadaNumerica
    {
        // Apenas essas funções são necessarias mudar.
        private double funcao(double x)
        {
            return Math.Sin(Math.Pow(x, 2) + x);
        }

        // Apenas essas funções são necessarias mudar.
        private double derivada(double x)
        {
            return Math.Cos(Math.Pow(x, 2) + x) * (2 * x + 1);
        }

        private double progressiva(double x, double h)
        {
            return (funcao(x + h) - funcao(x)) / h;
        }

        private double centrada(double x, double h)
        {
            return (funcao(x + h) - funcao(x - h)) / (2 * h);
        }

        private double regressiva(double x, double h)
        {
            return (funcao(x) - funcao(x - h)) / h;
        }

        public double resultado_progressiva(double x, double h)
        {
            return derivada(x) - progressiva(x, h);
        }

        public double resultado_centrada(double x, double h)
        {
            return derivada(x) - centrada(x, h);
        }

        public double resultado_regressiva(double x, double h)
        {
            return derivada(x) - regressiva(x, h);
        }
    }
}
