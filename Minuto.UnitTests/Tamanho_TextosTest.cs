using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minuto.Data.Repositories;
using Minuto.Domain.Entities;
using System;
using System.Linq;

namespace Minuto.UnitTests
{
    [TestClass]
    public class TamanhoTextosTest
    {

        private List<Channel> _channels;

        [TestInitialize]  
        public void testInit()
        {
            var repo = new ChannelRepository();
            _channels = repo.GetChannels();
        }

        [TestMethod]
        public void QtdeArtigosTest_Test()
        {
            Assert.IsTrue(10 == _channels.Count);
        }
        [TestMethod]
        public void QtdeTextoTitulo_Test()
        {
            //arrange (massa de dados para o teste)
            var tituloArtigo = "Confira 4 aplicativos para viagem e saia do tédio no trânsito";
            var descriptionLengh = 9514; 
            //act
            var article = _channels.FirstOrDefault(a => a.Title == tituloArtigo);
            //assert
            Assert.IsTrue(descriptionLengh == article.Description.Count());
        }
        [TestMethod]
        public void QtdeArtigosInvalidoTest_Test()
        {
            Assert.IsFalse(11 == _channels.Count);
        }
    }
}
