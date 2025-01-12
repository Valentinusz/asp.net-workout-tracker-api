using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerServer.Workouts;

/// <summary>
/// Entity representing a workout
/// </summary>
public class Workout
{
    /// <summary>
    /// ID of the workout
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}