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
            .OrderBy(exercise => exercise.Name)
            .Skip(pageSize * pageNumber)
            .Take(pageSize)
            .ToListAsync();
        
        var itemCount = _databaseContext.Exercises.CountAsync();


        return new Page<ExerciseDto>()
        {
            Content = await items,
            TotalItems = await itemCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public Task<ExerciseDto> getExerciseById(long id)
    {
        return _databaseContext.Exercises
            .Select(exercise => new ExerciseDto()
            {
                Id = exercise.Id,
                Name = exercise.Name,

            })
            .Where(exercise => exercise.Id == id)
            .FirstAsync();
    }

    public async Task<long> addExercise(Exercise exercise)
    { 
        _databaseContext.Exercises.Add(exercise);
        
        await _databaseContext.SaveChangesAsync();
        
        return exercise.Id;
    }
}