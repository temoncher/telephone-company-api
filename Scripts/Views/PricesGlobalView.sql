CREATE VIEW [V_prices_global]
AS
SELECT [price_id], [localities].[locality_id], [title], [localities].[name] AS [locality_name]
FROM [prices]
JOIN [localities]
ON [prices].[locality_id] = [localities].[locality_id]