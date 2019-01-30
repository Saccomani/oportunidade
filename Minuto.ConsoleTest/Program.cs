using System;
using Minuto.Data.Repositories;

namespace Minuto.DataDomain.Tests
{
    class Program
    {
        private const int separatorCount = 60;
        static void Main(string[] args)
        {

        
            try
            {
                var repo = new ChannelRepository();

                Console.WriteLine("Obtendo feeds..");
                Console.WriteLine(new String('-', separatorCount));

                var result = repo.GetChannels();

                Console.WriteLine("Encontrou... : " + result.Count);
                Console.WriteLine(new String('-', separatorCount));


                result.ForEach(item => { Console.WriteLine($"Titulo: {item.Title}"); });

                Console.WriteLine(new String('-', separatorCount));

                result.ForEach(x =>
                {
                    Console.WriteLine($"{x.GetCountOfWords().ToString("000000")} Palavras para | {x.Title}");
                });

                var resultTopWords = repo.GetTopWordByTopic(result);

                Console.WriteLine(new String('-', separatorCount));
                Console.WriteLine("Top 10 palavras por tópico");
                Console.WriteLine(new String('-', separatorCount));

                foreach (var item in resultTopWords)
                {
                    Console.WriteLine($"Tópico: { item.Key}");
                    Console.Write('\n');

                    foreach (var dicTopWords in item.Value)
                    {
                        Console.WriteLine(new String(' ', 3) + dicTopWords.Value.ToString("00") + " - " + dicTopWords.Key.ToUpper());
                    
                    }
              
                    Console.WriteLine(new String('-', separatorCount));

                }

                Console.ReadLine();
            }
            catch (TimeoutException ex)
            {
                Console.Write("Verifique sua conexao com a internet.\n\n" + ex.Message);
            }

            catch (Exception ex)
            {
                Console.Write("Erro ao tentar carregar os feeds: " + ex.Message);
            }

        }
    }
}
