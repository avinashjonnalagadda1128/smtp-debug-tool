using System;
using System.Text;
using System.Windows.Forms;
using MailKit;

public class TextBoxProtocolLogger : IProtocolLogger
{
    private readonly TextBox _textBox;

    public TextBoxProtocolLogger(TextBox textBox)
    {
        _textBox = textBox;
    }

    public void LogConnect(Uri uri)
    {
        AppendLine($"🌐 Connecting to {uri}");
    }

    public void LogClient(byte[] buffer, int offset, int count)
    {
        var message = Encoding.UTF8.GetString(buffer, offset, count);
        AppendLine("C: " + message);
    }

    public void LogServer(byte[] buffer, int offset, int count)
    {
        var message = Encoding.UTF8.GetString(buffer, offset, count);
        AppendLine("S: " + message);
    }

    public void Dispose()
    {
        // No resources to dispose
    }

    private void AppendLine(string message)
    {
        if (_textBox.InvokeRequired)
        {
            _textBox.Invoke(new Action(() => _textBox.AppendText(message + Environment.NewLine)));
        }
        else
        {
            _textBox.AppendText(message + Environment.NewLine);
        }
    }

    // Required by IProtocolLogger (used to mask secrets, optional to implement logic)
    public IAuthenticationSecretDetector AuthenticationSecretDetector { get; set; }
}
