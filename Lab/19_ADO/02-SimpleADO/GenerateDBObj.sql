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
IF DB_ID('Student') IS NOT NULL DROP Table Student;

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



