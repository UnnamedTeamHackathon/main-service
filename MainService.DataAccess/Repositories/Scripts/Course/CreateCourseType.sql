insert into course_types (name)
values (@Name)
returning id;