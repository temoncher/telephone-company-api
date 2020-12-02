USE [telephone_company];

-- Subscribers only if associated with localities
SELECT *
FROM [subscribers]
INNER JOIN [localities] ON [subscribers].[locality_id] = [localities].[locality_id]

-- Subscribers with their account information
SELECT *
FROM [subscribers]
INNER JOIN [accounts] ON [subscribers].[subscriber_id] = [accounts].[subscriber_id]
