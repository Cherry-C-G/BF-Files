--Question Name
--413. SQL Practice - University Scheduling
--Question Resources
--Question Description
--A university maintains data on professors, departments, courses and schedules in four tables: DEPARTMENT, PROFESSOR, COURSE and SCHEDULE.

--Write a query to print the names of professor with the names of the course they teach (or have taught) within their department. Each row in the results must be distinct (i.e., a professor teaching the same course over multiple semesters should only appear once), but the result can be in any order. Output should contain two columns: PROFESSOR.NAME, COURSE.NAME.

--Professor Table:
--| Name						| Type		| Description																													|
--| ID							| Integer	| A professor's ID in the inclusive range [1,1000]. This is a primary key.						|
--| NAME					| String		| A professor's name. This field contains between 1 and 100 characters (inclusive)	|
--| DEPARTMENT_ID	| Integer	| A professor's department ID. This is a foreign key to DEPARTMENT.ID.					|
--| SALARY					| Integer	| A professor's salary in the inclusive range [5000, 40000].											|

--Department Table:
--| Name						| Type		| Description																													|
--| ID							| Integer	| A department ID in the inclusive range [1,1000]. This is a primary key.					|
--| NAME					| String		| A department name. This field contains between 1 and 100 characters (inclusive)	|

--Course Table:
--| Name						| Type		| Description																											|
--| ID							| Integer	| A course ID in the inclusive range [1,1000]. This is a primary key.					|
--| NAME					| String		| A course name. This field contains between 1 and 100 characters (inclusive)	|
--| DEPARTMENT_ID	| Integer	| A course's department ID. This is a foreign key to DEPARTMENT.ID.				|
--| CREDITS				| Integer	| The number of credits allocated to the course in the inclusive range[1, 10].	|
 
--Schedule Table:
--| Name						| Type		| Description																														|
--| PROFESSOR_ID	| Integer	| The ID of the professor teaching the course. This is a foreign key to PROFESSOR.ID.	|
--| COURSE_ID			| Integer	| The course's ID number. This is a foreign key to COURSE.ID.										|
--| SEMESTER			| Integer	| A semester ID in the inclusive range [1, 6].																	|
--| YEAR						| Integer	| A calendar year in the inclusive range [2000, 2017].			

create table Department
(
	ID int Primary Key,
	Name Varchar(100)
);

create table Professor
(
	ID int Primary Key,
	Name Varchar(100),
	Department_ID int,
	Salary int,
	Foreign Key(Department_ID) references Department(ID)
);

create table Course
(
	ID int Primary Key,
	Name Varchar(100),
	Department_ID int,
	Credits int,
	Foreign Key (Department_ID) references Department(ID)
);

create table Schedule(
	Professor_ID int,
	Course_ID int,
	Semester int,
	Year int,
	Foreign Key(Professor_ID) references Professor(ID),
	Foreign Key(Course_ID) references Course(ID)
);

Insert into Department (ID, Name) values
(1, 'CS'),
(2,'English'),
(3,'Math');

insert into Professor(ID, Name, Department_ID,Salary) values
(1,'David B', 1, 10000),
(2,'Jane A', 2, 10000),
(3,'Bob J',3,10000);

insert into Course(ID, Name, Department_ID,Credits) values
(1,'CS101',1,4),
(2,'Englis101',2,4),
(3,'Math101',3,4);

--insert into Schedule(Professor_ID, Course_ID,Semester, Year) values
--(1,1,1,2020),
--(1,4,2,2020),
--(2,2,3,2020),
--(3,3,4,2020);

select distinct p.Name as ProfessorName, c.Name as CourseName
from Professor p
inner join Schedule s on p.ID = s.Professor_ID
inner join Course c on s.Course_ID = c.ID
where p.Department_ID = c.Department_ID

--Q2:Given a Movie table (id | name | rating), find the top 5 rated movie whose name contains the word "man".



select * from Movie
where name Like'%man%'
order by rating DESC
limit 5