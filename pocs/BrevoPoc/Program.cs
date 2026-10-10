// Para executar este código, você precisa definir as variáveis de ambiente BREVO_SMTP_USER e BREVO_SMTP_KEY com suas credenciais do Brevo SMTP.
// https://app.brevo.com/settings/keys/smtp

// No Windows PowerShell, você pode definir as variáveis de ambiente da seguinte forma:
// $env:BREVO_SMTP_USER="bbf83b001@smtp-brevo.com"
// $env:BREVO_SMTP_KEY="your_api_key_here"
// dotnet run

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

var host = "smtp-relay.brevo.com";
var port = 587;
var user = Environment.GetEnvironmentVariable("BREVO_SMTP_USER")!;
var key  = Environment.GetEnvironmentVariable("BREVO_SMTP_KEY")!;

var message = new MimeMessage();
message.From.Add(new MailboxAddress("POC Pós", "betojunior1250@gmail.com"));
message.To.Add(MailboxAddress.Parse("betojunior1250@hotmail.com"));
message.Subject = "POC Brevo - Pós-graduação";
message.Body = new BodyBuilder
{
    HtmlBody = "<h1>Funcionou!</h1><p>E-mail enviado via Brevo com .NET e MailKit.</p>",
    TextBody = "Funcionou! E-mail enviado via Brevo com .NET e MailKit."
}.ToMessageBody();

try
{
    using var client = new SmtpClient();
    await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
    await client.AuthenticateAsync(user, key);
    var response = await client.SendAsync(message);
    await client.DisconnectAsync(true);
    Console.WriteLine($"Enviado! Resposta do servidor: {response}");
}
catch (Exception ex)
{
    Console.WriteLine($"Falha no envio: {ex.Message}");
}