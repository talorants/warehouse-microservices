using Microsoft.AspNetCore.Mvc;
using Talorants.Api.User.Dtos;
using Talorants.Api.User.Services;
using Talorants.Shared.Models;


namespace Talorants.Api.User.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(UserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Dtos.CreateUser))]
    // // [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    // // [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
    // public async Task<IActionResult> PostUser(CreateUser dtos)
    // {
    //     try
    //     {
    //         if(!ModelState.IsValid)
    //             return BadRequest(dtos);
            
    //         var createUserResult = await _userService.CreateAsync(dtos.Name, dtos.Login, dtos.Password, dtos.PhoneNumber, dtos.UserGroup, dtos.Warehouses);
    //         if(!createUserResult.IsSuccess)
    //             return BadRequest( new {ErrorMessage = createUserResult.ErrorMessage});
            
    //         return CreatedAtAction(nameof(GetUser), new {Id = createUserResult.Data?.Id }, ToDto(createUserResult.Data));
    //     }
    //     catch(Exception e)
    //     {

    //     }
    // }

    // private Dtos.User ToDto(Model.User? model)
    //     => new()
    //     {
             

    //     }
}