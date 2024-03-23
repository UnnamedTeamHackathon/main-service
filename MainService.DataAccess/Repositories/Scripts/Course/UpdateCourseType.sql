update course_types
set name = coalesce(@Name, name)
where id = @Id;