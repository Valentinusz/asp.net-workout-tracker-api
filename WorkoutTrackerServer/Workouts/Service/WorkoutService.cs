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
    
    public void CreateWorkout(CreateWorkoutRequestDto workout)
    {
        _workoutRepository.Save(new Workout()
        {
            CreatedAt = DateTime.Now
        });
    }
}