update lessons
set module_id = coalesce(@ModuleId, module_id),
    text      = coalesce(@Text, text),
    video_id  = coalesce(@VideoId, video_id),
    task_id   = coalesce(@TaskId, task_id),
    type      = coalesce(@Type, type)
where id = @Id;