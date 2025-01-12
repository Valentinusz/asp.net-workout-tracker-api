﻿namespace WorkoutTrackerServer.Workouts.Repository;

/// <summary>
/// Repository for <see cref="Workout">Workout</see>.
/// </summary>
public interface IWorkoutRepository
{
    /// <summary>
    /// Saves the given workout to the database
    /// </summary>
    /// <param name="workout">Workout entity to save</param>
    void Save(Workout workout);
}