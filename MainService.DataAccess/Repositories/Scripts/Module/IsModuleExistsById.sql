select exists(select id
              from modules
              where id = @id);