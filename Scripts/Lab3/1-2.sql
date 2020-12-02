USE [telephone_company]

-- Subscribers where adress is not null
SELECT *
FROM [subscribers]
WHERE [adress] IS NOT NULL

-- Subscriber who's inn is 112
SELECT *
FROM [subscribers]
WHERE [inn] = 112