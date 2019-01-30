using System.Collections.Generic;

namespace Minuto.Domain.Entities.Dto
{
    public class TopWordsFromTopic
    {
        public string Title { get; set; }
        public List<TopWord> Words { get; set; }

        public TopWordsFromTopic()
        {
            this.Words = new List<TopWord>();
        }
    }
}