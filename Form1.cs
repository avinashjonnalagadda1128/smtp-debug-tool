using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Windows.Forms;

namespace SmtpDebugTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            try
            {
                string smtpServer = txtSmtpServer.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string fromEmail = txtFrom.Text.Trim();
                string toEmail = txtTo.Text.Trim();
                string subject = txtSubject.Text.Trim();
                string body = txtBody.Text.Trim();
                bool useTls = chkEnableTls.Checked;

                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(fromEmail));
                message.To.Add(MailboxAddress.Parse(toEmail));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                // ✅ Use logger directly in constructor
                using (var logger = new TextBoxProtocolLogger(txtLog))
                using (var client = new SmtpClient(new TextBoxProtocolLogger(txtLog)))  // ✅ This is the only valid way to use ProtocolLogger
                {
                    client.Connect(smtpServer, port,
                        useTls ? SecureSocketOptions.StartTls : SecureSocketOptions.None);

                    client.Authenticate(username, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                txtLog.AppendText("\r\n✅ Email sent successfully using MailKit.\r\n");
            }
            catch (MailKit.Security.AuthenticationException ex)
{
    txtLog.AppendText($"\r\n❌ Authentication Error: {ex.Message}\r\n");
    txtLog.AppendText("Explanation: The server refused authentication. This could mean STARTTLS is required or your credentials are wrong.\r\n");
}
catch (MailKit.CommandException ex)
{
    txtLog.AppendText($"\r\n❌ Command Error: {ex.Message}\r\n");

    if (ex.Message.Contains("STARTTLS", StringComparison.OrdinalIgnoreCase))
    {
        txtLog.AppendText("Explanation: STARTTLS is required by the server, but it was not enabled.\r\n");
    }
    else
    {
        txtLog.AppendText("Explanation: SMTP server command rejected. Check the SMTP flow and protocol log.\r\n");
    }
}
catch (Exception ex)
{
    txtLog.AppendText($"\r\n❌ General Error: {ex.Message}\r\n");

    if (ex.Message.Contains("does not support authentication", StringComparison.OrdinalIgnoreCase))
    {
        txtLog.AppendText("Explanation: The server likely requires STARTTLS before authentication. Try enabling TLS.\r\n");
    }
    else if (ex.Message.Contains("STARTTLS", StringComparison.OrdinalIgnoreCase))
    {
        txtLog.AppendText("Explanation: The server requires STARTTLS to proceed. Please enable TLS.\r\n");
    }
    else
    {
        txtLog.AppendText("Explanation: An unexpected error occurred. Check your SMTP settings and log.\r\n");
    }
}


        }
    }
}
