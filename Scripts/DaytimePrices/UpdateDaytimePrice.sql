USE [telephone_company];

UPDATE
  [daytime_prices]
SET
  [price_per_minute] = @pricePerMinute
WHERE
  [price_id] = @priceId
  AND [daytime_id] = @daytimeId