USE [telephone_company];

UPDATE
  [localities]
SET
  [name] = @name
WHERE
  [locality_id] = @localityId