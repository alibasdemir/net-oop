using Business.Features.Auth.Commands.Login;
using Business.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;   // mediator'ü dependency injection yaptık

        public AuthController(IMediator mediator)   // constructor oluşturduk
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)   // kullanıcıdan body'den registercommand istiyor. Controller'ı tek bir kalıba bağlamıştık bu yüzden mediator'ı entegre edip komutları mediator yoluyla gönderiyoruz
        {
            await _mediator.Send(registerCommand);  // mediator yoluyla gönderiyoruz
            return Created();   // register olunca token döneriz ancak şuan token sistemini oluşturmadığımız için boş dönüyoruz
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            await _mediator.Send(loginCommand);
            return Ok();
        }
    }
}
