/*Creating a Table in Sql Server*/
CREATE TABLE Employee 
(
	names VARCHAR(20),
	address VARCHAR(20),
	employee_number INT,
	salary SMALLMONEY
);

GO

CREATE TABLE department
(
	dept_no CHAR(4) NOT NULL,
	dept_name CHAR(25) NOT NULL,
	location CHAR(30) NULL
	CONSTRAINT PK_department PRIMARY KEY CLUSTERED (dept_no ASC) ON [PRIMARY] 
);

GO 

CREATE TABLE project 
(
	project_no CHAR(4) NOT NULL,
	project_name CHAR(15) NOT NULL,
	budget FLOAT NULL
	CONSTRAINT PK_project PRIMARY KEY CLUSTERED (project_no ASC) ON [PRIMARY] 
);

