USE [telephone_company];

DELETE FROM
  [prices]
WHERE
  [price_id] = @priceId