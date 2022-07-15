using MemeFactory.Api.Services;

namespace MemeFactory.Test
{
    [TestClass]
    public class MemeFactoryServiceTest
    {
        private readonly MemeFactoryService _memeFactoryService;

        public MemeFactoryServiceTest()
        {
            _memeFactoryService = new MemeFactoryService();
        }
        [TestMethod]
        public void AddText_ShouldReturnNull()
        {
            var result = _memeFactoryService.AddText(null, null);

            Assert.IsNull(result);
        }
    }
}