using System.Diagnostics;
using System.Windows.Forms;

namespace SmtpDebugTool
{
    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _output;

        public TextBoxTraceListener(TextBox output)
        {
            _output = output;
        }

        public override void Write(string message)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new MethodInvoker(() => _output.AppendText(message)));
            }
            else
            {
                _output.AppendText(message);
            }
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }
    }
}
