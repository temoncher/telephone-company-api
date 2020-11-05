CREATE VIEW [V_transactions_global]
AS
SELECT
  [transaction_id],
  [amount],
  [timestamp],
  [V_accounts_global].[account_id],
  [V_accounts_global].[subscriber_full_name],
  [transaction_types].[transaction_type_id],
  [transaction_types].[title] AS [transaction_type_title]
FROM [transactions]
  JOIN [V_accounts_global]
  ON [transactions].[account_id] = [V_accounts_global].[account_id]
  JOIN [transaction_types]
  ON [transactions].[transaction_type_id] = [transaction_types].[transaction_type_id]