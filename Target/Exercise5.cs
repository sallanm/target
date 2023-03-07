using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target
{
    class Exercise5
    {
        public string InverterString(string texto)
        {
            string stringInvertida = "";

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                stringInvertida += texto[i];
            }

            return stringInvertida;
        }
    }
}
