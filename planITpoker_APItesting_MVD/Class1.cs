using System;
using Xunit;
using Refit;
using System.Threading.Tasks;

namespace planITpoker_APItesting_MVD
{
    public class User
    {
        public string Name { get; set; }
        public string user { get; set; }
    }
    public interface IplanITpokerAPI
    {
        [Post("/api/authentication")]
        [Headers("name=John")]
        Task CreateUser([Body(BodySerializationMethod.UrlEncoded)] User user, [Header("name")] string name);
    }
    public class UnitTest1
    {        
        [Fact]
        public async Task QuickPlayLogin()
        {
            var _user = new User();
            var _name = new User();
            var planITAPI = RestService.For<IplanITpokerAPI>("https://www.planitpoker.com/",
                new RefitSettings {
                    ContentSerializer = new XmlContentSerializer()
                 });
            var quick = await planITAPI.CreateUser(_user, "John");
            //Assert.Equal("John", quick.Name);
        }
    }

}
