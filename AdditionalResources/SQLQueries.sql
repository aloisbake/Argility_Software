/*IF DB_ID('UserManagement') IS NOT NULL
BEGIN
	USE master;
    ALTER DATABASE  UserManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END*/

USE master;
ALTER DATABASE  UserManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

DROP DATABASE IF EXISTS UserManagement;
CREATE DATABASE UserManagement;
USE UserManagement;

DROP TABLE IF EXISTS [ProfileUser];
DROP TABLE IF EXISTS [UserGroup];

CREATE TABLE UserGroup (
    UserGroupID  int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
    [Description] varchar(255) NOT NULL,
	IsActive int NULL
);

CREATE TABLE ProfileUser (
    ProfileUserID int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
    [Name] varchar(255) NOT NULL,
    [Description] varchar(255) NOT NULL,
    EmailAddress varchar(255) NOT NULL,
	[Password] varchar(255) NOT NULL,
	IsActive int Default 1, 
	UserGroupID int FOREIGN KEY REFERENCES UserGroup(UserGroupID)
);

INSERT INTO UserGroup (Name, Description, IsActive)
VALUES ('Administator', 'Can manage users and run reports', 1),
('User', 'Can view and run reports', 1);

INSERT INTO ProfileUser (Name, Description, EmailAddress, Password, IsActive, UserGroupID)
VALUES ('admin', 'can manage users and run reports', 'admin@argilitysoftware.co.za', 'Password123', 1, 1),
('user1', 'can view users run reports', 'user1@argilitysoftware.co.za', 'Password123', 1, 1);


Select * FROM [UserGroup];
Select * FROM [ProfileUser];
