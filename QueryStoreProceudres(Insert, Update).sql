CREATE PROCEDURE [dbo].[NewClient] (@doc nchar(15), @name nchar(50))
AS BEGIN
INSERT INTO People (Document, name) values (@doc, @name);
END
GO

CREATE PROCEDURE [dbo].[UpdateClient] (@doc nchar(15), @name nchar(50))
AS BEGIN
UPDATE People SET name = @name WHERE Document = @doc;
END
GO

EXEC sp_rename NewClient, NewPerson;
EXEC sp_rename UpdateClient, UpdatePerson;