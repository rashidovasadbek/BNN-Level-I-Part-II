namespace N65.IdentityVerification.Application.Common.Settings;

public class EmailSenderSettings
{
    public string Host {  get; set; } = string.Empty;

    public int Port { get; set; }

    public string CredentialAddress { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string TestValue {  get; set; } = string.Empty;
}
