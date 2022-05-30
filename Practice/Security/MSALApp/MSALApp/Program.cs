using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace MSALApp
{
    class Program
    {
        private static string _clientId;
        private static string _tenantId;
        static Program()
        {
            _clientId = Configuration.Instance.GetValue("AzureAd", "ClientId");
            _tenantId = Configuration.Instance.GetValue("AzureAd", "TenantId");
        }

        public static async Task Main(string[] args)
        {
            try
            {
                var app = PublicClientApplicationBuilder
                            .Create(_clientId)
                            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                            .WithRedirectUri("http://localhost")
                            .Build();

                string[] scopes = { "user.read" };
                var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

                Console.WriteLine($"Access Token: \t {result.AccessToken}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
