update modules
set "order" = case
                  when @newOrder >= @order then "order" - 1
                  else "order" + 1
    end
where course_id = @courseId
  and "order" >= @order
  and "order" <= @newOrder;

update modules
set "order" = @newOrder
where id = @id;