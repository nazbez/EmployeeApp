/*
Show all employees whose salary is higher than their manager's salary
*/

SELECT 
	e.ID,
	e.Name,
	e.Salary,
	e.ManagerID,
	e.DepartmentID
FROM [dbo].[Employee] e
JOIN [dbo].[Employee] m ON e.ManagerID = m.Id
WHERE e.Salary > m.Salary;