select exists(select id
              from courses
              where id = @id);