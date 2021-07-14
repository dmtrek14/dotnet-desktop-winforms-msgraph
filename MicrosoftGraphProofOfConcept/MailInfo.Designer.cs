
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace MicrosoftGraphProofOfConcept
{
	partial class frmSendMail
	{
		//Set the API Endpoint to Graph 'me' endpoint. 
		// To change from Microsoft public cloud to a national cloud, use another value of graphAPIEndpoint.
		// Reference with Graph endpoints here: https://docs.microsoft.com/graph/deployments#microsoft-graph-and-graph-explorer-service-root-endpoints

		//Set the scope for API call to user.read
		string[] scopes = new string[] { "user.read" };
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.Body = new System.Windows.Forms.Label();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBcc = new System.Windows.Forms.TextBox();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(267, 71);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(494, 31);
            this.txtTo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(267, 135);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(494, 31);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.Text = "Test Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subject";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(267, 324);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(494, 145);
            this.txtBody.TabIndex = 4;
            this.txtBody.Text = "This is a test email";
            // 
            // Body
            // 
            this.Body.AutoSize = true;
            this.Body.Location = new System.Drawing.Point(94, 324);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(61, 25);
            this.Body.TabIndex = 5;
            this.Body.Text = "Body";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(601, 698);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(160, 45);
            this.btnSendMail.TabIndex = 6;
            this.btnSendMail.Text = "Send Email";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.SendMail_ClickAsync);
            // 
            // txtCopy
            // 
            this.txtCopy.Location = new System.Drawing.Point(267, 194);
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(494, 31);
            this.txtCopy.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "CC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "BCC";
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(267, 263);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(494, 31);
            this.txtBcc.TabIndex = 10;
            // 
            // txtAttachment
            // 
            this.txtAttachment.Location = new System.Drawing.Point(267, 522);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(344, 31);
            this.txtAttachment.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 528);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Attachments";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(656, 522);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(105, 38);
            this.btnChooseFile.TabIndex = 13;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.ChooseFile_ClickAsync);
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 786);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.txtBcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCopy);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTo);
            this.Name = "frmSendMail";
            this.Text = "Send Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtTo;
		public System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtBody;
		public System.Windows.Forms.Label Body;
		public System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBcc;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChooseFile;
    }
}

