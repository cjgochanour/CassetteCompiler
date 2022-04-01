USE MASTER
GO

IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'CassetteCompiler'
)
CREATE DATABASE CassetteCompiler
GO

USE CassetteCompiler
GO

DROP TABLE IF EXISTS CassetteGenre;
DROP TABLE IF EXISTS Genre;
DROP TABLE IF EXISTS Cassette;
DROP TABLE IF EXISTS [User];

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Cassette] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [Artist] nvarchar(255) NOT NULL,
  [Album] nvarchar(255) NOT NULL,
  [Year] int,
  [Notes] nvarchar(2000)
)
GO

CREATE TABLE [Genre] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [CassetteGenre] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CassetteId] int NOT NULL,
  [GenreId] int NOT NULL
)
GO

ALTER TABLE [Cassette] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [CassetteGenre] ADD FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [CassetteGenre] ADD FOREIGN KEY ([CassetteId]) REFERENCES [Cassette] ([Id]) ON DELETE CASCADE
GO
