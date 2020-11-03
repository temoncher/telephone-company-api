USE [telephone_company]

DECLARE @insertedWithAccountId TABLE(
	[daytime_id] INT NOT NULL,
	[duration] INT NOT NULL,
	[account_id] INT NOT NULL
);

DECLARE @insertedWithTransactionTypeId TABLE(
	[daytime_id] INT NOT NULL,
	[duration] INT NOT NULL,
	[account_id] INT NOT NULL,
	[transaction_type_id] INT NOT NULL
);

INSERT INTO @insertedWithAccountId
SELECT [daytime_id], [duration], [account_id]
FROM [calls]
	JOIN [accounts] ON [calls].[subscriber_id] = [accounts].[subscriber_id]

INSERT INTO @insertedWithTransactionTypeId
SELECT [account_id], [duration], [daytime_id], [transaction_type_id]
FROM @insertedWithAccountId
	JOIN [transaction_types] ON [transaction_types].[title] = 'LOSS'


SELECT *
FROM @insertedWithTransactionTypeId