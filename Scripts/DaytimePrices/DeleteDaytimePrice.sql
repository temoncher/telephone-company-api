USE [telephone_company];

DELETE FROM
  [daytime_prices]
WHERE
  [price_id] = @priceId
  AND [daytime_id] = @daytimeId