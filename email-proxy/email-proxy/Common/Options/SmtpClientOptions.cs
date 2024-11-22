namespace email_proxy.Common.Options;

public class SmtpClientOptions
{
    public const string Key = "SmtpClient";
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }
}