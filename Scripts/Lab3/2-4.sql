USE [telephone_company];

-- All localities with associated subscribers(if present)
SELECT *
FROM [subscribers]
RIGHT JOIN [localities] ON [subscribers].[locality_id] = [localities].[locality_id]

-- All transactions with associated calls(if present)
-- Same as LEFT JOIN [transactions] with [calls]
SELECT *
FROM [calls]
RIGHT JOIN [transactions] ON [transactions].[call_id] = [calls].[call_id]
