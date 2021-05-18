declare @projectGuid uniqueidentifier = 'a22752d6-1ab6-8f16-90a6-8845241a936c';
declare @task1Guid uniqueidentifier = 'a22452d6-1ab6-8f16-90a6-8845241a936c';
declare @task2Guid uniqueidentifier = 'a32752d6-1ab6-8f16-90a6-8845241a936c';
declare @clientGuid uniqueidentifier = 'a22752d6-1ab6-4f16-90a6-8845241a936c';


insert into Projects (Id, Name, Deadline, ClientId, Specification) values(@projectGuid,'Project 4', '2021-2-2', @clientGuid, (convert(VARBINARY(max), 'TestCase'))); 
insert into Projects (Id, Name, Deadline, ClientId, Specification) values(NEWID(),'Project 55', '2021-2-2', @clientGuid, (convert(VARBINARY(max), 'TestCase'))); 

insert into Tasks (Id, Name, Description, ProjectId) values (@task1Guid, 'Task1', 'First task', @projectGuid);
insert into Tasks (Id, Name, Description, ProjectId) values (@task2Guid, 'Task2', 'Second task', @projectGuid);

insert into Payments (Id, Amount, Currency, ClientId, ProjectId) values (NEWID(), 100, 'EUR', @clientGuid, @projectGuid);
insert into Payments (Id, Amount, Currency, ClientId, ProjectId) values (NEWID(), 100, 'EUR', @clientGuid, @projectGuid);

insert into EmployeeTask (EmployeeId, TaskId) values ('e06ba72a-3469-4eb3-82c6-606d5e57a807', @task1Guid);
insert into EmployeeTask (EmployeeId, TaskId) values ('e06ba72a-3469-4eb3-82c6-606d5e57a807', @task2Guid);

insert into EmployeeProject (EmployeeId, ProjectId, RoleOnProject) values ('e06ba72a-3469-4eb3-82c6-606d5e57a807', @projectGuid, 'Developer');
insert into EmployeeProject (EmployeeId, ProjectId, RoleOnProject) values ('b16ac5fc-61ab-4509-ab2d-b4b2ed2897b9', @projectGuid, 'QA');

insert into Documentation (Id, Name, Version, Pdf, Accepted, EmployeeId, ProjectId) values (NEWID(), 'Doc1', 'v1.0.0', (convert(VARBINARY(max), 'TestCase')), 0, 'e06ba72a-3469-4eb3-82c6-606d5e57a807', @projectGuid);
insert into Documentation (Id, Name, Version, Pdf, Accepted, EmployeeId, ProjectId) values (NEWID(), 'Doc2', 'v1.0.0', (convert(VARBINARY(max), 'TestCase')), 0, 'e06ba72a-3469-4eb3-82c6-606d5e57a807', @projectGuid);

insert into Demos (Id, Name, Video, Exe, Comment, ProjectId) values (NEWID(), 'Demo1', (convert(VARBINARY(max), 'TestCase')), (convert(VARBINARY(max), 'TestCase')), 'Video1', @projectGuid);
insert into Demos (Id, Name, Video, Exe, Comment, ProjectId) values (NEWID(), 'Demo2', (convert(VARBINARY(max), 'TestCase')), (convert(VARBINARY(max), 'TestCase')), 'Video1', @projectGuid);

