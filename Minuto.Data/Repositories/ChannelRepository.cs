using System;
using System.Collections.Generic;
using Minuto.Data.Repositories.Base;
using Minuto.Domain.Entities;
using Minuto.Domain.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using Minuto.Infra.CrossCutting.Helpers;

namespace Minuto.Data.Repositories
{
    public class ChannelRepository:RepositoryBase<Channel>, IChannelRepository
    {
        public ChannelRepository()
        {

        }
  
        public List<Channel> GetChannels()
        {

            try
            {
                var cli = new HttpClient();
                cli.Timeout = new TimeSpan(0, 0, 20);

                var rss = cli.GetStringAsync("http://www.minutoseguros.com.br/blog/feed/");

                var items = System.Xml.Linq.XDocument.Parse(rss.Result)
                                .Descendants("item")
                                .Select(i => new Channel
                                {
                                    Title = (string)i.Element("title"),
                                    Link = (string)i.Element("link"),
                                    PublicationDate = (DateTime)i.Element("pubDate"),
                                    Description = (string)i.Element("{http://purl.org/rss/1.0/modules/content/}encoded"),

                                })
                .Take(10).ToList();

                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }


        public Dictionary<string, int> GetCountWordByTitle(List<Channel> listToVerify)
        {
            var ret = new Dictionary<string, int>();

            listToVerify.ForEach(x => ret.Add(x.Title, x.Description.Length));

            return ret;
        }

        public Dictionary<string, Dictionary<string, int>> GetTopWordByTopic(List<Channel> listToVerify)
        {
            var ret = new Dictionary<string, Dictionary<string, int>>();


            foreach (var item in listToVerify)
            {

                var textoSemPreposicao = PreposicoesHelper.ClearSentence(item.Description);
                var replaced = Regex.Replace(textoSemPreposicao, "/[,;.!:—\\/]/g", " ");

                string[] words = Regex.Split(replaced, @"\W");
              
                var occurrences = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    string lowerWord = word.ToLowerInvariant();
                    if (!occurrences.ContainsKey(lowerWord))
                        occurrences.Add(lowerWord, 1);
                    else
                        occurrences[lowerWord]++;
                }


                ret.Add(item.Title, (from wp in occurrences.OrderByDescending(kvp => kvp.Value)
                                     select wp).Take(10).ToDictionary(kw => kw.Key, kw => kw.Value));
            }

            return ret;
        }
    }
}
