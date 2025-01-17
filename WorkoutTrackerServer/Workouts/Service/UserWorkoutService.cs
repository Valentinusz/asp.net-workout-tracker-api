using WorkoutTrackerServer.Workouts.Dto;
using WorkoutTrackerServer.Workouts.Repository;

namespace WorkoutTrackerServer.Workouts.Service;

public class UserWorkoutService : IUserWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    public async Task<IEnumerable<WorkoutDto>> GetWorkoutsOfUser(long userId)
    {
        return await _workoutRepository.FindByUserId();
    }
}