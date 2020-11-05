USE [telephone_company];

SELECT
  *
FROM [subscribers]
WHERE
  [subscriber_id] = @subscriberId