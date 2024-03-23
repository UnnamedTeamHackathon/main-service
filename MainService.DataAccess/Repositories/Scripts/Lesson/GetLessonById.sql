select id        as Id,
       module_id as ModuleId,
       text      as Text,
       video_id  as VideoId,
       task_id   as TaskId,
       type      as Type,
       "order"   as "Order"
from lessons
where id = @id
order by "order";