USE [telephone_company]
GO

-- Add account for each new subscriber
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
    [INSERTED]
END;

GO

-- Update account valance after each transaction
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
    [INSERTED].[account_id],
    SUM(CASE WHEN [transaction_types].[title] = 'INCOME' THEN [INSERTED].[amount] ELSE 0 END) [income],
    SUM(CASE WHEN [transaction_types].[title] = 'LOSS' THEN [INSERTED].[amount] ELSE 0 END) [loss]
  FROM
    [INSERTED]
    JOIN [transaction_types] ON [INSERTED].[transaction_type_id] = [transaction_types].[transaction_type_id]
  GROUP BY [INSERTED].[account_id]

  UPDATE
    [accounts]
  SET
    [balance] = [accounts].[balance] + (
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