USE [telephone_company];

-- Subscribers only if associated with localities
SELECT *
FROM [subscribers], [localities]
WHERE [subscribers].[locality_id] = [localities].[locality_id]

-- Subscribers with their account information
SELECT *
FROM [subscribers], [accounts]
WHERE [subscribers].[subscriber_id] = [accounts].[subscriber_id]
