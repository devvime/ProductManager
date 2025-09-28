using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService loginService = loginService;

        [HttpPost]
        public ActionResult<Login> Login(Login request)
        {
            var result = loginService.Execute(request);

            if (result)
            {
                return Ok();
            }

            return Unauthorized();
        }
    }
}