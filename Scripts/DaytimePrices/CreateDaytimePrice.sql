USE [telephone_company];

INSERT INTO
  [daytime_prices]
  (
    [price_id],
    [daytime_id],
    [price_per_minute]
  )
VALUES
  (
    @priceId,
    @daytimeId,
    @pricePerMinute
  );