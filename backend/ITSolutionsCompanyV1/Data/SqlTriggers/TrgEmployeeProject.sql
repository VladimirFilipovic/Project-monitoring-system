CREATE TRIGGER trgEmployeeProject
on EmployeeProject
AFTER INSERT, UPDATE
AS
BEGIN
	declare @EmployeeId uniqueidentifier;
	declare @EmployeePrev uniqueidentifier;
	declare @Deleted bit;
	declare @DeletedPrevious bit;

	declare ep_cursor cursor FAST_FORWARD  for
	select EmployeeId,Deleted
	from inserted
	open ep_cursor

	declare deleted_cursor cursor FAST_FORWARD  for
	select Deleted, EmployeeId
	from deleted
	open deleted_cursor
	
	fetch next from deleted_cursor
		into @DeletedPrevious, @EmployeePrev;

	fetch next from ep_cursor
		into @EmployeeId,@Deleted;
			
	while @@FETCH_STATUS = 0 
		BEGIN
			print(@EmployeePrev);
			IF @EmployeePrev is null --assigned new project to employee
				BEGIN
					update AspNetUsers
					set  NumberOfActiveProjects = NumberOfActiveProjects + 1
					where AspNetUsers.Id = @EmployeeId
				END
			ELSE IF update (Deleted) -- deleted is changed from 0 to 1 or vice versa
				BEGIN
					if(@Deleted > @DeletedPrevious)  --1 > 0 so its deleted
						BEGIN
							update AspNetUsers
							set NumberOfActiveProjects = NumberOfActiveProjects - 1
							where AspNetUsers.Id = @EmployeeId
						END
					else if (@Deleted < @DeletedPrevious) --0 < 1 so its active again
						BEGIN
							update AspNetUsers
							set NumberOfActiveProjects = NumberOfActiveProjects + 1
							where AspNetUsers.Id = @EmployeeId
						END
				END--ako je insert odnosno ako je projekat ponovo aktivan

			fetch next from ep_cursor
				into @EmployeeId,@Deleted;
			
			fetch next from deleted_cursor
				into @DeletedPrevious,@EmployeePrev;
		END
	close ep_cursor
	deallocate ep_cursor
	close deleted_cursor
	deallocate deleted_cursor
END