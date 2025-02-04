using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WorkoutTrackerServer.Workouts.Dto;
using WorkoutTrackerServer.Workouts.Repository;

namespace WorkoutTrackerServer.Workouts.Service;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public Task<List<WorkoutDto>> GetWorkoutsAsync()
    {
        return _workoutRepository.FindByUserId();
    }
    
    public async Task<CreateWorkoutResponseDto> CreateWorkout(CreateWorkoutRequestDto createWorkoutRequest)
    {
        var workout = new Workout
        {
            StartTime = DateTime.Now
        };
        
        await _workoutRepository.Save(workout);

        ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;

        return new CreateWorkoutResponseDto
        {
            Id = workout.Id,
        };
    }
}