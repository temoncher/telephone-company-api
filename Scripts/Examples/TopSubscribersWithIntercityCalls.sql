USE [telephone_company]

DECLARE @intercitySubscribers TABLE(
	[subscriber_id] INT NOT NULL,
	[total] SMALLMONEY NOT NULL
);

INSERT INTO @intercitySubscribers
SELECT TOP 3
	[subscribers].[subscriber_id],
	SUM([transactions].[amount]) AS total
FROM [calls]
JOIN [subscribers] ON [calls].[subscriber_id] = [subscribers].[subscriber_id]
JOIN [transactions] ON [calls].[call_id] = [transactions].[call_id]
WHERE [calls].[locality_id] <> [subscribers].[locality_id]
GROUP BY [subscribers].[subscriber_id]

SELECT *
FROM @intercitySubscribers