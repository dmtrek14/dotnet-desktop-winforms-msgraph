using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosoftGraphProofOfConcept
{
    static class Program
    {
		public static string ClientId = Environment.GetEnvironmentVariable("ClientId", EnvironmentVariableTarget.User);
		public static string Tenant = Environment.GetEnvironmentVariable("Tenant", EnvironmentVariableTarget.User);
		private static IPublicClientApplication clientApp;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeAuth();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSendMail());
        }

        public static IPublicClientApplication PublicClientApp { get { return clientApp; } }

        private static void InitializeAuth()
        {

            clientApp = PublicClientApplicationBuilder.Create(ClientId)
                    .WithDefaultRedirectUri()
                    .WithAuthority(AzureCloudInstance.AzurePublic, Tenant)
                    .Build();

            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);

        }
    }
}
