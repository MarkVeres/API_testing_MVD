using System;
using Xunit;
using Refit;
using System.Threading.Tasks;

namespace planITpoker_APItesting_MVD
{
    public class User
    {
        public string Name { get; set; }
    }
    public interface IplanITpokerAPI
    {
        [Post("/api/authentication/{user}")]
        Task<User> PostUserName(string user);
    }
    public class UnitTest1
    {        
        [Fact]
        public async Task QuickPlayLogin()
        {
            var planITAPI = RestService.For<IplanITpokerAPI>("https://www.planitpoker.com/");
            var quick = await planITAPI.PostUserName("John");
            Assert.Equal("name=John", quick.Name);
        }
    }

}
