using Newtonsoft.Json;
using RestSharp;
using SankhyaAuthTester.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankhyaAuthTester.AuthRoute
{
    public class AuthorizeRoute
    {
        string _url { get; set; } = "http://allog.snk.ativy.com:50079/mge/service.sbr?serviceName=MobileLoginSP.login&outputType=json";
        public string GetToken()
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                using (var cliente = new HttpClient(httpClientHandler))
                {
                    var body = @"{
                    " + "\n" +
                    @"   ""serviceName"": ""MobileLoginSP.login"",
                    " + "\n" +
                    @"      ""requestBody"": {
                    " + "\n" +
                    @"           ""NOMUSU"": {
                    " + "\n" +
                    @"               ""$"": ""sup""
                    " + "\n" +
                    @"           },
                    " + "\n" +
                    @"           ""INTERNO"":{
                    " + "\n" +
                    @"              ""$"":""##3030@llog""
                    " + "\n" +
                    @"           },
                    " + "\n" +
                    @"          ""KEEPCONNECTED"": {
                    " + "\n" +
                    @"              ""$"": ""S""
                    " + "\n" +
                    @"          }
                    " + "\n" +
                    @"      }
                    " + "\n" +
                    @"  }";

                    //string JsonObjeto = JsonConvert.SerializeObject(body);

                    var content = new StringContent(body, Encoding.UTF8, "text/plain");

                    var result = cliente.PostAsync(_url, content).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var tokenJson = result.Content.ReadAsStringAsync().Result;
                        SankhyaReturn Token = new SankhyaReturn();
                        Token = System.Text.Json.JsonSerializer.Deserialize<SankhyaReturn>(tokenJson.ToString());
                        string token = Token.responseBody.jsessionid.jsessionid;
                        return token ;
                    }
                    return null;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
