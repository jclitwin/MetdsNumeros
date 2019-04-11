using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico.Bisseccao
{
    public class MetodoBisseccao
    {
        // Apenas essas funções são necessarias mudar.
        public double funcao(double x)
        {
            return Math.Pow(x, 2) - 3;
        }

        // Apenas essas funções são necessarias mudar.
        //private double derivada(double x)
        //{
        //    return Math.Cos(Math.Pow(x, 2) + x) * (2 * x + 1);
        //}

        private double raizintervalo(double x)
        {
            return funcao(x);
        }

        public bool verificar_raiz_intervalo(double intervalo_a, double intervalo_b)
        {
            //var x = raizintervalo(intervalo_a);
            //var y = raizintervalo(intervalo_b);
            //
            //var sinalX = (x > 0) ? true : false;
            //var sinalY = (y > 0) ? true : false;
            //
            //return (sinalX != sinalY) ? true : false;
            var a = funcao(intervalo_a);
            var b = funcao(intervalo_b);
            return ((a * b) > 0) ? false : true;
        }

        public double calcularXN(double intervalo_a, double intervalo_b)
        {
            return (intervalo_a + intervalo_b) / 2;
        }

        public double calcular_erro_absoluto(double intervalo_a, double intervalo_b)
        {
            return intervalo_b - intervalo_a;
        }
    }
}
