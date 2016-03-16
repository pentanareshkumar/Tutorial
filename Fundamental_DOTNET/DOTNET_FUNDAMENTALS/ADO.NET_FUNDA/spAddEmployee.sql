
CREATE TABLE tblEmployees
(
EmployeeId int identity primary key,
Name nvarchar(50),
Gender nvarchar(10),
Salary int
);

GO

INSERT INTO tblEmployees values('Mason','Male',5000)
INSERT INTO tblEmployees values('Priyanka','Female',3500)
INSERT INTO tblEmployees values('John','Male',2350)
INSERT INTO tblEmployees values('Louna','Female',5700)
INSERT INTO tblEmployees values('Jackson','Male',4890)
INSERT INTO tblEmployees values('Aulia','Female',4500)

CREATE PROCEDURE spAddEmployee
@Name varchar(50),
@Gender varchar(20),
@Salary int,
@EmployeID int Out
AS 
BEGIN
INSERT INTO tblEmployees values(@Name,@Gender,@Salary)
SELECT @EmployeID = SCOPE_IDENTITY()
END


EXECUTE @RC = [dbo].[spAddEmployee] 
   'Sai1'
  ,'Male'
  ,10000
  ,@EmployeID OUTPUT
GO