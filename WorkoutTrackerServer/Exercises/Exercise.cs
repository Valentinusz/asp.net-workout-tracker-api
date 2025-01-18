using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerServer.Exercises;

public class Exercise
{
    [Key]
    public long Id { get; set; }
    
    public string Name { get; set; }
}