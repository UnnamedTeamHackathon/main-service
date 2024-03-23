create table if not exists modules
(
    id        uuid primary key default gen_random_uuid(),
    course_id uuid references courses (id),
    name      text not null,
    "order"   int  not null
);

create index module_id_index on modules (id);