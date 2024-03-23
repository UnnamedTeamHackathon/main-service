using MainService.DataAccess.Models;
using MainService.Models.Lesson;

namespace MainService.Services.Mappers;

public static class LessonMapper
{
    public static Lesson MapToDomain(this DbLesson source)
    {
        return source == null
            ? default
            : new Lesson
            {
                Id = source.Id,
                ModuleId = source.ModuleId,
                Text = source.Text,
                VideoId = source.VideoId,
                TaskId = source.TaskId,
                Type = (LessonType)source.Type,
                Order = source.Order
            };
    }

    public static List<Lesson> MapToDomain(this List<DbLesson> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }

    public static DbLesson MapToDb(this Lesson source)
    {
        return source == null
            ? default
            : new DbLesson
            {
                Id = source.Id,
                ModuleId = source.ModuleId,
                Text = source.Text,
                VideoId = source.VideoId,
                TaskId = source.TaskId,
                Type = (int)source.Type,
                Order = source.Order
            };
    }
}