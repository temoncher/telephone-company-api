USE [telephone_company];

DELETE FROM
  [localities]
WHERE
  [locality_id] = @localityId