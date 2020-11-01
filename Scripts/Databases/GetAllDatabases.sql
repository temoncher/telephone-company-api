SELECT name, database_id
FROM sys.databases
WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');