using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Controller;

/// <summary>
/// Operations for interacting with workouts
/// </summary>
[ApiController]
[Route("/workouts")]
public class WorkoutController
{
    /// <summary>
    /// Creates a new workout
    /// </summary>
    /// <param name="body"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void CreateWorkout([FromBody] CreateWorkoutRequestDto body)
    {
        
    }
}