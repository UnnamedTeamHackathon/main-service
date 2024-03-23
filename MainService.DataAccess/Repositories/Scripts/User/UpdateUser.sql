update users
set email      = coalesce(@Email, email),
    username   = coalesce(@Username, username),
    name       = coalesce(@Name, name),
    surname    = coalesce(@Surname, surname),
    patronymic = coalesce(@Patronymic, patronymic),
    birthday   = coalesce(@Birthday, birthday),
    photo_id   = coalesce(@PhotoId, photo_id),
    country    = coalesce(@Country, country)
where id = @Id;