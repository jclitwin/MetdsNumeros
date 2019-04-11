using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtdNumerico.Secante
{
    public class MetodoSecantes
    {
        public double f(double x)
        {
            return Math.Pow(x, 2) + x - 6;
        }

        public double calcular_secante(double x0, double x1)
        {
            return (x0 * f(x1) - x1 * f(x0)) / (f(x1) - f(x0));
        }
    }
}
