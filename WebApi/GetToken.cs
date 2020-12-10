using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using WebApi.Models;
//using System.Text.Json;

using Newtonsoft.Json;


namespace WebApi
{
    public class GetToken
    {

        public GetToken() { }

        public string GetWebToken()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(Config.BaseURL);

            var request = new RestRequest(Config.Token, Method.POST);

            //request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", Config.ClientKey);
            request.AddHeader("x-client-id", Config.ClientID);


            request.AddParameter("application/json", @"{}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            //var token = JsonSerializer.Deserialize<WebToken>(response.Content);

            WebToken token = JsonConvert.DeserializeObject<WebToken>(response.Content);
            return token.token;
        }
    }
}
