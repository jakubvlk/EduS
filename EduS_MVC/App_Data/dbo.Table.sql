CREATE TABLE [dbo].[Table]
(
	[FirstName] NVARCHAR(50) NOT NULL , 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Username] VARCHAR(10) NOT NULL IDENTITY, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(20) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(200) NOT NULL, 
    [DegreeBefore] NVARCHAR(50) NOT NULL, 
    [DegreeAfter] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([Username])
)
