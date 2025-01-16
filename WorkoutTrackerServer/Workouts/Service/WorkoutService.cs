using WorkoutTrackerServer.Workouts.Dto;
using WorkoutTrackerServer.Workouts.Repository;

namespace WorkoutTrackerServer.Workouts.Service;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

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

        return new CreateWorkoutResponseDto
        {
            Id = workout.Id,
        };
    }
}