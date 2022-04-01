INSERT INTO [User] ([Name], Email) VALUES ('Mark Andrews', 'mark@andrews.com')
INSERT INTO [User] ([Name], Email) VALUES ('Alice Parado', 'alice@parado.net')
INSERT INTO [User] ([Name], Email) VALUES ('Jack Freely', 'jack@freely.com')
INSERT INTO [User] ([Name], Email) VALUES ('Marlon Brando', 'm@b.net')
INSERT INTO [User] ([Name], Email) VALUES ('Tim Curry', 'tim@curry.com')

INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (1, 'Bad Brains', 'Bad Brains', 1982, null)
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (2, 'Michael Jackson', 'Thriller', 1982, 'What a guy')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (3, 'Meshuggah', 'Chaosphere', 1998, 'I just had to own this in every variant')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (4, 'Taylor Swift', 'Folklore', 2020, 'She is just magical')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (5, 'Various Artists', 'The Rocky Horror Picture Show', 1975, null)
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (1, 'BTS', 'Dynamite', 2020, null)
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (1, 'Mortiis', 'The Song Of A Long Forgotten Ghost', 1993, 'Ah, my dungeon synth fix')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (3, 'Tool', 'Undertow', null, 'unofficial bootleg tape')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (4, 'Nino Rota', 'The Godfather (Original Soundtrack)', null, null)
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (2, 'Various Artists', 'Footloose (Original Soundtrack)', 1984, null)
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (3, 'Koji Kondo', 'The Legend of Zelda', null, 'homemade from NES to tape deck')
INSERT INTO Cassette (UserId, Artist, Album, [Year], Notes) VALUES (1, 'Black Flag', 'Damaged', 1981, 'Signed by Mike Patton')


INSERT INTO Genre ([Name]) VALUES ('Rock')
INSERT INTO Genre ([Name]) VALUES ('Pop')
INSERT INTO Genre ([Name]) VALUES ('Punk')
INSERT INTO Genre ([Name]) VALUES ('Soundtrack')
INSERT INTO Genre ([Name]) VALUES ('Hip-Hop')
INSERT INTO Genre ([Name]) VALUES ('Electronic')
INSERT INTO Genre ([Name]) VALUES ('Jazz')
INSERT INTO Genre ([Name]) VALUES ('Reggae')
INSERT INTO Genre ([Name]) VALUES ('Other')

INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (1, 3)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (2, 2)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (3, 9)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (3, 1)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (4, 2)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (5, 4)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (5, 1)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (6, 2)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (7, 6)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (8, 9)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (8, 1)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (9, 4)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (10, 4)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (11, 4)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (11, 6)
INSERT INTO CassetteGenre (CassetteId, GenreId) VALUES (12, 3)