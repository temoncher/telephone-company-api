USE [telephone_company]

DECLARE @callsLocations TABLE(
	[subscriber_id] INT NOT NULL,
	[locality_id] INT NOT NULL,
	[duration] INT NOT NULL
);

INSERT INTO @callsLocations
SELECT
	[calls].[subscriber_id],
	[localities].[locality_id],
	SUM([calls].[duration])
FROM [calls]
JOIN [localities] ON [calls].[locality_id] = [localities].[locality_id]
GROUP BY [calls].[subscriber_id], [localities].[locality_id]

SELECT *
FROM @callsLocations