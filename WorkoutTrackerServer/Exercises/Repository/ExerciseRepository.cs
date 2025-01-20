using WorkoutTrackerServer.Persistence;

namespace WorkoutTrackerServer.Exercises.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="databaseContext">Database context.</param>
    public ExerciseRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
}