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
IF DB_ID('Students') IS NOT NULL DROP Table Students;

create table Students
(
Id int not null identity,
FirstName varchar(20) not null,
LastName varchar(50) not null,
Grade char(2),
AvgGrade int,
Birthdate DateTime,

constraint PK_Students Primary Key(Id),
constraint CHK_birthdate CHECK(birthdate <= CURRENT_TIMESTAMP)
)

