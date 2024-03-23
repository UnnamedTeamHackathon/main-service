update modules
set name = coalesce(@name, name)
where id = @id;