USE [telephone_company];

UPDATE [prices]
SET [locality_id] = @localityId,
    [title] = @title
WHERE [price_id] = @priceId