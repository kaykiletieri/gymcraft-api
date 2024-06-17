using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
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
            var users = await _userService.GetAllAsync();
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
            var user = await _userService.GetByIdAsync(userUuid);
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
    {/*
        try
        {*/
        var createdUser = await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { userUuid = createdUser.Uuid }, createdUser);
        /*}
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }*/
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        try
        {
            var updatedUser = await _userService.UpdateAsync(user);
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