using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

public class kabumScraper
{
    public string ObterPreco(string descricaoProduto, int idProduto)
    {
        try
        {
            // Inicializa o ChromeDriver
            using (IWebDriver driver = new ChromeDriver())
            {
                // Abre a página
                string url = $"https://www.kabum.com.br//busca/{descricaoProduto}";
                driver.Navigate().GoToUrl(url);

                // Aguarda um tempo fixo para permitir que a página seja carregada (você pode ajustar conforme necessário)
                System.Threading.Thread.Sleep(5000);

                // Encontra o elemento que possui o atributo data-testid
                IWebElement priceElement = driver.FindElement(By.CssSelector("[data-testid='price-value']"));

                // Verifica se o elemento foi encontrado
                if (priceElement != null)
                {
                    // Obtém o preço do primeiro produto
                    string firstProductPrice = priceElement.Text;

                    // Registra o log com o ID do produto
                    RegistrarLog("132630", "Igor", DateTime.Now, "WebScraping - kabum", "Sucesso", idProduto);

                    // Retorna o preço
                    return firstProductPrice;
                }
                else
                {
                    Console.WriteLine("Preço não encontrado.");

                    // Registra o log com o ID do produto
                    RegistrarLog("132630", "Igor", DateTime.Now, "WebScraping - kabum", "Preço não encontrado", idProduto);

                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a página: {ex.Message}");

            // Registra o log com o ID do produto
            RegistrarLog("132630", "Igor", DateTime.Now, "Web Scraping - kabum", $"Erro: {ex.Message}", idProduto);

            return null;
        }
    }

    private static void RegistrarLog(string codRob, string usuRob, DateTime dateLog, string processo, string infLog, int idProd)
    {

        using (var context = new LogContext())
        {
            var log = new Log
            {
                CodRob = codRob,
                UsuRob = usuRob,
                DateLog = dateLog,
                Processo = processo,
                InfLog = infLog,
                IdProd = idProd
            };
            context.Logs.Add(log);
            context.SaveChanges();
        }

    }

    public static string PegarLink(string nomeProduto)
    {
        string url = $"https://www.kabum.com.br//busca/{nomeProduto.Replace(" ", "+")}";
        return url;
    }

}


