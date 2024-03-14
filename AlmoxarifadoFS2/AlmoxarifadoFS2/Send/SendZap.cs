using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoFS2.Send
{
    using System;

    public class SendZap
    {
        // Verificar se o usuário deseja receber mensagem no whatsapp
        public static string verificarMensagem()
        {
            Console.WriteLine("Deseja receber a comparação também via WhatsApp?\nTecle 1 para sim e 2 para não");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                Console.WriteLine("Digite o número de celular (com DDD) que receberá a mensagem");
                string numUsuario = Console.ReadLine();
                return numUsuario;

            }
            else
            {
                return null;
            }
        }

        // Enviar mensagem no whatsapp
        public static void SendWhatsApp(string Comparacao, string nomeProdutoMercadoLivre, string precoProdutoMercadoLivre, string nomeProdutoMagazineLuiza, string precoProdutoMagazineLuiza, string numUsuario)
        {

            string message = $"Produto do Mercado Livre: {nomeProdutoMercadoLivre}\nPreço: R$ {precoProdutoMercadoLivre}\n" +
                             $"Produto do Magazine Luiza: {nomeProdutoMagazineLuiza}\nPreço: {precoProdutoMagazineLuiza}\n" +
                             $"{Comparacao}\n";

            try
            {


                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();
                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                parameters.Add("apikey", "71eda880-a74b-4689-b1cc-68e95b004b32"); // Chave API
                parameters.Add("phone_number", "5579996073754"); // Número conectado
                parameters.Add("contact_phone_number", $"55{numUsuario}"); // Número receptor da mensagem

                parameters.Add("message_custom_id", "tste");

                parameters.Add("message_type", "text");
                parameters.Add("message_body", message);

                string responseString = "";
                byte[] response_data;

                response_data = client.UploadValues(url, "POST", parameters);
                responseString = System.Text.UnicodeEncoding.UTF8.GetString(response_data);

                Console.WriteLine(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAIL: {ex.Message}");
            }

            Console.ReadLine();

            Environment.Exit(0);
        }
    }

}