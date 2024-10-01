/*
Show the department with the highest sum of salaries of all its employees
*/

SELECT TOP(1) 
	DepartmentID, 
	SUM(Salary) AS 'SalarySum'
FROM [dbo].[Employee]
GROUP BY DepartmentID
ORDER BY 'SalarySum' DESC;