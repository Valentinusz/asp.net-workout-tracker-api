using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerServer.Workouts.Dto;
using WorkoutTrackerServer.Workouts.Service;

namespace WorkoutTrackerServer.Workouts.Controller;

/// <summary>
/// Operations for interacting with workouts
/// </summary>
[ApiController]
[Route("/workouts")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="workoutService"></param>
    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpGet]
    [Route("{workoutId}", Name = "GetWorkout")]
    public async Task<ActionResult<WorkoutDto>> GetWorkout(long workoutId)
    {
        return Ok();
    }
    
    /// <summary>
    /// Creates a new workout
    /// </summary>
    /// <param name="body"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<CreateWorkoutResponseDto>> CreateWorkout([FromBody] CreateWorkoutRequestDto body)
    {
        var response = await _workoutService.CreateWorkout(body);
        
        return CreatedAtRoute("GetWorkout", new {workoutId = response.Id}, response);
    }
}