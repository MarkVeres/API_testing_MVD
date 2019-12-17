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
            //RestSharpHelper restApi = new RestSharpHelper();
            //var client = restApi.SetUrl("/api/authentication/anonymous");
            //var request = restApi.CreatePostRequest();
            //IRestResponse response = client.Execute(request);

            var client = new RestClient("https://www.planitpoker.com/api/authentication/anonymous");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Cookie", "__cfduid=d5b74a13e6923e71a4997cdcb3c26b3291575446976; .AspNet.TwoFactorRememberBrowser=6HshiEfKlXIA7ZEDkGq-niGp3Eqpc_qKFYMmShx_x21fGs_ieH8rhYahkYm_EI9mXKSpeS_lfydmiEaT1Wy14YZR9kkJWsnNMv8G1S3fRKsPMixPyXktWhtMsP5mCjXnMG6wy8E8kocn0Hat2nTpJxXzEEoivLOp4tCdu2EK137__8eUXvh29nX7N6mWD1mW4f-W4nLJKs745qlqBVeGt0IANurhf8ezQEqkUoXqXw5l_TfG00OoZpx3HADqs82Xf_ZPPAozX5acGEQgR_Lxp1eFjB01vOuYMhGMrI1IrErnSDPIU6al58GPMDZpJ1w6; .AspNet.ApplicationCookie=-gZtzrrupPJGK_7AGv2soltfbuO5I20vSZBj2suEwdWX-bU1xo7v8o2ZYhHDWu78pG1z1J4lyc5NQnSiE8nUirkkMnbJeDTLrNbBUXNp8vphC7BBC6gJXbTBT9vKPDSUdzn-JLfTrlkyuD3tV83Y46Squ2PXMe5BcPAHn80qLFFtq2J9MO38mw38FeAPK3pQ0uPpw5X2y0lsinwGgsNT8MgOZbIjn6Vb8mSdvobtzB4WhZXna27_0Y1OevKvd_M6eD9549ViDa85fdCTAZCSDS2Dhli8UblzF1REo5SifiCcdKoymaOcqqcAhUeYeBevWqD110Cv275kj9Uaj8vaNbd-HyCr_NvN5yq8uoPlXqAHiUplA-v-RXgPaZBihi4XhxqplflrnbyMvAqbrL8CC6O-zgSzfXLvFwCfFD1y-0g");
            request.AddHeader("Content-Length", "9");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "www.planitpoker.com");
            request.AddHeader("Postman-Token", "5f46f56a-faa1-4e4a-b559-00388a068a27,2a91a319-4ba3-4860-873a-6dcd12a84b84");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", "name=Jack", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            int length = response.Content.Length;
            Assert.Equal(2, length);
        }
    }
}
