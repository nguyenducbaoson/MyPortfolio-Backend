using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly string? _portfolioTemplate;

        public EmailController(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _portfolioTemplate = configuration["EmailSettings:PortfolioReplyTemplate"];
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(SendEmail request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Message))
                return Redirect("https://your-frontend-site.com/email-confirmation?status=invalid");

            string htmlMessage = string.Format(
                _portfolioTemplate ?? "Default email template content.",
                request.Name ?? "there",
                request.Message ?? "",   
                "Nguyen Duc Bao Son"      
            );            
            await _emailSender.SendEmailAsync(request.Email, request.Message, htmlMessage);
            return Ok();
        }
    }
}
