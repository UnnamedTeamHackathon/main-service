select id                          as Id,
       role                        as Role,
       email                       as Email,
       username                    as Username,
       password_hash               as PasswordHash,
       refresh_token               as RefreshToken,
       refresh_token_expired_after as RefreshTokenExpiredAfter,
       name                        as Name,
       surname                     as Surname,
       patronymic                  as Patronymic,
       birthday                    as Birthday,
       photo_id                    as PhotoId,
       country                     as Country
from users
where id = @id;