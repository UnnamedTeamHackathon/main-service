namespace MainService.Services.Exceptions;

public class ModuleNotFoundException(Guid id) : NotFoundException($"Модуль с id {id} не найден.");