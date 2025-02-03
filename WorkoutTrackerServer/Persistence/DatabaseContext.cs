using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Exercises;
using WorkoutTrackerServer.Workouts;

namespace WorkoutTrackerServer.Persistence;

/// <summary>
/// Database context
/// </summary>
public class DatabaseContext : IdentityDbContext<IdentityUser>
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