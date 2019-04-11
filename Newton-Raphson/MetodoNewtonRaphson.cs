using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico.Newton_Raphson
{
    public class MetodoNewtonRaphson
    {
        // Apenas essas funções são necessarias mudar.
        public double funcao(double x)
        {
            //return (Math.Pow(x, 3) - (9 * x)) + 3;
            return Math.Cos(x) - Math.Pow(x, 2);
        }

        public double funcao_derivada(double x)
        {
            //return (3 * (Math.Pow(x, 2))) - 9;
            return Math.Sin(x) + 2 * x;
        }

        public double funcao_xn_plus_1(double x)
        {
            return x + (funcao(x) / funcao_derivada(x));
        }

        public bool verificar_raiz_intervalo(double intervalo_a, double intervalo_b)
        {
            var a = funcao(intervalo_a);
            var b = funcao(intervalo_b);
            return ((a * b) > 0) ? false : true;
        }
    }
}
