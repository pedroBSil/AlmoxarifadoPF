using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoFS2.ComparacaoDePrecos
{
    internal class ComparacaoPreco
    {
        public static string CompararPreco(string precoMerL, string precokab, string linkkab, string linkMer)
        {
            char[] removerCaracteres = { 'R', '$', ' ' };

            double precokabum = Convert.ToDouble(precokab.Trim(removerCaracteres));
            double precoMercado = Convert.ToDouble(precoMerL.Trim(removerCaracteres));

            Console.WriteLine(precoMercado);
            Console.WriteLine(precokabum);

            if (precokabum > precoMercado)
            {
                return "Melhor preço: Mercado Livre\n" + $"Link do produto:{linkMer}";

            }
            else if (precoMercado > precokabum)
            {
                return "Melhor preço: kabum\n" + $"Link do produto:{linkkab}";
            }
            else
            {
                return "Preços iguais";
            }
        }
    }
}
   