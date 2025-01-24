using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerServer.Exercises.Dto;
using WorkoutTrackerServer.Exercises.Service;
using WorkoutTrackerServer.Pagination;

namespace WorkoutTrackerServer.Exercises.Controller;

[ApiController]
[Route("exercises")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
    
    /// <summary>
    /// Get a page of exercises.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<Page<ExerciseDto>> GetExercises([FromQuery] int page, [FromQuery] int pageSize)
    {
        return _exerciseService.GetExercises(page, pageSize);
    }

    [HttpGet]
    [Route("{exerciseId:long}", Name = "GetExercise")]
    public Task<ExerciseDto> GetExerciseById([FromRoute] long exerciseId)
    {
        return _exerciseService.GetExercise(exerciseId);
    }

    [HttpPost]
    public async Task<ActionResult<CreateExerciseResponseDto>> CreateExercise(
        [FromBody] CreateExerciseRequestDto body)
    {
        Console.WriteLine(body);
        
        var response = await _exerciseService.CreateExercise(body);
        
        return CreatedAtRoute("GetExercise", new {workoutId = response.Id}, response);
    }

    [HttpPut]
    [Route("{exerciseId:long}")]
    public Task<ExerciseDto> UpdateExercise([FromRoute] long exerciseId, [FromBody] UpdateExerciseRequestDto updateExerciseRequestDto)
    {
        return _exerciseService.UpdateExercise(exerciseId, updateExerciseRequestDto);
    }
    
    [HttpDelete]
    [Route("{exerciseId:long}")]
    public IActionResult DeleteExercise([FromRoute] long exerciseId)
    {
        _exerciseService.DeleteExercise(exerciseId); 
        
        return NoContent();
    }
}