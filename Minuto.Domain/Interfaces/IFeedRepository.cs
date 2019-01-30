using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Minuto.Domain.Entities;

namespace Minuto.Domain.Interfaces
{
    public interface IChannelRepository:IRepositoryBase<Channel>
    {
        List<Channel> GetChannels();
        Dictionary<string, int> GetCountWordByTitle(List<Channel> listToVerify);
        Dictionary<string, Dictionary<string, int>> GetTopWordByTopic(List<Channel> listToVerify);

    }
}
