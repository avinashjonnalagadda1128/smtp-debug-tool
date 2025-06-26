using System;
using System.Net;
using System.Net.Mail;
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

                SmtpClient client = new SmtpClient(smtpServer, port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(username, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 10000 // 10 seconds
                };

                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                client.Send(mail);

                txtLog.AppendText("✅ Email sent successfully.\r\n");
            }
            catch (SmtpException ex)
            {
                txtLog.AppendText($"❌ SMTP Error: {ex.StatusCode}\r\n");
                txtLog.AppendText($"Message: {ex.Message}\r\n");

                // Optional: Add detailed meaning for common SMTP error codes
                if (ex.StatusCode == SmtpStatusCode.MailboxUnavailable)
                {
                    txtLog.AppendText("Explanation: Mailbox unavailable (wrong recipient address?)\r\n");
                }
                else if (ex.StatusCode == SmtpStatusCode.GeneralFailure)
                {
                    txtLog.AppendText("Explanation: Could not connect to server (check server, port, or internet)\r\n");
                }
            }
            catch (Exception ex)
            {
                txtLog.AppendText($"❌ General Error: {ex.Message}\r\n");
            }
        }
    }
}
