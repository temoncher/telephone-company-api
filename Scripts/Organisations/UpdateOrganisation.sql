USE [telephone_company];

UPDATE
  [organisations]
SET
  [name] = @name
WHERE
  [organisation_id] = @organisationId