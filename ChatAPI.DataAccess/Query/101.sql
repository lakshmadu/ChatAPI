-- Create the database
CREATE DATABASE ChatAppDB;
GO

-- Use the new database
USE ChatAppDB;
GO

-- Create Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Create ChatRooms table
CREATE TABLE ChatRooms (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Create Messages table
CREATE TABLE Messages (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    ChatRoomId INT FOREIGN KEY REFERENCES ChatRooms(Id),
    Content NVARCHAR(MAX) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE()
);
GO
