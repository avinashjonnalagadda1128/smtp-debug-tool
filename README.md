# SMTP Debug Tool

A simple Windows desktop tool to help debug SMTP issues using the built-in `System.Net.Mail.SmtpClient` class in .NET.

This tool allows you to:

- Manually test SMTP connections
- Send test emails
- View error messages and connection issues
- Validate SMTP credentials and server configuration

---

## 🚀 Features

- Easy-to-use GUI interface
- Supports custom SMTP servers, ports, and authentication
- View raw SMTP responses and error messages
- Built with .NET 6 and WinForms

---

## 📥 Download

You can download the latest `.exe` from the [Releases page](https://github.com/avinashjonnalagadda1128/smtp-debug-tool/releases/latest).

1. Download the `.exe` file
2. Double-click to run (no install required)
3. Fill in the fields and test your SMTP server!

---

## 🛠 Usage

1. Enter your SMTP server (e.g., `smtp.office365.com`)
2. Specify the port (`587` for TLS, `25` for standard)
3. Provide sender and recipient email
4. Write a subject and message
5. Click **Send Email**
6. Output will appear in the log panel at the bottom

---

## 📦 Build from Source

To build this project locally:

```bash
git clone https://github.com/avinashjonnalagadda1128/smtp-debug-tool.git
cd smtp-debug-tool
dotnet publish -c Release -r win-x64 --self-contained true

Notes
Email passwords are not stored

Tool uses secure authentication (STARTTLS/SMTP-AUTH)

.exe is unsigned — may trigger a SmartScreen warning

built by avinash(avinashjonnalagadda1128)
