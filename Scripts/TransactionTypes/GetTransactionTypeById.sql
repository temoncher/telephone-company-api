USE [telephone_company];

SELECT
  *
FROM
  [transaction_types]
WHERE
  [transaction_type_id] = @transactionTypeId