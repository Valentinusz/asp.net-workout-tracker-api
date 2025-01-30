using WorkoutTrackerServer.Exercises.Dto;
using WorkoutTrackerServer.Pagination;

namespace WorkoutTrackerServer.Exercises.Repository;

public interface IExerciseRepository
{
    Task<Page<ExerciseDto>> getPage(int pageNumber, int pageSize);
    Task<ExerciseDto> getExerciseById(long id);
    Task<long> addExercise(Exercise exercise);
}