USE [LinkManagerDB];
GO
----------------------------------------------------------

-----------------------------------------------------------------
-- Users Sprocs
-----------------------------------------------------------------

IF OBJECT_ID('spUsers_Add') IS NOT NULL 
	DROP PROCEDURE spUsers_Add
GO

CREATE PROCEDURE spUsers_Add(
	@Name NVARCHAR(100),
	@Email NVARCHAR(200),
	@Password NVARCHAR(200)
)
AS
  SET NOCOUNT ON 
  INSERT INTO [dbo].[Users]
	VALUES(@Name, @Email, @Password);
	RETURN SCOPE_IDENTITY();
GO
-----------------------------------------------------------------

-----------------------------------------------------------------
-- LinkTypes Sprocs
---------------------------------------------------------------

IF OBJECT_ID('spLinkType_Add') IS NOT NULL 
	DROP PROCEDURE spLinkType_Add
GO

CREATE PROC spLinkType_Add(
	@Name NVARCHAR(100)
)
AS
 SET NOCOUNT ON 

	INSERT INTO LinkTypes
		VALUES(@Name);
GO
-----------------------------------------------------------------

IF OBJECT_ID('spLinkTypes_GetAll') IS NOT NULL 
	DROP PROCEDURE spLinkTypes_GetAll
GO

CREATE PROC spLinkTypes_GetAll
AS
 SET NOCOUNT ON 

	SELECT LinkTypeId, Name AS LinkTypeName
	FROM LinkTypes;
GO

-----------------------------------------------------------------
-- Links Sprocs
----------------------------------------------------------------

IF OBJECT_ID('spLink_AddNew') IS NOT NULL 
	DROP PROCEDURE spLink_AddNew
GO

CREATE PROCEDURE spLink_AddNew(
	@Title NVARCHAR(200),
	@TypeId INT,
	@Url NVARCHAR(500),
	@OwnerId INT,
	@CreationTime DATE = NULL
)
AS
  SET NOCOUNT ON 

  INSERT INTO Links
    VALUES (@Title,
			0,
			@TypeId, 
			@Url,
			COALESCE(@CreationTime, GETDATE()));

  DECLARE @CurrentLinkId INT = SCOPE_IDENTITY();

  INSERT INTO UsersLinks
	VALUES (@OwnerId,
		    @CurrentLinkId);
GO
-----------------------------------------------------------------

IF OBJECT_ID('spLinks_Get') IS NOT NULL 
	DROP PROCEDURE spLinks_Get
GO

CREATE PROCEDURE spLinks_Get(
	@OwnerId INT
)
AS
  SET NOCOUNT ON 
  SELECT Links.LinkId, Links.Title, t.LinkTypeName, LinkTypeId, Links.IsFavorite, Links.Url, Links.CreationDate
  FROM Links

  LEFT JOIN (SELECT Name AS LinkTypeName, LinkTypeId
			 FROM LinkTypes) AS t
  ON (t.LinkTypeId = Links.TypeId)

  INNER JOIN UsersLinks
  ON (UsersLinks.LinkId = Links.LinkId)
  
  WHERE (UsersLinks.UserId = @OwnerId) 
  
  ORDER BY LinkId DESC
GO
-----------------------------------------------------------------

IF OBJECT_ID('spLink_SetFavorite') IS NOT NULL 
	DROP PROCEDURE spLink_SetFavorite
GO
CREATE PROCEDURE spLink_SetFavorite(
    @LinkId INT,
	@NewFavoriteValue BIT
)
AS
 SET NOCOUNT ON 

   UPDATE Links
		SET IsFavorite = @NewFavoriteValue
    WHERE (Links.LinkId = @LinkId)
GO
-----------------------------------------------------------------

IF OBJECT_ID('spLink_Delete') IS NOT NULL 
	DROP PROCEDURE spLink_Delete
GO
CREATE PROCEDURE spLink_Delete(
    @LinkId INT
)
AS
 SET NOCOUNT ON 

   DELETE
    FROM Links
    WHERE (Links.LinkId = @LinkId)
GO
-----------------------------------------------------------------

IF OBJECT_ID('spLink_Update') IS NOT NULL 
	DROP PROCEDURE spLink_Update
GO
CREATE PROCEDURE spLink_Update(
    @LinkId INT,
	@Title NVARCHAR(200),
	@TypeId INT,
	@Url NVARCHAR(500)
)
AS
 SET NOCOUNT ON 

  UPDATE Links
    SET Title = @Title,
		 TypeId = @TypeId, 
		 Url = @Url
	WHERE (Links.LinkId = @LinkId)
GO
-----------------------------------------------------------------

--EXEC spLinks_Get 100, 1, 1, NULL, NULL, 'DESC';