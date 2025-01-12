using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Workouts;

namespace WorkoutTrackerServer.Persistence;

/// <summary>
/// Database context
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Workout entities
    /// </summary>
    public DbSet<Workout> Workouts { get; set; }
}