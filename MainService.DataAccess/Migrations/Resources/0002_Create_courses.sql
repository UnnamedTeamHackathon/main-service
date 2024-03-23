create table if not exists course_types
(
    id   uuid primary key default gen_random_uuid(),
    name text not null
);

create table if not exists courses
(
    id          uuid primary key default gen_random_uuid(),
    name        text not null,
    description text,
    difficulty  int  not null    default 0,
    type_id     uuid references course_types (id)
);

create table if not exists students
(
    user_id   uuid references users (id),
    course_id uuid references courses (id),
    status    int default 0
);

create index course_id_index on courses (id);