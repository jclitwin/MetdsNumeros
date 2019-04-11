using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico.Secante
{
    public class MetodoSecantes
    {
        public double funcao(double x)
        {
            return Math.Pow(x, 2) + x - 6;
        }

        public double calcular_secante(double x, double xn)
        {
            return 0;
        }
    }
}
