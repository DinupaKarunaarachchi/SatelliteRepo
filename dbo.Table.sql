CREATE TABLE [dbo].[Satellites]
(
	[satid] INT NOT NULL PRIMARY KEY, 
    [satname] NCHAR(10) NULL, 
    [longtitute] NCHAR(10) NULL, 
    [latitute] NCHAR(10) NULL, 
    [elevation] NCHAR(10) NULL, 
    [health] NCHAR(10) NULL
)
