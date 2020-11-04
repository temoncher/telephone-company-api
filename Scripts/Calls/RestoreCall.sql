USE [telephone_company];

UPDATE
  [calls]
SET
  [deleted_at] = NULL
WHERE
  [call_id] = @callId