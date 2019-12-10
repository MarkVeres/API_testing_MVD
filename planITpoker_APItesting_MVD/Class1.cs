using System;
using Xunit;
using Refit;
using System.Threading.Tasks;

namespace planITpoker_APItesting_MVD
{
    public interface IplanITpokerAPI
    {
        [Post("/quickplay/")]
        Task<string> PostUserName(string name);
    }
    public class UnitTest1
    {        
        [Fact]
        public async Task planIT()
        {
            var planITAPI = RestService.For<IplanITpokerAPI>("https://www.planitpoker.com/");
            var quick = await planITAPI.PostUserName("John");
        }
    }

}
