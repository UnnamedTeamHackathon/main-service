insert into lessons (module_id, text, video_id, task_id, type, "order")
values (@ModuleId, @Text, @VideoId, @TaskId, @Type, @Order)
returning id;