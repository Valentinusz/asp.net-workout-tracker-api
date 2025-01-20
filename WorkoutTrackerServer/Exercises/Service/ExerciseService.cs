using WorkoutTrackerServer.Exercises.Dto;
using WorkoutTrackerServer.Pagination;

namespace WorkoutTrackerServer.Exercises.Service;

public class ExerciseService : IExerciseService
{
    public Task<Page<ExerciseDto>> GetExercises(uint page, uint pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ExerciseDto> GetExercise(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CreateExerciseResponseDto> CreateExercise(CreateExerciseRequestDto createExerciseRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<ExerciseDto> UpdateExercise(long id, UpdateExerciseRequestDto updateExerciseRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteExercise(long id)
    {
        throw new NotImplementedException();
    }
}