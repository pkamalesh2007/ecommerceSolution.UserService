using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, [FromServices] IValidator<RegisterRequest> validator)
    {
        if (request == null)
        {
            return BadRequest("Invalid registeration details");
        }

        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(errors);
        }
        AuthenticationResponse? response = await _userService.Register(request);

        if (response == null || response.Success == false)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, [FromServices] IValidator<LoginRequest> validator)
    {       

        if (request == null) {
            return BadRequest("Invalid login details");
        }

        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) {
            var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(errors);        
        }



        AuthenticationResponse? response = await _userService.Login(request);

        if (response == null || response.Success == false)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}