USE [telephone_company];

UPDATE
  [prices]
SET
  [locality_id] = @localityId
WHERE
  [price_id] = @priceId