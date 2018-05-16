CREATE PROCEDURE [dbo].[DeletePerson] (@doc nchar(15))
AS BEGIN
	DELETE FROM People WHERE Document = @doc
END
GO

CREATE PROCEDURE [dbo].[GetAllPeople]
AS BEGIN
	SELECT * FROM People
END
GO