using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace Target
{
    internal class Exercise3
    {
        public string LabelResultado;
        public List<Item> CalculoEx3JSON(string filePath)
        {
            string json = File.ReadAllText(filePath);

            List<Item> lista = JsonConvert.DeserializeObject<List<Item>>(json);
            return lista;
        }

        public double CalculoMedia(List<Item> lista)
        {
            double media = lista.Where(mv => mv.valor > 0)
                                .Average(mv => mv.valor);
            return media;
        }

        public double CalculoMenor(List<Item> lista)
        {
            double menorValor = lista.Where(mv => mv.valor > 0)
                                     .Min(mv => mv.valor);
            return menorValor;
        }

        public double CalculoMaior(List<Item> lista)
        {
            double maiorValor = lista.Where(mv => mv.valor > 0)
                                      .Max(mv => mv.valor);
            return maiorValor;
        }

        public int CalculoQtdeDias(List<Item> lista, double media)
        {
            int QtdeDias = lista.Count(qd => qd.valor > media); 
            return QtdeDias;
        }

        public string CalculoAcimaMediaDiaria(List<Item> lista, double media)
        {
            List<Item> vendasAcimaDaMedia = new List<Item>();

            foreach (Item item in lista)
            {
                if (item.valor > media)
                {
                    vendasAcimaDaMedia.Add(item);
                }
            }

            foreach (Item venda in vendasAcimaDaMedia)
            {
                LabelResultado += ($"{venda.dia} - {venda.valor}\n");
            }

            return LabelResultado;
        }

        public List<Item> LerEx3XML(string caminhoArquivo)
        {
            List<Item> itens = new List<Item>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<root>" + File.ReadAllText(caminhoArquivo) + "</root>");
            foreach (XmlNode node in xml.SelectNodes("root/row"))
            {
                Item item = new Item();
                item.dia = int.Parse(node.SelectSingleNode("dia").InnerText);
                item.valor = double.Parse(node.SelectSingleNode("valor").InnerText, CultureInfo.InvariantCulture);
                itens.Add(item);
            }
            return itens;
        }
    }
}
