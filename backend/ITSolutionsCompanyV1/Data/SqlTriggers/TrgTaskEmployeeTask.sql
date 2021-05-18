CREATE TRIGGER trgTaskEmployeeTask
ON Tasks
AFTER UPDATE
AS
BEGIN
	IF 1 in (select deleted from inserted)
	BEGIN
		update EmployeeTask
		set Deleted = 1
		where (EmployeeTask.TaskId in  (select Id from inserted)) and ((SELECT Deleted FROM inserted where EmployeeTask.TaskId = inserted.Id) >
			(SELECT Deleted FROM deleted where EmployeeTask.TaskId = deleted.Id))
	END

	IF 1 in (select Completed from inserted)
	BEGIN
	update EmployeeTask
		set Deleted = 1
		where (EmployeeTask.TaskId in  (select Id from inserted)) and ((SELECT Completed FROM inserted where EmployeeTask.TaskId = inserted.Id) >
			(SELECT Completed FROM deleted where EmployeeTask.TaskId = deleted.Id))
	END
END
