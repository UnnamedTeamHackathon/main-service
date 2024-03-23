namespace MainService.Services.Exceptions;

public class UserNotFoundException(Guid id) : NotFoundException($"Пользователь с id {id} не найден.");