using EnvioEmails.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnvioEmails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailservice;

        public EmailController(EmailService emailservice)
        {
            _emailservice = emailservice;
        }

        [HttpPost(Name = "EnviarEmail")]
        public async Task<IActionResult> EnviarEmail(string nomeRemetente, string emailRemetente, string nomeDestinario, string emailDestinario, string mensagem)
        {
            try
            {
                await _emailservice.EnviarEmail(nomeRemetente, emailRemetente, nomeDestinario, emailDestinario, mensagem);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}