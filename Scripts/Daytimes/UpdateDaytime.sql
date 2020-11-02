USE [telephone_company];

UPDATE
  [daytimes]
SET
  [title] = @title
WHERE
  [daytime_id] = @daytimeId