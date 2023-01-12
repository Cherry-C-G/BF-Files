create database CourseDAO

CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

CREATE TABLE Course (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX) NOT NULL,
    ProfessorId INT NOT NULL,
    FOREIGN KEY (ProfessorId) REFERENCES Professor(Id)
);

CREATE TABLE Professor (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Office VARCHAR(50) NOT NULL,
    Title VARCHAR(50) NOT NULL
);

CREATE TABLE Student_Course (
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id),
    FOREIGN KEY (CourseId) REFERENCES Course(Id)
);
