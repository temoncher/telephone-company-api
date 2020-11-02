USE [telephone_company];

DELETE FROM
  [transaction_types]
WHERE
  [transaction_type_id] = @transactionTypeId