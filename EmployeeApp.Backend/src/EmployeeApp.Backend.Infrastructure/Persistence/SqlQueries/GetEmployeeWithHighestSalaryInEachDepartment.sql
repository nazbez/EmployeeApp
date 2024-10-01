/*
Show the employee with the highest salary in each department
*/

WITH RankedSalaries AS (
    SELECT ID,
        Name,
        Salary,
        DepartmentID,
		ManagerID,
        ROW_NUMBER() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
    FROM [dbo].[Employee]
)
SELECT ID,
	Name,
	Salary,
	DepartmentID,
	ManagerID
FROM RankedSalaries
WHERE Rank = 1;