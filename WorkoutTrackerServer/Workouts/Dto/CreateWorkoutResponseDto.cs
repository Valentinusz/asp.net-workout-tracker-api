using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerServer.Workouts.Dto;

public class CreateWorkoutResponseDto
{
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public long Id { get; set; }
}