namespace FinalBattle.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string sender, string receiver, string subject, string message, List<IFormFile> attachments);
    }
}
