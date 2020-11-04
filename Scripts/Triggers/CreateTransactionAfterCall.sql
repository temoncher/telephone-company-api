-- Add account for each new subscriber
CREATE TRIGGER [TR_calls_AfterInsert] ON [calls]
AFTER
INSERT
  AS BEGIN
  SET NOCOUNT ON

  DECLARE @insertedWithAccountId TABLE(
    [locality_id] INT NOT NULL,
    [daytime_id] INT NOT NULL,
    [duration] INT NOT NULL,
    [account_id] INT NOT NULL
  );

  DECLARE @insertedWithTransactionTypeId TABLE(
    [locality_id] INT NOT NULL,
    [daytime_id] INT NOT NULL,
    [duration] INT NOT NULL,
    [account_id] INT NOT NULL,
    [transaction_type_id] INT NOT NULL
  );

  DECLARE @insertedWithPriceId TABLE(
    [daytime_id] INT NOT NULL,
    [duration] INT NOT NULL,
    [account_id] INT NOT NULL,
    [transaction_type_id] INT NOT NULL,
    [price_id] INT NOT NULL
  );

  DECLARE @insertedWithAmount TABLE(
    [account_id] INT NOT NULL,
    [transaction_type_id] INT NOT NULL,
    [amount] SMALLMONEY NOT NULL
  );

  INSERT INTO @insertedWithAccountId
  SELECT [locality_id], [daytime_id], [duration], [account_id]
  FROM [INSERTED]
    JOIN [accounts]
    ON [INSERTED].[subscriber_id] = [accounts].[subscriber_id]

  INSERT INTO @insertedWithTransactionTypeId
  SELECT [locality_id], [daytime_id], [duration], [account_id], [transaction_type_id]
  FROM @insertedWithAccountId
    JOIN [transaction_types]
    ON [transaction_types].[title] = 'LOSS'

  INSERT INTO @insertedWithPriceId
  SELECT [daytime_id], [duration], [account_id], [transaction_type_id], [price_id]
  FROM @insertedWithTransactionTypeId
    JOIN [prices]
    ON [prices].[locality_id] = [@insertedWithTransactionTypeId].[locality_id]

  INSERT INTO @insertedWithAmount
  SELECT [account_id], [transaction_type_id], [amount] = CAST([duration] AS REAL) / 60 * [price_per_minute]
  FROM @insertedWithPriceId
    JOIN [daytime_prices]
    ON [daytime_prices].[price_id] = [@insertedWithPriceId].[price_id]
      AND [daytime_prices].[daytime_id] = [@insertedWithPriceId].[daytime_id]

  INSERT INTO [transactions]
    ([account_id], [transaction_type_id], [amount])
  SELECT [account_id], [transaction_type_id], [amount]
  FROM @insertedWithAmount
END;