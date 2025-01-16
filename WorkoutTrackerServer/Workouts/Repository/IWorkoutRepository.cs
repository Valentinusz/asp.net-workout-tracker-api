using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Repository;

/// <summary>
/// Repository for <see cref="Workout">Workout</see>.
/// </summary>
public interface IWorkoutRepository
{
    public Task<List<WorkoutDto>> FindByUserId();
    
    /// <summary>
    /// Saves the given workout to the database
    /// </summary>
    /// <param name="workout">Workout entity to save</param>
    public Task<int> Save(Workout workout);
}