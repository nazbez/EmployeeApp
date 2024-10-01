/*
Show departments with more than 50 employees
*/

SELECT DepartmentID, 
	COUNT(*) AS EmployeeCount
FROM [dbo].[Employee]
GROUP BY DepartmentID
HAVING COUNT(*) > 50;