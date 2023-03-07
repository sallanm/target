using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Target
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LabelText();
            Exercise1 ex1 = new Exercise1();
            ResultadoEx1.Content = ex1.Calcular(13, 0, 0);
            Ex4();
        }

        public void LabelText()
        {
            LabelEX1.Content = "Observe o trecho de código abaixo:\r\n\r\nint INDICE = 13, SOMA = 0, K = 0;\r\n\r\nenquanto K < INDICE faça\r\n{\r\nK = K + 1;\r\nSOMA = SOMA + K;\r\n}\r\n\r\nimprimir(SOMA);\r\n\r\nAo final do processamento, qual será o valor da variável SOMA?";
            LabelEX2.Content = "Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores \n(exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência \nde Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.\r\n\r\nIMPORTANTE:\r\nEsse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;";
            LabelEX3.Content = "Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, \nque calcule e retorne:\r\n• O menor valor de faturamento ocorrido em um dia do mês;\r\n• O maior valor de faturamento ocorrido em um dia do mês;\r\n• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.\r\n\r\nIMPORTANTE:\r\na) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;\r\nb) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;";
            LabelEX4.Content = "Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:\r\n\r\nSP – R$67.836,43\r\nRJ – R$36.678,66\r\nMG – R$29.229,88\r\nES – R$27.165,48\r\nOutros – R$19.849,53\r\n\r\nEscreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal \nda distribuidora.";
            LabelEX5.Content = "Escreva um programa que inverta os caracteres de um string.\r\n\r\nIMPORTANTE:\r\na) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;\r\nb) Evite usar funções prontas, como, por exemplo, reverse;";
        }

        private void BtnCalcularEx2(object sender, RoutedEventArgs e)
        {
            
            
            if (int.TryParse(TextNum.Text, out int numero) && numero > 0)
            {
                Exercise2 ex2 = new Exercise2();
                ResultadoEx2.Content = ex2.Calcular(1, 0, 0, true, "", Convert.ToInt32(TextNum.Text), "0");
                ResultadoEx2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Favor, informe um número inteiro válido e positivo", "Atenção!", MessageBoxButton.OK);
                ResultadoEx2.Visibility = Visibility.Hidden;
                TextNum.Text = "";
                TextNum.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tipoArquivo = Path.GetExtension(TextArquivoPath.Text);
            double media;
            double maiorValor;
            double menorValor;
            int qtdeDias;
            List<Item> lista = new List<Item>();
            if (BtnSelecionarArquivo.Content.ToString() == "Calcular") 
            {
                Exercise3 ex3 = new Exercise3();

                if (tipoArquivo == ".json")
                {
                    lista = ex3.CalculoEx3JSON(TextArquivoPath.Text.ToString());

                    menorValor = ex3.CalculoMenor(lista);
                    maiorValor = ex3.CalculoMaior(lista);
                    media = ex3.CalculoMedia(lista);
                    qtdeDias = ex3.CalculoQtdeDias(lista, media);
                }
                else
                {
                    lista = ex3.LerEx3XML(TextArquivoPath.Text.ToString());

                    menorValor = ex3.CalculoMenor(lista);
                    maiorValor = ex3.CalculoMaior(lista);
                    media = ex3.CalculoMedia(lista);
                    qtdeDias = ex3.CalculoQtdeDias(lista, media);
                }
                
                BtnSelecionarArquivo.Content = "Selecionar Arquivo";
                TextArquivoPath.Text = "";
                TextMenor.Text = menorValor.ToString();
                TextMaior.Text = maiorValor.ToString();
                TextQtdeDias.Text = qtdeDias.ToString();
                TextMedia.Text = media.ToString();


                ListaDias.Items.Clear();
                foreach (Item item in lista)
                {
                    ListaDias.Items.Add(new Item() { dia = item.dia, valor = item.valor });
                }

            }
            else
            {
                
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.DefaultExt = "(.json)|*.json|(.xml)|*.xml"; 
                dialog.Filter = "JSON (.json)|*.json|XML (.xml)|*.xml"; 

                dialog.ShowDialog();

                TextArquivoPath.Text = dialog.FileName;
            }
            
        }
        
        public void TextArquivoPathChanged(object sender, EventArgs e)
        {
            if(TextArquivoPath.Text.Length > 0)
            {
                BtnSelecionarArquivo.Content = "Calcular";
            }
            else
            {
                BtnSelecionarArquivo.Content = "Selecionar Arquivo";
            }
        }

        private void Ex4()
        {
            var estados = new List<Exercise4>()
            {
            new Exercise4 { Estado = "SP", Valor = 67836.43 },
            new Exercise4 { Estado = "RJ", Valor = 36678.66 },
            new Exercise4 { Estado = "MG", Valor = 29229.88 },
            new Exercise4 { Estado = "ES", Valor = 27165.48 },
            new Exercise4 { Estado = "Outros", Valor = 19849.53 }
            };

            Exercise4 ex4 = new Exercise4();
            double total = ex4.Total(estados);
            string teste = ex4.Calculo(estados, total);

            LabelResultadoEX4.Content = teste;
        }

        private void BtnInverterClick(object sender, RoutedEventArgs e)
        {
            Exercise5 ex5 = new Exercise5();
            TextBoxInvertida.Text = ex5.InverterString(TextBoxString.Text);
        }
    }
}
