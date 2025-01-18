using System.ComponentModel.DataAnnotations;
using WorkoutTrackerServer.Exercises;
using WorkoutTrackerServer.Workouts;

namespace WorkoutTrackerServer.WorkoutSets;

public class WorkoutSet
{
    [Key]
    public int Id { get; set; }
    
    public Workout Workout { get; set; }
    
    public Exercise Exercise { get; set; }
}