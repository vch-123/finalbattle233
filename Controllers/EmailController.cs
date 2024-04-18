using FinalBattle.Interfaces;
using FinalBattle.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalBattle.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(model.Sender, model.Receiver, model.Subject, model.Message, model.Attachments);
                return RedirectToAction("SendEmailSuccess");
            }

            return View(model);
        }

        public IActionResult SendEmailSuccess()
        {
            return View();
        }
    }
}
