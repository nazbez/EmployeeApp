/*
Show all employees whose manager is in a different department
*/

SELECT 
	e.ID,
	e.Name,
	e.Salary,
	e.ManagerID,
	e.DepartmentID,
	m.DepartmentID AS 'Manager`s DepartmentId'
FROM [dbo].[Employee] e
JOIN [dbo].[Employee] m ON e.ManagerID = m.Id
WHERE e.DepartmentID <> m.DepartmentID;