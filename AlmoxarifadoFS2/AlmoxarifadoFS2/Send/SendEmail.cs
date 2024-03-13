using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoFS2.Send
{

    public class SendEmail
    {

        public static string pedirEmail()
        {
            Console.WriteLine("Informe o e-mail para envio da comparação de produtos:");
            string emailUsuario = Console.ReadLine();
            return emailUsuario;
        }

        public static void EnviarEmail(string Comparacao, string nomeProdutoMercadoLivre, string precoProdutoMercadoLivre, string nomeProdutoMagazineLuiza, string precoProdutoMagazineLuiza, string emailUsuario)
        {
            // Configurações do servidor SMTP do Gmail
            string smtpServer = "smtp-mail.outlook.com"; // Servidor SMTP do Gmail
            int porta = 587; // Porta SMTP do Gmail para TLS/STARTTLS
            string remetente = "igorsenaiteste@outlook.com"; // Seu endereço de e-mail 
            string senha = "senai.123"; // Sua senha do email

            // Configurar cliente SMTP
            using (SmtpClient client = new SmtpClient(smtpServer, porta))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(remetente, senha);
                client.EnableSsl = true; // Habilitar SSL/TLS

                string recipient = "marsemaster@gmail.com"; // Endereço de e-mail do destinatário
                string subject = "Assunto do E-mail";
                string body = "Este é o conteúdo do e-mail.";

                // Construir mensagem de e-mail
                MailMessage mensagem = new MailMessage(remetente, emailUsuario)
                {
                    Subject = "Resultado da comparação de preços",
                    Body = $"Produto do Mercado Livre: {nomeProdutoMercadoLivre}\nPreço: R$ {precoProdutoMercadoLivre}\n" +
                           $"Produto do Magazine Luiza: {nomeProdutoMagazineLuiza}\nPreço: {precoProdutoMagazineLuiza}\n" +
                           $"{Comparacao}"
                };

                // Enviar e-mail
                client.Send(mensagem);


                Console.WriteLine(nomeProdutoMercadoLivre);
                Console.WriteLine(precoProdutoMercadoLivre);
                Console.WriteLine(nomeProdutoMagazineLuiza);
                Console.WriteLine(precoProdutoMagazineLuiza);

            }
        }
    }
}

