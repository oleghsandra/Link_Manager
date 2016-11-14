﻿USE [LinkManagerDB];
GO
----------------------------------------------------------

--Delete and create tables considering the FOREIGN keys
IF OBJECT_ID('UsersLinks', 'U') IS NOT NULL 
    DROP TABLE UsersLinks
GO

IF OBJECT_ID('Links', 'U') IS NOT NULL 
    DROP TABLE Links
GO

IF OBJECT_ID('LinkTypes', 'U') IS NOT NULL 
    DROP TABLE LinkTypes
GO

IF OBJECT_ID('Users', 'U') IS NOT NULL 
    DROP TABLE Users
GO


CREATE TABLE Users
(
	UserId INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
	Name NVARCHAR(100) NOT NULL,
	Email NVARCHAR(200) NOT NULL UNIQUE,
	[Password] NVARCHAR(200) NOT NULL
)
GO

CREATE TABLE LinkTypes
(
	LinkTypeId INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
	Name NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE Links
(
	LinkId INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
	Title NVARCHAR(200) NULL,
	IsFavorite BIT DEFAULT 0,
	TypeId INT NULL FOREIGN KEY REFERENCES LinkTypes(LinkTypeId) ON DELETE SET NULL,
	Url NVARCHAR(500) NOT NULL,
	CreationDate DATE NULL
)
GO

CREATE TABLE UsersLinks
(
	UserLinkId INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
	LinkId INT NOT NULL FOREIGN KEY REFERENCES Links(LinkId) ON DELETE CASCADE
)