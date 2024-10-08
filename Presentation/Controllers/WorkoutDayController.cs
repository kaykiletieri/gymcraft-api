using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class WorkoutDayController : ControllerBase
{
    private readonly IWorkoutDayService _workoutDayService;

    public WorkoutDayController(IWorkoutDayService workoutDayService)
    {
        _workoutDayService = workoutDayService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkoutDays()
    {
        try
        {
            IEnumerable<WorkoutDay> workoutDays = await _workoutDayService.GetAllAsync();
            return Ok(workoutDays);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{workoutDayUuid}")]
    public async Task<IActionResult> GetWorkoutDayById(Guid workoutDayUuid)
    {
        try
        {
            WorkoutDay? workoutDay = await _workoutDayService.GetByIdAsync(workoutDayUuid);
            if (workoutDay == null)
            {
                return NotFound();
            }
            return Ok(workoutDay);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkoutDay([FromBody] WorkoutDay workoutDay)
    {
        try
        {
            WorkoutDay createdWorkoutDay = await _workoutDayService.CreateAsync(workoutDay);
            return CreatedAtAction(nameof(GetWorkoutDayById), new { workoutDayUuid = createdWorkoutDay.Uuid }, createdWorkoutDay);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWorkoutDay([FromBody] WorkoutDay workoutDay)
    {
        try
        {
            WorkoutDay updatedWorkoutDay = await _workoutDayService.UpdateAsync(workoutDay);
            return Ok(updatedWorkoutDay);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{workoutDayUuid}")]
    public async Task<IActionResult> SoftDeleteWorkoutDay(Guid workoutDayUuid)
    {
        try
        {
            await _workoutDayService.SoftDeleteAsync(workoutDayUuid);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
