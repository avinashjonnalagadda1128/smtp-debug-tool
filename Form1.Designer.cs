namespace SmtpDebugTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            int top = 10, left = 10, width = 400, height = 23, spacing = 28;

            this.txtSmtpServer.SetBounds(left, top, width, height); top += spacing;
            this.txtPort.SetBounds(left, top, width, height); top += spacing;
            this.txtUsername.SetBounds(left, top, width, height); top += spacing;
            this.txtPassword.SetBounds(left, top, width, height); top += spacing;
            this.txtFrom.SetBounds(left, top, width, height); top += spacing;
            this.txtTo.SetBounds(left, top, width, height); top += spacing;
            this.txtSubject.SetBounds(left, top, width, height); top += spacing;
            this.txtBody.SetBounds(left, top, width, 80); top += spacing + 60;
            this.btnSend.SetBounds(left, top, width, height); top += spacing;
            this.txtLog.SetBounds(left, top, width, 120);

            this.txtPassword.UseSystemPasswordChar = true;
            this.txtBody.Multiline = true;
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.txtSmtpServer.PlaceholderText = "SMTP Server (e.g., smtp.office365.com)";
            this.txtPort.PlaceholderText = "Port (e.g., 587)";
            this.txtUsername.PlaceholderText = "Username";
            this.txtPassword.PlaceholderText = "Password";
            this.txtFrom.PlaceholderText = "From Email";
            this.txtTo.PlaceholderText = "To Email";
            this.txtSubject.PlaceholderText = "Subject";
            this.txtBody.PlaceholderText = "Email Body";

            this.btnSend.Text = "Send Email";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtSmtpServer, txtPort, txtUsername, txtPassword,
                txtFrom, txtTo, txtSubject, txtBody, btnSend, txtLog
            });

            this.Text = "SMTP Debug Tool";
            this.ClientSize = new System.Drawing.Size(440, top + 130);
            this.ResumeLayout(false);
        }
    }
}
