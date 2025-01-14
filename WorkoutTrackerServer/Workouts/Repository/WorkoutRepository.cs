using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Persistence;

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
    /// Saves the workout to the database.
    /// </summary>
    /// <param name="workout"></param>
    public void Save(Workout workout)
    {
        _databaseContext.Workouts.Add(workout);
        
        _databaseContext.SaveChanges();
    }
}