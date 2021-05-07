-- **** This stored procedure is designed for fetching similar advertisers.
-- **** Input  ************************************
-- ****      query     : query string for full text search
-- ****      advertiser: exclude itself from the result
-- **** Output ************************************
-- ****             Id : Adversiter Id (Similar one)
-- ****            Key : The KEY column returns unique values of the returned rows.
-- ****           Rank : Rank value from full text search
CREATE PROCEDURE [dbo].[GetDuplicatedNames]
	@query nvarchar(150),
	@advertiser nvarchar(100)
AS
BEGIN
	SELECT AD.[Id], KEY_TBL.[Key], KEY_TBL.[Rank]
	FROM [dbo].[Advertiser] AD
	JOIN CONTAINSTABLE ([dbo].[Advertiser], [Name], @query) AS KEY_TBL 
	ON AD.[Name] = KEY_TBL.[Key]
	WHERE KEY_TBL.[Key] <> @advertiser
	AND KEY_TBL.[RANK] >= 200
	ORDER BY KEY_TBL.[RANK] DESC
END
