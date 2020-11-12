USE [telephone_company]

DECLARE @locations TABLE(
	[locality_id] INT NOT NULL,
	[call_day] DATETIME NOT NULL,
	[subscribers_called] INT NOT NULL
);

INSERT INTO @locations
SELECT
	[localities].[locality_id],
	DATEADD(DAY, 0, DATEDIFF(DAY, 0, [calls].[created_at])) AS call_day,
	COUNT([calls].[subscriber_id]) AS subscribers_called
FROM [calls]
JOIN [localities] ON [calls].[locality_id] = [localities].[locality_id]
GROUP BY [localities].[locality_id], DATEADD(DAY, 0, DATEDIFF(DAY, 0, [calls].[created_at]))

SELECT *
FROM @locations