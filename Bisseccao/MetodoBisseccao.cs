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
            //return Math.Pow(x, 2) - 3;
            return Math.Cos(x) * Math.Pow(x, 2) - x;
        }

        private double raizintervalo(double x)
        {
            return funcao(x);
        }

        public bool verificar_raiz_intervalo(double intervalo_a, double intervalo_b)
        {
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

        public double estimar_quantidade_iteracoes(double intervalo_a, double intervalo_b, double erro)
        {
            return ((Math.Log(intervalo_b - intervalo_a)) - Math.Log(erro)) / Math.Log(2);
        }
    }
}
