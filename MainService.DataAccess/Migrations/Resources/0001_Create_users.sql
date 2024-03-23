create table if not exists users
(
    id                          uuid primary key     default gen_random_uuid(),
    role                        int         not null default 0,
    email                       text unique not null,
    username                    text unique not null,
    password_hash               text,
    refresh_token               text,
    refresh_token_expired_after timestamp,
    name                        text,
    surname                     text,
    patronymic                  text,
    birthday                    timestamp,
    photo_id                    uuid,
    country                     int         not null default 0
);

create index user_id_index on users (id);
create index email_index on users (email);
create index username_index on users (username);