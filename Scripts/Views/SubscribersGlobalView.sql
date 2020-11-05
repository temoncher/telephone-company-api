CREATE VIEW [V_subscribers_global]
AS
SELECT
  [subscriber_id],
  [inn],
  [first_name],
  [last_name],
  [patronymic],
  [adress],
  [subscribers].[organisation_id],
  [organisations].[name] AS [organisation_name]
FROM [subscribers]
  JOIN [organisations]
  ON [organisations].[organisation_id] = [subscribers].[organisation_id]