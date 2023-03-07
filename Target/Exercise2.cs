using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Target
{
    internal class Exercise2
    {

        public string Calcular(int fibonacci, int num, int valAuxiliar, bool pertence, string resultado, int val, string sequencia)
        {

            while (fibonacci <= val)
            {
                sequencia += ", " + fibonacci;
                if (fibonacci == val) pertence = true; else pertence = false;

                valAuxiliar = num;
                num = fibonacci;
                fibonacci = num + valAuxiliar;
            }

            string x = (pertence == true) ? x = "Verdadeiro! O número " + val + " pertence à sequencia" : x = "Falso! O número " + val + " não pertence à sequencia";
            return resultado = "Sequência fibonacci: \n" + sequencia + "\n\n" + x;
        }
    }
}
