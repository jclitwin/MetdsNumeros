using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico.PosicaoFalsa
{
    public class MetodoPosicaoFalsa
    {
        // Apenas essas funções são necessarias mudar.
        public double funcao(double x)
        {
            //return Math.Pow(x, 2) - 3;
            return Math.Pow(x, 3) - 9 * x + 3;
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
            //return (intervalo_a + intervalo_b) / 2;

            return ((intervalo_a * funcao(intervalo_b)) - (intervalo_b * funcao(intervalo_a))) / (funcao(intervalo_b) - funcao(intervalo_a));
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
