use ManageSchoolSystem

use ManageSchoolSystem

CREATE TABLE Class(
	[class_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[class_name] nvarchar(50)
);

CREATE TABLE Users(
	userid int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[displayName] [nvarchar](50) NULL,
	[phone_number] [varchar](20) NULL,
	[email] [varchar](200) NULL,
	[class_id] int NULL,
	[role] [varchar](200), --Example : "student", "staff", "teacher"
	[isActive] [bit] DEFAULT 1,
	FOREIGN KEY (class_id) REFERENCES Class(class_id)
)

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(50) NOT NULL
);

CREATE TABLE ClassCourses (
    ClassID INT NOT NULL,
    CourseID INT NOT NULL,
    PRIMARY KEY (ClassID, CourseID),
    FOREIGN KEY (ClassID) REFERENCES Class(class_id),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE TeacherCourses (
    userid INT NOT NULL,
    CourseID INT NOT NULL,
    PRIMARY KEY (userid, CourseID),
    FOREIGN KEY (userid) REFERENCES Users(userid),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Grades (
    GradeID INT PRIMARY KEY IDENTITY(1,1),
    userid INT NOT NULL,
    CourseID INT NOT NULL,
    ClassID INT NOT NULL,
    Grade FLOAT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userid) REFERENCES Users(userid),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (ClassID) REFERENCES Class([class_id])
);

CREATE TABLE Semesters (
    SemesterID INT PRIMARY KEY IDENTITY(1,1),
    SemesterName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

CREATE TABLE Timetable (
    TimetableID INT PRIMARY KEY IDENTITY(1,1),
    ClassID INT NULL,
    Slot INT NULL, -- Slot trong ngày (1-4)
    DayOfWeek INT NULL, -- Thứ trong tuần (1-7)
    CourseID INT NULL,
    userid INT NULL,
    Room VARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CreatedBy VARCHAR(50) NULL,
	SemesterID INT,
    FOREIGN KEY (ClassID) REFERENCES Class([class_id]),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (userid) REFERENCES Users(userid),
	FOREIGN KEY (SemesterID) REFERENCES Semesters(SemesterID)
);

CREATE TABLE Attendance (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    TimetableID INT NOT NULL,
    userid INT NOT NULL,
    AttendanceStatus NVARCHAR(20), -- Ví dụ: "Present", "Absent", "Excused"
    Date DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (TimetableID) REFERENCES Timetable(TimetableID),
    FOREIGN KEY (userid) REFERENCES Users(userid)
);
