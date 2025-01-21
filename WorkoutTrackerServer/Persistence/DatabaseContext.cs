using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Exercises;
using WorkoutTrackerServer.Workouts;

namespace WorkoutTrackerServer.Persistence;

/// <summary>
/// Database context
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Workout entities
    /// </summary>
    public DbSet<Workout> Workouts { get; set; }
    
    public DbSet<Exercise> Exercises { get; set; }
}