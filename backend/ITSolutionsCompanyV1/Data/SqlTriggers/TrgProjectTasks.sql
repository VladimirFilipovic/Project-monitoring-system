CREATE TRIGGER trgProjectTasks
ON Projects
AFTER UPDATE
AS
BEGIN
--DELETE
	IF 1 in (select deleted from inserted) 
	BEGIN
		UPDATE Documentation
		SET Deleted = 1
		WHERE Documentation.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT Deleted FROM inserted where Documentation.ProjectId = inserted.Id) >
			(SELECT Deleted FROM deleted where Documentation.ProjectId = deleted.Id))

		UPDATE Tasks
		SET Deleted = 1
		WHERE Tasks.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT Deleted FROM inserted where Tasks.ProjectId = inserted.Id) >
			(SELECT Deleted FROM deleted where Tasks.ProjectId = deleted.Id))	

		UPDATE Demos
		SET Deleted = 1
		WHERE Demos.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT Deleted FROM inserted where Demos.ProjectId = inserted.Id) >
			(SELECT Deleted FROM deleted where Demos.ProjectId = deleted.Id))

		UPDATE Payments
		SET Deleted = 1
		WHERE Payments.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT Deleted FROM inserted where Payments.ProjectId = inserted.Id) >
			(SELECT Deleted FROM deleted where Payments.ProjectId = deleted.Id))
		
		UPDATE EmployeeProject
		SET Deleted = 1
		WHERE EmployeeProject.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT Deleted FROM inserted where EmployeeProject.ProjectId = inserted.Id) >
			(SELECT Deleted FROM deleted where EmployeeProject.ProjectId = deleted.Id))	
	END 
	IF 1 in (select IsCompleted from inserted)
	BEGIN
		UPDATE Tasks
		SET Completed = 1
		WHERE Tasks.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT IsCompleted FROM inserted where Tasks.ProjectId = inserted.Id) >
			(SELECT IsCompleted FROM deleted where Tasks.ProjectId = deleted.Id))	

		UPDATE EmployeeProject
		SET Deleted = 1
		WHERE EmployeeProject.ProjectId IN  
			(SELECT Id FROM inserted) AND 
			((SELECT IsCompleted FROM inserted where EmployeeProject.ProjectId = inserted.Id) >
			(SELECT IsCompleted FROM deleted where EmployeeProject.ProjectId = deleted.Id))	
	END
END

