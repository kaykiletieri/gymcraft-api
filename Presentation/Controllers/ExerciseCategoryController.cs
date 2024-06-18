using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Services.Interfaces;
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
            IEnumerable<ExerciseCategoryDTO> exerciseCategories = await _exerciseCategoryService.GetAllAsync();
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
            ExerciseCategoryDTO? exerciseCategory = await _exerciseCategoryService.GetByIdAsync(exerciseCategoryUuid);
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
    public async Task<IActionResult> CreateExerciseCategory([FromBody] CreateExerciseCategoryDTO exerciseCategory)
    {
        try
        {
            ExerciseCategoryDTO createdExerciseCategory = await _exerciseCategoryService.CreateAsync(exerciseCategory);
            return CreatedAtAction(nameof(GetExerciseCategoryById), new { exerciseCategoryUuid = createdExerciseCategory.Uuid }, createdExerciseCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{exerciseCategoryUuid}")]
    public async Task<IActionResult> UpdateExerciseCategory(Guid exerciseCategoryUuid, [FromBody] UpdateExerciseCategoryDTO exerciseCategory)
    {
        try
        {
            ExerciseCategoryDTO updatedExerciseCategory = await _exerciseCategoryService.UpdateAsync(exerciseCategoryUuid, exerciseCategory);
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
