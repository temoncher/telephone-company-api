USE [telephone_company];

DELETE FROM
  [subscribers]
WHERE
  [subscriber_id] = @subscriberId