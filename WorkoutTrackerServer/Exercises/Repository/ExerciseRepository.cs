using Microsoft.EntityFrameworkCore;
using WorkoutTrackerServer.Exercises.Dto;
using WorkoutTrackerServer.Pagination;
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

    public async Task<Page<ExerciseDto>> getPage(int pageNumber, int pageSize)
    {
        var items = _databaseContext.Exercises
            .Select(exercise => new ExerciseDto()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                
            })   
            .Skip(pageSize * pageNumber)
            .Take(pageSize)
            .ToListAsync();
        
        var itemCount = _databaseContext.Exercises.Count();


        return new Page<ExerciseDto>()
        {
            Content = await items
        };
    }
}