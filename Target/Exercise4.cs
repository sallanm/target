using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Target
{
    internal class Exercise4
    {
        public string Estado { get; set; }
        public double Valor { get; set; }

        public string Resultado;
        public string Calculo(List<Exercise4> estados, double total)
        {
            foreach (var estado in estados)
            {
                double percentual = (estado.Valor / total) * 100;
                //Console.WriteLine($"{estado.Estado} - R${estado.Valor} ({percentual:N2}%)");
                Resultado += ($"{estado.Estado} - R${estado.Valor} ({percentual:N2}%)\n");
            }
            return Resultado;
        }

        public double Total(List<Exercise4> estados) 
        {
            double total = estados.Sum(e => e.Valor);
            return total;
        }
    }
}
