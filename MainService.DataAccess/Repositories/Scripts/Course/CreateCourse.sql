insert into courses (name, description, difficulty, type_id)
values (@Name, @Description, @Difficulty, @TypeId)
returning id;