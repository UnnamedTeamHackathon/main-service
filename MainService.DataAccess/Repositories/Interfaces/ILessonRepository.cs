using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Models;
using MainService.Models.Lesson;

namespace MainService.DataAccess.Repositories.Interfaces;

public interface ILessonRepository
{
    ITransaction BeginTransaction();
    Task<bool> IsLessonExistsById(Guid id);
    Task<Guid> CreateLesson(CreateLessonRequest request, ITransaction transaction = null);
    Task<DbLesson> GetLesson(Guid id);
    Task<List<DbLesson>> GetLessonsByModule(Guid moduleId);
    Task UpdateLesson(UpdateLessonRequest request, ITransaction transaction = null);
    Task DeleteLesson(Guid id, ITransaction transaction = null);
    Task<int> GetLastLessonOrder(Guid moduleId);
    Task ReorderLessons(Guid id, Guid moduleId, int order, int newOrder, ITransaction transaction = null);
}