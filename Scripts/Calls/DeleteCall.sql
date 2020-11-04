USE [telephone_company];

DELETE FROM
  [calls]
WHERE
  [call_id] = @callId