insert into modules (course_id, name, "order")
values (@CourseId, @Name, @Order)
returning id;