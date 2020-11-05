USE [telephone_company];

SELECT
  *
FROM [transactions]
WHERE
  [transaction_id] = @transactionId