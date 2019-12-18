using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace restSharp_Try
{
    public class API_test_class
    {
        [Fact]
        public void QuickPlayLogin()
        {
            RestSharpHelper<User> restApi = new RestSharpHelper<User>();
            var client = restApi.SetUrl("/api/authentication/anonymous");
            var request = restApi.CreatePostRequest();
            var response = restApi.GetResponse(client, request);

            string status = response.StatusCode.ToString();
            Assert.Equal("OK", status);

            //User content = restApi.GetContent<User>(response);
            //Assert.Equal("Jack", content.name);
        }
    }
}
