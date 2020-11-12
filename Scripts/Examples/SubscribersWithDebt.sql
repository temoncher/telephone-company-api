USE [telephone_company]

DECLARE @subscribersWithDebt TABLE(
	[subscriber_id] INT NOT NULL,
	[first_name] NVARCHAR(30) NOT NULL,
	[last_name] NVARCHAR(30) NOT NULL,
	[patronymic] NVARCHAR(30),
	[adress] NVARCHAR(50),
	[debt] MONEY NOT NULL,
	[fine] MONEY NOT NULL
);

INSERT INTO @subscribersWithDebt
SELECT TOP 3
	[subscribers].[subscriber_id],
	[subscribers].[first_name],
	[subscribers].[last_name],
	[subscribers].[patronymic],
	[subscribers].[adress],
	ABS([accounts].[balance]) AS debt,
	 -- I didn't really get how do I calculate fine, so I just multipled balance by random number
	ABS([accounts].[balance]) * 0.08 AS fine
FROM [subscribers]
JOIN [accounts] ON [subscribers].[subscriber_id] = [accounts].[subscriber_id]
WHERE [accounts].[balance] < 0

SELECT *
FROM @subscribersWithDebt