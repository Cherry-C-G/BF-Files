use aw;

TRUNCATE TABLE DimScenario;

BEGIN Transaction;

INSERT INTO DimScenario(ScenarioKey, ScenarioName)
SELECT 1, N'Actual' FROM DUAL UNION ALL
SELECT 2, N'Budget' FROM DUAL UNION ALL
SELECT 3, N'Forecast' FROM DUAL;

COMMIT;
