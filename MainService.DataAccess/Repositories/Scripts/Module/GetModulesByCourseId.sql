select id        as Id,
       course_id as CourseId,
       name      as Name,
       "order"   as "Order"
from modules
where course_id = @courseId
order by "order";