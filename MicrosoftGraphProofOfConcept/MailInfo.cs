using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace MicrosoftGraphProofOfConcept
{
	public partial class frmSendMail : Form
	{
		public frmSendMail()
		{
			InitializeComponent();
		}

		private async void SendMail_ClickAsync(object sender, EventArgs e)
		{
			Button triggeredButton = (Button)sender;
			//set up authenticiation
			AuthenticationResult authResult = null;
			var app = Program.PublicClientApp;
			var accounts = await app.GetAccountsAsync();
			IAccount firstAccount = accounts.FirstOrDefault();
			//must set scopes above the 4 basic scopes in app in addition to in Azure
			string[] localScope = new string[] { "Mail.Send", "Mail.ReadWrite" };
			try
			{
				/* we first try acquiring the token silently, but if this fails (e.g., user may have signed out), we'll try the interactive acquisition
				 */
				authResult = await Program.PublicClientApp.AcquireTokenSilent(localScope, firstAccount)
					.ExecuteAsync();
			}
			catch (MsalUiRequiredException ex)
			{
				try
				{
					//interactive auth fallback
					authResult = await app.AcquireTokenInteractive(scopes)
											.WithAccount(firstAccount)
											.WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
											.WithExtraScopesToConsent(localScope)
											.ExecuteAsync();
				}
				catch (MsalException msalex)
				{
					MessageBox.Show($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
				return;
			}
			//if we got back a good auth result when we tried to acquire the token, let's proceed
			if (authResult != null)
			{
				//once we're authed, we need to new up a graphClient, which is what will do the work for us
				GraphServiceClient graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
				{
					// Add the access token in the Authorization header of the API request.
					requestMessage.Headers.Authorization =
							new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
				})
				);
				//create our email message based on form content
				var message = new Microsoft.Graph.Message
				{
					Subject = this.txtSubject.Text,
					Body = new ItemBody
					{
						ContentType = BodyType.Text,
						Content = this.txtBody.Text
					},
					ToRecipients = new List<Recipient>()
					{
						new Recipient
						{
							EmailAddress = new EmailAddress
							{
								Address = this.txtTo.Text
							}
						}
					}
					//there are a number of other properties that can be set, such as read receipts, importance and more
				};
				if(this.txtCopy.Text.Length > 0)
                {
					message.CcRecipients = new List<Recipient>() {
						new Recipient
                        {
							EmailAddress = new EmailAddress{Address = this.txtCopy.Text}
                        }
					};
                }
				if(this.txtBcc.Text.Length > 0)
                {
					message.BccRecipients = new List<Recipient>() {
						new Recipient
						{
							EmailAddress = new EmailAddress{Address = this.txtBcc.Text}
						}
					};
				}
				//handle any attachments
				if (this.txtAttachment.Text.Length > 0)
                {
					FileInfo fileInfo = new FileInfo(this.txtAttachment.Text);
                    byte[] doc = System.IO.File.ReadAllBytes(this.txtAttachment.Text);

					var attachment = new FileAttachment
                    {
                        Name = fileInfo.Name,
                        ContentBytes = doc,
						Size = (int)fileInfo.Length

					};
					//append the attachments to the Graph.Message
                    message.Attachments = new MessageAttachmentsCollectionPage
                    {
                        attachment
                    };
                }


				await graphClient.Me
					.SendMail(message, true)
					.Request()
					.PostAsync();


				MessageBox.Show("Email sent");
			}


		}


        private async void ChooseFile_ClickAsync(object sender, EventArgs e)
        {
			var openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = "C:\\",
				Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
				FilterIndex = 2,
				RestoreDirectory = true
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
				txtAttachment.Text = openFileDialog.FileName;
            }
        }
    }

}
