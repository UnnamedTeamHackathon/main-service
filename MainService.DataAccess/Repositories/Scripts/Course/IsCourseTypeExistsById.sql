select exists(select id
              from course_types
              where id = @id);