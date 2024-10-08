using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class WorkoutExerciseController : ControllerBase
{
    private readonly IWorkoutExerciseService _workoutExerciseService;

    public WorkoutExerciseController(IWorkoutExerciseService workoutExerciseService)
    {
        _workoutExerciseService = workoutExerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkoutExercises()
    {
        try
        {
            IEnumerable<WorkoutExercise> workoutExercises = await _workoutExerciseService.GetAllAsync();
            return Ok(workoutExercises);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{workoutExerciseUuid}")]
    public async Task<IActionResult> GetWorkoutExerciseById(Guid workoutExerciseUuid)
    {
        try
        {
            WorkoutExercise? workoutExercise = await _workoutExerciseService.GetByIdAsync(workoutExerciseUuid);
            if (workoutExercise == null)
            {
                return NotFound();
            }
            return Ok(workoutExercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkoutExercise([FromBody] WorkoutExercise workoutExercise)
    {
        try
        {
            WorkoutExercise createdWorkoutExercise = await _workoutExerciseService.CreateAsync(workoutExercise);
            return CreatedAtAction(nameof(GetWorkoutExerciseById), new { workoutExerciseUuid = createdWorkoutExercise.Uuid }, createdWorkoutExercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWorkoutExercise([FromBody] WorkoutExercise workoutExercise)
    {
        try
        {
            WorkoutExercise updatedWorkoutExercise = await _workoutExerciseService.UpdateAsync(workoutExercise);
            return Ok(updatedWorkoutExercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{workoutExerciseUuid}")]
    public async Task<IActionResult> DeleteWorkoutExercise(Guid workoutExerciseUuid)
    {
        try
        {
            await _workoutExerciseService.SoftDeleteAsync(workoutExerciseUuid);
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
