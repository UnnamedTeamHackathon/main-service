create table if not exists lessons
(
    id        uuid primary key default gen_random_uuid(),
    module_id uuid references modules (id),
    text      text,
    video_id  uuid,
    task_id   uuid,
    type      int not null     default 0,
    "order"   int not null
);

create index lesson_id_index on lessons (id);