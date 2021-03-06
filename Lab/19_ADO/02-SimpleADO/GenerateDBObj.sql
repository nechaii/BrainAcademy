  --insert into Categories(CategoryName,Description) values ('Test','Test');
  --delete from Categories where CategoryName='Test';

use master;
go
IF DB_ID('BAStudent') IS NOT NULL DROP DATABASE BAStudent;
go
CREATE DATABASE BAStudent;
GO
USE BAStudent;
GO
CREATE SCHEMA Student AUTHORIZATION dbo;
go
IF object_ID('Student') IS NOT NULL DROP Table Student;

create table Student
(
Id int not null identity(1,1),
FirstName varchar(20) not null,
LastName varchar(50) not null,
Grade char(2),
AvgGrade decimal,
Birthdate DateTime default DATEADD(Year,-1,GETDATE()),

constraint PK_Students Primary Key(Id),
constraint CHK_Birthdate CHECK(birthdate <= CURRENT_TIMESTAMP-10)
);
GO
USE BAStudent;
GO
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Mentos','Stimorol',4,5.0);
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Sancho','Vatra',4,5.0);
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Pedro','Prima',4,5.0);
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Garcia','Elevator',4,5.0);
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Elbarto','Gomes',4,5.0);
insert into Student (FirstName,LastName,Grade,AvgGrade) values ('Huano','Muches',4,5.0);
;
go
USE BAStudent;
go
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetStudentProc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GetStudentProc]
GO
Create proc [dbo].[GetStudentProc] @pId int
as select  * from Student where Id=@pId;
go
go
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateStudentProc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UpdateStudentProc]
GO
Create Procedure [dbo].[UpdateStudentProc] 
/*as 

Declare*/

@pId as int=1,
@pFirstName as varchar(20) = null,
@pLastName as varchar(50)=null,
@pGrade as char(2) = null,
@pAvgGrade as decimal = null

As
--begin
	update Student set FirstName=@pFirstName, LastName=@pLastName where Id=@pId;



