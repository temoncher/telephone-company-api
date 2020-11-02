USE [telephone_company];

UPDATE
  [transaction_types]
SET
  [title] = @title
WHERE
  [transaction_type_id] = @transactionTypeId