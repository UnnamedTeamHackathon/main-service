set transaction isolation level read uncommitted;

select "order"
from lessons
where module_id = @moduleId
order by "order" desc
limit 1;