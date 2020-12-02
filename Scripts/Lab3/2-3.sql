USE [telephone_company];

-- All subscribers with associated localities(if present)
SELECT *
FROM [subscribers]
LEFT JOIN [localities] ON [subscribers].[locality_id] = [localities].[locality_id]

-- All transactions with associated calls(if present)
SELECT *
FROM [transactions]
LEFT JOIN [calls] ON [transactions].[call_id] = [calls].[call_id]
