USE [telephone_company];

SELECT
  *
FROM [calls]
WHERE
  [call_id] = @callId