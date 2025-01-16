using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Persistence;
using WorkoutTrackerServer.Workouts.Dto;

namespace WorkoutTrackerServer.Workouts.Repository;

/// <summary>
/// Repository for the workout entity.
/// </summary>
public class WorkoutRepository : IWorkoutRepository
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="databaseContext">Database context.</param>
    public WorkoutRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Returns all workouts for the given user.
    /// </summary>
    /// <returns></returns>
    public Task<List<WorkoutDto>> FindByUserId()
    {
        return _databaseContext.Workouts
            .Select(workout => new WorkoutDto
                {
                    Id = workout.Id
                })
            .ToListAsync();
    }
    
    /// <summary>
    /// Saves the workout to the database.
    /// </summary>
    /// <param name="workout"></param>
    public Task<int> Save(Workout workout)
    {
        _databaseContext.Workouts.Add(workout);
        
        return _databaseContext.SaveChangesAsync();
    }
}