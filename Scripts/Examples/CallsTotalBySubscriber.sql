USE [telephone_company]

DECLARE @callsWithCost TABLE(
	[subscriber_id] INT NOT NULL,
	[call_id] INT NOT NULL,
	[cost] SMALLMONEY NOT NULL
);

INSERT INTO @callsWithCost
SELECT
	[calls].[subscriber_id],
	[calls].[call_id],
	[transactions].[amount]
FROM [calls]
JOIN [transactions] ON [calls].[call_id] = [transactions].[call_id]
WHERE YEAR([calls].[created_at]) = YEAR(GETDATE())

SELECT *
FROM @callsWithCost

DECLARE @aggregated TABLE(
	[subscriber_id] INT NOT NULL,
	[calls_number] INT NOT NULL,
	[total] SMALLMONEY NOT NULL
);

INSERT INTO @aggregated
SELECT
	[@callsWithCost].[subscriber_id],
	COUNT([call_id]) AS calls_number,
	SUM([@callsWithCost].[cost]) AS total
FROM @callsWithCost
GROUP BY [@callsWithCost].[subscriber_id]

SELECT *
FROM @aggregated
