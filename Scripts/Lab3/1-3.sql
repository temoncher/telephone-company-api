USE [telephone_company]

-- Total duration of all calls
SELECT SUM([calls].[duration])
FROM [calls]

-- Largest transaction
SELECT MAX([transactions].[amount])
FROM [transactions]