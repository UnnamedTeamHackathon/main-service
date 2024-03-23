namespace MainService.Services.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);