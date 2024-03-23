using MainService.DataAccess.Repositories.Interfaces;
using MainService.Models.Lesson;
using MainService.Services.Exceptions;
using MainService.Services.Interfaces;
using MainService.Services.Mappers;

namespace MainService.Services;

public class LessonService(ILessonRepository lessonRepository, IModuleRepository moduleRepository) : ILessonService
{
    public async Task<Guid> CreateLesson(CreateLessonRequest request)
    {
        if (!await moduleRepository.IsModuleExistsById(request.ModuleId))
        {
            throw new ModuleNotFoundException(request.ModuleId);
        }

        var lastOrder = await lessonRepository.GetLastLessonOrder(request.ModuleId);
        request.Order = lastOrder + 1;

        return await lessonRepository.CreateLesson(request);
    }

    public async Task<Lesson> GetLesson(Guid id)
    {
        var lesson = await lessonRepository.GetLesson(id);
        if (lesson == null)
        {
            throw new LessonNotFoundException(id);
        }

        return lesson.MapToDomain();
    }

    public async Task<List<Lesson>> GetLessonsByModule(Guid moduleId)
    {
        var lessons = await lessonRepository.GetLessonsByModule(moduleId);

        return lessons.MapToDomain();
    }

    public async Task UpdateLesson(Guid id, UpdateLessonRequest request)
    {
        var lesson = await lessonRepository.GetLesson(id);
        if (lesson == null)
        {
            throw new LessonNotFoundException(id);
        }

        using var transaction = lessonRepository.BeginTransaction();
        try
        {
            request.Id = id;
            await lessonRepository.UpdateLesson(request, transaction);

            if (request.Order.HasValue)
            {
                await lessonRepository.ReorderLessons(id, lesson.ModuleId, lesson.Order, request.Order.Value, transaction);
            }
            
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task DeleteLesson(Guid id)
    {
        var lesson = await lessonRepository.GetLesson(id);
        if (lesson == null)
        {
            throw new LessonNotFoundException(id);
        }

        using var transaction = lessonRepository.BeginTransaction();
        try
        {
            var lastOrder = await lessonRepository.GetLastLessonOrder(lesson.ModuleId);
            await lessonRepository.ReorderLessons(id, lesson.ModuleId, lesson.Order, lastOrder + 1, transaction);
            await lessonRepository.DeleteLesson(id, transaction);
            
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}