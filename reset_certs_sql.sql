


update membercerts set completed = 0 where id in (select top 4 id from membercerts
order by membercerts.id desc)
