USE [telephone_company];

SELECT
  *
FROM [daytime_prices]
WHERE
  [price_id] = @priceId