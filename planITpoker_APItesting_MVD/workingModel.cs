using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject2
{
    public class User
    {
        public string Name { get; set; }
    }
    public interface IGitHubApi
    {
        [Headers("User-Agent: Awesome Octocat App")]
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
            var octocat = await gitHubApi.GetUser("octocat");
            Assert.Equal("The Octocat", octocat.Name);
        }
    }
}
