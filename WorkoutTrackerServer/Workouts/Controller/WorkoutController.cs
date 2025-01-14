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
    
    /// <summary>
    /// Creates a new workout
    /// </summary>
    /// <param name="body"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateWorkout([FromBody] CreateWorkoutRequestDto body)
    {
        _workoutService.CreateWorkout(body);
        
        return Created();
    }
}