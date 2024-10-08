using GymCraftAPI.Application.DTOs.Exercise;
using GymCraftAPI.Application.Services.Interfaces;
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
            IEnumerable<ExerciseDTO> exercises = await _exerciseService.GetAllAsync();
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
            ExerciseDTO? exercise = await _exerciseService.GetByIdAsync(exerciseUuid);
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
    public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exercise)
    {
        try
        {
            ExerciseDTO createdExercise = await _exerciseService.CreateAsync(exercise);
            return CreatedAtAction(nameof(GetExerciseById), new { exerciseUuid = createdExercise.Uuid }, createdExercise);
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

    [HttpPut("{exerciseUuid}")]
    public async Task<IActionResult> UpdateExercise(Guid exerciseUuid, [FromBody] UpdateExerciseDTO exercise)
    {
        try
        {
            ExerciseDTO updatedExercise = await _exerciseService.UpdateAsync(exerciseUuid, exercise);
            return Ok(updatedExercise);
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

    [HttpDelete("{exerciseUuid}")]
    public async Task<IActionResult> SoftDeleteExercise(Guid exerciseUuid)
    {
        try
        {
            await _exerciseService.SoftDeleteAsync(exerciseUuid);
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
