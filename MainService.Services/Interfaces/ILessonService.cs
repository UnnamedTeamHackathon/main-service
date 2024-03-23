using MainService.Models.Lesson;

namespace MainService.Services.Interfaces;

public interface ILessonService
{
    Task<Guid> CreateLesson(CreateLessonRequest request);
    Task<Lesson> GetLesson(Guid id);
    Task<List<Lesson>> GetLessonsByModule(Guid moduleId);
    Task UpdateLesson(Guid id, UpdateLessonRequest request);
    Task DeleteLesson(Guid id);
}