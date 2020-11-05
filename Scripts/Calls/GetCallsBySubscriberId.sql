USE [telephone_company];

SELECT
  *
FROM [calls]
WHERE
  [subscriber_id] = @subscriberId