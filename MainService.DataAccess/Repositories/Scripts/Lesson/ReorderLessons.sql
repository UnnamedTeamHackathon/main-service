update lessons
set "order" = case
                  when @newOrder >= @order then "order" - 1
                  else "order" + 1
    end
where module_id = @moduleId
  and "order" >= @order
  and "order" <= @newOrder;

update lessons
set "order" = @newOrder
where id = @id;