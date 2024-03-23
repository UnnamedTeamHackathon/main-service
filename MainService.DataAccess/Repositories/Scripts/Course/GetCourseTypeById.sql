select id   as Id,
       name as Name
from course_types
where id = @id;