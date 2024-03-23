namespace MainService.Services.Exceptions;

public class CourseNotFoundException(Guid id) : NotFoundException($"Курс с id {id} не найден.");