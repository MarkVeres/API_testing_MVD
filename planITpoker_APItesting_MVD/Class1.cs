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
    public interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<User> GetUser(string user);

        [Get("")]
        Task<string> GetGoogle();

        [Get("/quickplay/")]
        Task<string> GetQuick();

        [Get("/board/")]
        Task<string> GetBoard();
    }
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
            var octocat = await gitHubApi.GetUser("octocat");
            Assert.Equal("octocat", octocat.Name);
        }
        [Fact]
        public async Task planIT()
        {
            var planITAPI = RestService.For<IGitHubApi>("https://www.planitpoker.com/");
            var quick = await planITAPI.GetQuick();
            Assert.NotNull(quick);
        }
        [Fact]
        public async Task TestGoogle()
        {
            var googleAPI = RestService.For<IGitHubApi>("https://www.google.com/");
            var google = await googleAPI.GetGoogle();
            Assert.NotNull(google);
        }
        [Fact]
        public async Task TestBoard()
        {
            var googleAPI = RestService.For<IGitHubApi>("https://www.planitpoker.com/");
            var google = await googleAPI.GetBoard();
            Assert.NotNull(google);
        }
    }

}
