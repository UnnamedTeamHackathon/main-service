update courses
set name        = coalesce(@Name, name),
    description = coalesce(@Description, description),
    difficulty  = coalesce(@Difficulty, difficulty),
    type_id     = coalesce(@TypeId, type_id)
where id = @Id;