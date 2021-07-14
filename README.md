# Introduction 
This is a sample WinForms app to demonstrate how to wire-up non-SMTP email with Office365. Microsoft has examples for WPF and UWP, but not WinForms, hence the creation of this small app.

### How to Set Up 
1. Register application with Azure
2. Set the permissions in Azure to the desire scopes. In this case, you'll need to add "Mail.Send" and "Mail.ReadWrite" for Microsoft Graph to allow proper permissions for sending emails and attachments. Scopes will also need to be specified in the application itself (~line 29 in MailInfo.cs in the sample)
3. Use the ClientId and TenantId from app registration on Azure in local application (Program.cs)
4. Restore packages


## Additional Informational and Documentation Links
- [Authenication and auth basics for Microsoft Graph](https://docs.microsoft.com/en-us/graph/auth/auth-concepts)
- [Using the Outlook mail REST API (Graph)](https://docs.microsoft.com/en-us/graph/api/resources/mail-api-overview?view=graph-rest-1.0)
- [Get access without a signed-in user (for services or daemons)](https://docs.microsoft.com/en-us/graph/auth-v2-service)
