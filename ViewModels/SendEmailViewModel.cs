using System.ComponentModel.DataAnnotations;

namespace FinalBattle.ViewModels
{
    public class SendEmailViewModel
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        public string Receiver { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}
