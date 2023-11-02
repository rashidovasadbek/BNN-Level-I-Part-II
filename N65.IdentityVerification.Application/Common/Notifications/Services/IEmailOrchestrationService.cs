namespace N65.IdentityVerification.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}
