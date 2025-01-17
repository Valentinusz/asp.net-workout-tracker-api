using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Service;

public interface IUserWorkoutService
{
    Task<IEnumerable<WorkoutDto>> GetWorkoutsOfUser(long userId);
}