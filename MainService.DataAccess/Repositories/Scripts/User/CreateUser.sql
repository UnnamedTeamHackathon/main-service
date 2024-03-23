insert into users (role, email, username, password_hash, refresh_token, refresh_token_expired_after, name, surname, patronymic, birthday, photo_id, country)
values (@Role, @Email, @Username, @PasswordHash, @RefreshToken, @RefreshTokenExpiredAfter, @Name, @Surname, @Patronymic, @Birthday, @PhotoId, @Country)
returning id;