using System;
namespace WebApi.Models
{
    static class Config
    {
        public static string BaseURL { get; } = "https://api-demo.airwallex.com";

        public static string ClientKey { get; } = "a33b98c4f02e1a4e98d3ce1312e0a413a5f2a2988d6b9ed7b4dc1b713270d933a3e10565ee91558ba240d5615ed55750";

        public static string ClientID { get; } = "OKxMutbETMeZCXseHaop6g";

        public static string Token { get; } = "/api/v1/authentication/login";

        public static string Beneficiaries { get; } = "/api/v1/beneficiaries";

    }
}
