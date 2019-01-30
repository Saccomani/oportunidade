using System;
using Minuto.Domain.Entities.Base;
using Minuto.Infra.CrossCutting.Helpers;

namespace Minuto.Domain.Entities
{
    public class Channel :EntityBase
    {

        public Channel()
        {

        }

        public string Title { get; set; }

         public string Link { get; set; }

        public string Link2 { get; set; }

        public string Description { get; set; }

        public string LastBuildDate { get; set; }

        public string Language { get; set; }

        public string UpdatePeriod { get; set; }
 
        public string UpdateFrequency { get; set; }
  
        public string Generator { get; set; }

        public DateTime PublicationDate { get; set; }

        public int GetCountOfWords()
        {
            return Description.Length; 
        }

        public string WordsWithoutPreposicoes
        {
        get{ 

            return PreposicoesHelper.ClearSentence(Description);
        }
            
        }
    }
}
