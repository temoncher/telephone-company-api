USE [telephone_company]
GO
;

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_subscribers_AfterInsert] ON [subscribers]
AFTER
INSERT
  AS BEGIN
INSERT INTO
  [accounts] ([subscriber_id])
SELECT
  [subscriber_id]
FROM
  inserted
END;

GO
;

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_transactions_AfterInsert] ON [transactions]
AFTER
INSERT
  AS BEGIN DECLARE @accountId INT,
  @amount INT,
  @transactionType VARCHAR,
  @previousBalance INT
SELECT
  @accountId = account_id,
  @amount = amount,
  @transactionType = transaction_type_id
FROM
  inserted -- TODO: join inserted with transaction types
SELECT
  @previousBalance = balance
FROM
  [accounts]
WHERE
  [account_id] = @accountId
UPDATE
  [accounts]
SET
  [balance] = CASE
    WHEN @transactionType = 'INCOME' THEN @previousBalance + @amount
    ELSE @previousBalance - @amount
  END
WHERE
  [account_id] = @accountId
END;

GO
;