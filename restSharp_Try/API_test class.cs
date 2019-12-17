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
            RestSharpHelper restApi = new RestSharpHelper();
            var client = restApi.SetUrl("/api/authentication/anonymous");
            var request = restApi.CreatePostRequest("name=Jack");
            IRestResponse response = client.Execute(request);

            int resLength = response.Content.Length;

            //Length should be 0, although Postman returns length = 2
            Assert.Equal(0, resLength);
            // How to assert name from the request ???
        }
    }
}
