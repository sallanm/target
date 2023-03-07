using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Target
{
    internal class Exercise1
    {
        public int Calcular (int indice, int soma, int k)
        {
            while (k < indice)
            {
                k = k + 1;
                soma = soma + k;
            }
            return soma;
        }
    }
}
