using WorkoutTrackerServer.Exercises.Dto;
using WorkoutTrackerServer.Pagination;

namespace WorkoutTrackerServer.Exercises.Service;

public interface IExerciseService
{
    Task<Page<ExerciseDto>> GetExercises(uint page, uint pageSize);
    Task<ExerciseDto> GetExercise(long id);
    Task<CreateExerciseResponseDto> CreateExercise(CreateExerciseRequestDto createExerciseRequestDto);
    Task<ExerciseDto> UpdateExercise(long id, UpdateExerciseRequestDto updateExerciseRequestDto);
    Task DeleteExercise(long id);
}