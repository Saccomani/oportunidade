using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minuto.Data.Repositories;
using Minuto.Domain.Interfaces;
using Minuto.Domain.Entities.Dto;

namespace Minuto.Angular.Api.Controllers
{
    [Route("api/[controller]")]
    public class FeedController : Controller
    {
        private readonly IChannelRepository _repository;
        public FeedController(IChannelRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("GetFeeds")]
        public IActionResult GetFeeds()
        {
            var feedList = _repository.GetChannels();

            return Ok(feedList);
        }

        [HttpGet]
        [Route("GetTopWordFromTopic")]
        public IActionResult GetTopWordFromTopic()
        {
            var feedList = _repository.GetChannels();
            var resultDictionary = _repository.GetTopWordByTopic(feedList);
            var list= new List<TopWordsFromTopic>();

            foreach (var item in resultDictionary)
            {

                var topicInfo= new TopWordsFromTopic();
                topicInfo.Title = item.Key ; 

                foreach (var dicTopWords in item.Value)
                {
                    topicInfo.Words.Add(new TopWord { Word = dicTopWords.Key, Count = dicTopWords.Value });
                }

                list.Add(topicInfo);
            }
            return Ok(list);
        }
    }
}
