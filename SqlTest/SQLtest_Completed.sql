CREATE TABLE #temp ([id] INT, [name] VARCHAR (100), [salary] MONEY, [manager_id] INT)

INSERT INTO #temp VALUES (1,'John',300,3)
INSERT INTO #temp VALUES (2,'Mike',200,3)
INSERT INTO #temp VALUES (3,'Sally',550,4)
INSERT INTO #temp VALUES (4,'Jane',500,7)
INSERT INTO #temp VALUES (5,'Joe',600,7)
INSERT INTO #temp VALUES (6,'Dan',600,3)
INSERT INTO #temp VALUES (7,'Phil',550,NULL)


--1.	Give the names of employees, whose salaries are greater than their immediate managers’:

SELECT empl.[name] [Employee Name whose salary is greater than immediate managers]
--, mgr.[name] ManagerName, mgr.[salary] ManagerSalary,  empl.[salary] EmployeeSalary 
FROM #temp empl
JOIN #temp mgr ON empl.[manager_id] = mgr.id
WHERE  empl.[salary] > mgr.[salary] 


--2.	What is the average salary of employees who do not manage anyone? In the sample above, that would be John, Mike, Joe and Dan, since they do not have anyone reporting to them.

SELECT AVG ([salary]) [average salary of employees who do not manage anyone] 
FROM #temp 
WHERE id NOT IN (select DISTINCT [manager_id] 
				from #temp
				WHERE [manager_id] IS NOT NULL
				) 
				
DROP TABLE #temp				