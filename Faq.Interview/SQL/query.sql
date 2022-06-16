

;WITH CTE_TEMP1(Id, Designation, Rank, Salary, SerialNo) AS (
	SELECT Id, Designation, Rank, Salary,
	DENSE_RANK() OVER (PARTITION BY Rank ORDER BY Salary DESC) AS SerialNo
	FROM Employee
),
CTE_TEMP2(Id, Designation, Rank, Salary, SerialNo) AS (
	SELECT Id, Designation, Rank, Salary,
	DENSE_RANK() OVER (PARTITION BY Rank ORDER BY Salary DESC) AS SerialNo
	FROM Employee
)

SELECT 
	T1.SerialNo AS [Serial No],
	T1.Id,
	T1.Rank,
	T1.Designation,
	T1.Salary,
	CASE WHEN T2.Salary - T1.Salary = 0 THEN 'Max Salary' ELSE CAST(T2.Salary - T1.Salary AS NVARCHAR(50)) END AS [Salary Difference]  

FROM CTE_TEMP1 AS T1
	LEFT JOIN CTE_TEMP2 AS T2 ON T1.Rank = T2.Rank AND T1.Rank IN ( SELECT TOP 2 Rank FROM CTE_TEMP2 WHERE SerialNo = 1 )
WHERE T2.SerialNo = 1
