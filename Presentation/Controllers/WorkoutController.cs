using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkouts()
    {
        try
        {
            IEnumerable<Workout> workouts = await _workoutService.GetAllAsync();
            return Ok(workouts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{workoutUuid}")]
    public async Task<IActionResult> GetWorkoutById(Guid workoutUuid)
    {
        try
        {
            Workout? workout = await _workoutService.GetByIdAsync(workoutUuid);
            if (workout == null)
            {
                return NotFound();
            }
            return Ok(workout);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkout([FromBody] Workout workout)
    {
        try
        {
            Workout createdWorkout = await _workoutService.CreateAsync(workout);
            return CreatedAtAction(nameof(GetWorkoutById), new { workoutUuid = createdWorkout.Uuid }, createdWorkout);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWorkout([FromBody] Workout workout)
    {
        try
        {
            Workout updatedWorkout = await _workoutService.UpdateAsync(workout);
            return Ok(updatedWorkout);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{workoutUuid}")]
    public async Task<IActionResult> DeleteWorkout(Guid workoutUuid)
    {
        try
        {
            await _workoutService.SoftDeleteAsync(workoutUuid);
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
