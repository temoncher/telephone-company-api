USE [telephone_company];

INSERT INTO
  [transactions] (
    [transaction_type_id],
    [account_id],
    [amount]
  )
VALUES
  (
    @transactionTypeId,
    @accountId,
    @amount
  );