namespace MainService.Services.Exceptions;

public class LessonNotFoundException(Guid id) : NotFoundException($"Урок с id {id} не найден.");