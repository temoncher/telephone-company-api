USE [telephone_company]

-- By first name ASC
SELECT *
FROM [subscribers]
ORDER BY [subscribers].[first_name]

-- By last name DESC
SELECT *
FROM [subscribers]
ORDER BY [subscribers].[last_name] DESC