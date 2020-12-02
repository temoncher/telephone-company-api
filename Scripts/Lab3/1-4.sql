USE [telephone_company];

-- Total duration of calls for each locality with grandtotal
SELECT
	[calls].[locality_id],
	SUM([calls].[duration]) AS [total_duration]
FROM [calls]
GROUP BY ROLLUP([calls].[locality_id])

-- Total duration of calls for each combination of locality and daytime
SELECT
	[calls].[locality_id],
	[calls].[daytime_id],
	SUM([calls].[duration]) AS [total_duration]
FROM [calls]
GROUP BY CUBE([calls].[locality_id], [calls].[daytime_id])