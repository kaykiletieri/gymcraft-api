using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            IEnumerable<UserDTO> users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{userUuid}")]
    public async Task<IActionResult> GetUserById(Guid userUuid)
    {
        try
        {
            UserDTO? user = await _userService.GetByIdAsync(userUuid);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
    {
        try
        {
            UserDTO createdUser = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { userUuid = createdUser.Uuid }, createdUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{userUuid}")]
    public async Task<IActionResult> UpdateUser(Guid userUuid, [FromBody] UpdateUserDTO user)
    {
        try
        {
            UserDTO updatedUser = await _userService.UpdateAsync(userUuid, user);
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{userUuid}")]
    public async Task<IActionResult> SoftDeleteUser(Guid userUuid)
    {
        try
        {
            await _userService.SoftDeleteAsync(userUuid);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}