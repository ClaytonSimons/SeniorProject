USE master
IF db_id('UserDB') IS NOT NULL
DROP DATABASE UserDB
GO
CREATE DATABASE UserDB
GO
USE UserDB

CREATE TABLE UserClient
(
UserID	INT IDENTITY(1,1) NOT NULL,
UserName	VARCHAR(50),
Pass	VARCHAR(50),
CONSTRAINT UserClient_pk PRIMARY KEY (UserID)
);


CREATE TABLE WordData
(
WordID	INT	IDENTITY(1,1) NOT NULL,
UserID	INT NOT NULL,
Word	VARCHAR(50),
KeyValue	INT,
KeyboardType	INT,
CONSTRAINT WordData_pk PRIMARY KEY (WordID),
CONSTRAINT WordData_UserClient_fk FOREIGN KEY (UserID) REFERENCES UserClient (UserID)
);


CREATE TABLE Timing
(
TimingID	BIGINT IDENTITY(1,1) NOT NULL,
WordID		INT NOT NULL,
Timing		INT,
CONSTRAINT Timing_pk PRIMARY KEY (TimingID),
CONSTRAINT Timing_Timing_fk FOREIGN KEY (WordID) REFERENCES WordData (WordID)
);