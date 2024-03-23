select exists(select id
              from lessons
              where id = @id);