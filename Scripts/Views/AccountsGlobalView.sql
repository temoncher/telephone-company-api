CREATE VIEW [V_accounts_global]
AS
SELECT
  [account_id],
  [balance],
  [subscribers].[subscriber_id],
  [subscriber_full_name] = CONCAT(
    [subscribers].[first_name],
    ' ',
    [subscribers].[last_name]
  )
FROM [accounts]
  JOIN [subscribers]
  ON [subscribers].[subscriber_id] = [accounts].[subscriber_id]