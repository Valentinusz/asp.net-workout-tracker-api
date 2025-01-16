using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Service;

public interface IWorkoutService
{
    public Task<List<WorkoutDto>> GetWorkoutsAsync();
    
    public Task<CreateWorkoutResponseDto> CreateWorkout(CreateWorkoutRequestDto createWorkoutRequest);
}