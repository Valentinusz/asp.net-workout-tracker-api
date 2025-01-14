using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Service;

public interface IWorkoutService
{
    public void CreateWorkout(CreateWorkoutRequestDto workout);
}