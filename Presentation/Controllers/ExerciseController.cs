using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExercises()
    {
        try
        {
            var exercises = await _exerciseService.GetAllAsync();
            return Ok(exercises);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{exerciseUuid}")]
    public async Task<IActionResult> GetExerciseById(Guid exerciseUuid)
    {
        try
        {
            var exercise = await _exerciseService.GetByIdAsync(exerciseUuid);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] Exercise exercise)
    {
        try
        {
            var createdExercise = await _exerciseService.CreateAsync(exercise);
            return CreatedAtAction(nameof(GetExerciseById), new { exerciseUuid = createdExercise.Uuid }, createdExercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExercise([FromBody] Exercise exercise)
    {
        try
        {
            var updatedExercise = await _exerciseService.UpdateAsync(exercise);
            return Ok(updatedExercise);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> SoftDeleteExercise(Guid exerciseUuid)
    {
        try
        {
            await _exerciseService.SoftDeleteAsync(exerciseUuid);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
