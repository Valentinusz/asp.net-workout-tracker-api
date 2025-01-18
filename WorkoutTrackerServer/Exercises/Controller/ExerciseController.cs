using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerServer.Exercises.Dto;

namespace WorkoutTrackerServer.Exercises.Controller;

[ApiController]
[Route("exercises")]
public class ExerciseController : ControllerBase
{

    [HttpGet]
    public Task<IEnumerable<ExerciseDto>> GetExercisePage()
    {
        return null;
    }

    [HttpGet]
    [Route("{exerciseId}")]
    public Task<ExerciseDto> GetExerciseById([FromRoute] long exerciseId)
    {
        return null;
    }
}