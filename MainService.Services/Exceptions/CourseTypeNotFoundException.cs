namespace MainService.Services.Exceptions;

public class CourseTypeNotFoundException(Guid id) : NotFoundException($"Тип курса с id {id} не найден.");