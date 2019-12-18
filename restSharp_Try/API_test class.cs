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
            var request = restApi.CreatePostRequest();
            IRestResponse response = client.Execute(request);

            //var client = new RestClient("https://www.planitpoker.com/api/authentication/anonymous");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Connection", "keep-alive");
            //request.AddHeader("Cookie", "__cfduid=d5b74a13e6923e71a4997cdcb3c26b3291575446976; .AspNet.TwoFactorRememberBrowser=9KcmnpG0WDReU5M-3rP-SJZo2kROvz2UB9yitPpW8kHDGzC6axnFyOKLitencNZhby1nWtXeBmaY4wbfNPP09fANQxQrk9spS1QXhM-X_Jn0zJNe6zywKpc3Q-gZUzcm8tX1UtN9JvAlywAMguh0rgmoXkJZYuzIEqFNNh38xKouYUnbQzs72Fa22F78GLlV-qw_3YAG0LPQquMwcGDSH3F4RH4ufYMME6cCDWenIoioS485_KKuXRHy6nAqdnoFIy-a6Zj4opuu2q5j9SyktxtKObA_jOj7Z9Y4m0c0OT5tAsgrqphNco-SP2fRN_o6; .AspNet.ApplicationCookie=Kl-ZvYKldYbkUJZxItXjwhoV9QHjpNThmV3HFjqacNlSfP6j3bzh__W8BXzqWcXrKgfZLXeMrqn9IkZTsFxknZQLeCUBFqxd2e6DDMAP0klImaNJXwgTOdTlIF6-WINWfgMs-M81RuoLpwEtv1vdXxelRUHrHGX-gavKSR806L3QclxzTU4YW1aPV6Sq7_C6O4HZu_kwUhQozKW5w_v0HILOVbhjO50LmD_RWaQkcz8XEeFdW6xm0DJ4rYf9plN1wvTlVh1Sa8-L-IZndCWqUg9Xjy49jP8ifSJ9duhv_GBQbXxOa0sb3qkbX1OLe1IdDyVpbPJSuIxgJsVUTciO5uNW0RWvjMT9sBsSMg_6xyRyaOhvcgKDXK3UIIRGc8Wq5uVMH2AS9HY5DLrkwQBQZs7VdNOgkOKGdADu5exOzdY");
            //request.AddHeader("Content-Length", "9");
            //request.AddHeader("Accept-Encoding", "gzip, deflate");
            //request.AddHeader("Host", "www.planitpoker.com");
            //request.AddHeader("Postman-Token", "157aa182-971a-42eb-ac4f-22f3cfd1428c,2fdb85b6-5ecb-46ff-8a4c-306f30b7281f");
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Accept", "*/*");
            //request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddParameter("undefined", "name=Jack", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            string status = response.StatusCode.ToString();
            Assert.Equal("OK", status);
        }
    }
}
