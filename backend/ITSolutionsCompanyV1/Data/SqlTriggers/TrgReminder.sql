CREATE TRIGGER trgReminder  
ON Projects
AFTER INSERT 
AS  
BEGIN
   EXEC msdb.dbo.sp_send_dbmail  
        @profile_name = 'ITSolutions Admin',  
        @recipients = 'vlada.19982309@gmail.com',  
        @body = 'New project request',  
        @subject = 'Request';  
END