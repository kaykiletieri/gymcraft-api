using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymCraftAPI.Presentation.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ExerciseCategoryController : ControllerBase
{
    private readonly IExerciseCategoryService _exerciseCategoryService;

    public ExerciseCategoryController(IExerciseCategoryService exerciseCategoryService)
    {
        _exerciseCategoryService = exerciseCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExerciseCategories()
    {
        try
        {
            var exerciseCategories = await _exerciseCategoryService.GetAllAsync();
            return Ok(exerciseCategories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{exerciseCategoryUuid}")]
    public async Task<IActionResult> GetExerciseCategoryById(Guid exerciseCategoryUuid)
    {
        try
        {
            var exerciseCategory = await _exerciseCategoryService.GetByIdAsync(exerciseCategoryUuid);
            if (exerciseCategory == null)
            {
                return NotFound();
            }
            return Ok(exerciseCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateExerciseCategory([FromBody] ExerciseCategory exerciseCategory)
    {
        try
        {
            var createdExerciseCategory = await _exerciseCategoryService.CreateAsync(exerciseCategory);
            return CreatedAtAction(nameof(GetExerciseCategoryById), new { exerciseCategoryUuid = createdExerciseCategory.Uuid }, createdExerciseCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExerciseCategory([FromBody] ExerciseCategory exerciseCategory)
    {
        try
        {
            var updatedExerciseCategory = await _exerciseCategoryService.UpdateAsync(exerciseCategory);
            return Ok(updatedExerciseCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{exerciseCategoryUuid}")]
    public async Task<IActionResult> SoftDeleteExerciseCategory(Guid exerciseCategoryUuid)
    {
        try
        {
            await _exerciseCategoryService.SoftDeleteAsync(exerciseCategoryUuid);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
