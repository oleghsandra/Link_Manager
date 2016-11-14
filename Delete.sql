
-----------------------------------------------------------
--Delete all SP

IF OBJECT_ID('spUsers_Add') IS NOT NULL 
	DROP PROCEDURE spUsers_Add
GO

IF OBJECT_ID('spLink_AddNew') IS NOT NULL 
	DROP PROCEDURE spLink_AddNew
GO

IF OBJECT_ID('spLinks_Get') IS NOT NULL 
	DROP PROCEDURE spLinks_Get
GO

IF OBJECT_ID('spLinkType_Add') IS NOT NULL 
	DROP PROCEDURE spLinkType_Add
GO