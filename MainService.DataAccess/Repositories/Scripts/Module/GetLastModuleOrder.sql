set transaction isolation level read uncommitted;

select "order"
from modules
where course_id = @courseId
order by "order" desc
limit 1;