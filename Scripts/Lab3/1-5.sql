USE [telephone_company];

-- All subscribers with "Land" in adress
SELECT *
FROM [subscribers]
WHERE [subscribers].[adress] LIKE '%Land%'

-- All localities that has "r" as second character
SELECT *
FROM [localities]
WHERE [localities].[name] LIKE '_r%'