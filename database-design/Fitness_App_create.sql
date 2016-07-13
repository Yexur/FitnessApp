-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2016-07-13 19:29:41.525

-- tables
-- Table: Class
CREATE TABLE Class (
    id int NOT NULL,
    classID int NOT NULL,
    startTime time NOT NULL,
    endTime time NOT NULL,
    date date NOT NULL,
    locationID int NOT NULL,
    instructorID int NOT NULL,
    status int NOT NULL,
    capacity int NOT NULL,
    created timestamp NOT NULL,
    updated timestamp NOT NULL,
    CONSTRAINT Class_pk PRIMARY KEY (id)
) COMMENT ''
COMMENT 'These are the actual classes being offered at work';

-- Table: ClassType
CREATE TABLE ClassType (
    id int NOT NULL,
    name varchar(255) NOT NULL,
    status bit NOT NULL,
    created timestamp NOT NULL,
    updated timestamp NOT NULL,
    CONSTRAINT ClassType_pk PRIMARY KEY (id)
) COMMENT ''
COMMENT 'The different types of classes that we will be offering';

-- Table: Instructors
CREATE TABLE Instructors (
    id int NOT NULL,
    name nvarchar(255) NOT NULL,
    created timestamp NOT NULL,
    updated timestamp NOT NULL,
    CONSTRAINT Instructors_pk PRIMARY KEY (id)
) COMMENT ''
COMMENT 'This is a list of possible instructors to teach the classes';

-- Table: Locations
CREATE TABLE Locations (
    id int NOT NULL,
    name nvarchar(255) NOT NULL,
    created timestamp NOT NULL,
    updated timestamp NOT NULL,
    CONSTRAINT Locations_pk PRIMARY KEY (id)
) COMMENT ''
COMMENT 'These are locations where the classes can be held';

-- Table: RegistrationRecords
CREATE TABLE RegistrationRecords (
    id int NOT NULL,
    classID int NOT NULL,
    emailAddress nvarchar(255) NOT NULL,
    waitlisted bit NOT NULL,
    created timestamp NOT NULL,
    updated timestamp NOT NULL,
    CONSTRAINT RegistrationRecords_pk PRIMARY KEY (id)
) COMMENT ''
COMMENT 'All class records are stored in this table';

-- foreign keys
-- Reference: Class_Locations (table: Class)
ALTER TABLE Class ADD CONSTRAINT Class_Locations FOREIGN KEY Class_Locations (locationID)
    REFERENCES Locations (id);

-- Reference: Class_RegistrationRecords (table: RegistrationRecords)
ALTER TABLE RegistrationRecords ADD CONSTRAINT Class_RegistrationRecords FOREIGN KEY Class_RegistrationRecords (classID)
    REFERENCES Class (id);

-- Reference: class_obj (table: Class)
ALTER TABLE Class ADD CONSTRAINT class_obj FOREIGN KEY class_obj (classID)
    REFERENCES ClassType (id);

-- Reference: instructor_class (table: Class)
ALTER TABLE Class ADD CONSTRAINT instructor_class FOREIGN KEY instructor_class (instructorID)
    REFERENCES Instructors (id);

-- End of file.

