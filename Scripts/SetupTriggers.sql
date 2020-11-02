USE [telephone_company]
GO

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_subscribers_AfterInsert] ON [subscribers]
AFTER
INSERT
  AS BEGIN
  INSERT INTO
  [accounts]
    ([subscriber_id])
  SELECT
    [subscriber_id]
  FROM
    [inserted]
END;

GO

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_transactions_AfterInsert] ON [transactions]
AFTER
INSERT
  AS BEGIN
  DECLARE @newInserted TABLE(
    account_id INT NOT NULL,
    income INT NOT NULL,
    loss INT NOT NULL
  )

  INSERT INTO @newInserted
  SELECT
    [inserted].[account_id],
    SUM(CASE WHEN [transaction_types].[title] = 'INCOME' THEN [inserted].[amount] ELSE 0 END) [income],
    SUM(CASE WHEN [transaction_types].[title] = 'LOSS' THEN [inserted].[amount] ELSE 0 END) [loss]
  FROM
    [inserted]
    JOIN [transaction_types] ON [inserted].[transaction_type_id] = [transaction_types].[transaction_type_id]
  GROUP BY [inserted].[account_id]

  UPDATE
    [accounts]
  SET
    [balance] = (
      SELECT [@newInserted].[income] - [@newInserted].[loss]
  FROM @newInserted
  WHERE [accounts].[account_id] = [@newInserted].[account_id]
    )
  WHERE [accounts].[account_id] IN (
    SELECT DISTINCT [@newInserted].[account_id]
  FROM @newInserted
  )
END;

GO