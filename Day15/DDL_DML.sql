USE master

CREATE DATABASE Day15

USE Day15

CREATE TABLE DEPARTMENT (
    deptname VARCHAR(100) PRIMARY KEY,
    floor INT,
    phone VARCHAR(20),
    empno INT NOT NULL,
)

CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    empname VARCHAR(100),
    salary DECIMAL(10, 2),
    deptname VARCHAR(100) NOT NULL,
    bossno INT NULL,
    CONSTRAINT fk_emp_dept FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname),
    CONSTRAINT fk_emp_boss FOREIGN KEY (bossno) REFERENCES EMP(empno)
)

ALTER TABLE DEPARTMENT
ADD CONSTRAINT fk_department_emp FOREIGN KEY (empno) REFERENCES EMP(empno)

CREATE TABLE ITEM (
    itemname VARCHAR(100) PRIMARY KEY,
    itemtype VARCHAR(50),
    itemcolor VARCHAR(50)
)

CREATE TABLE SALES (
    salesno INT PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(100) NOT NULL,
    deptname VARCHAR(100) NOT NULL,
    CONSTRAINT fk_sales_item FOREIGN KEY (itemname) REFERENCES ITEM(itemname),
    CONSTRAINT fk_sales_dept FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname)
)

INSERT INTO EMP (empno, empname, salary, deptname, bossno) VALUES
(1, 'Alice', 75000, 'Management', NULL),
(2, 'Ned', 45000, 'Marketing', 1),
(3, 'Andrew', 25000, 'Marketing', 2),
(4, 'Clare', 22000, 'Marketing', 2),
(5, 'Todd', 38000, 'Accounting', 1),
(6, 'Nancy', 22000, 'Accounting', 5),
(7, 'Brier', 43000, 'Purchasing', 1),
(8, 'Sarah', 56000, 'Purchasing', 7),
(9, 'Sophie', 35000, 'Personnel', 1),
(10, 'Sanjay', 15000, 'Navigation', 3),
(11, 'Rita', 15000, 'Books', 4),
(12, 'Gigi', 16000, 'Clothes', 4),
(13, 'Maggie', 11000, 'Clothes', 4),
(14, 'Paul', 15000, 'Equipment', 3),
(15, 'James', 15000, 'Equipment', 3),
(16, 'Pat', 15000, 'Furniture', 3),
(17, 'Mark', 15000, 'Recreation', 3)

INSERT INTO DEPARTMENT (deptname, floor, phone, empno) VALUES
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2)

ALTER TABLE DEPARTMENT
ALTER COLUMN empno INT NULL

INSERT INTO DEPARTMENT (deptname, floor, phone, empno) VALUES
('Management', 5, '34', NULL),
('Books', 1, '81', NULL),
('Clothes', 2, '24', NULL),
('Equipment', 3, '57', NULL),
('Furniture', 4, '14', NULL),
('Navigation', 1, '41', NULL),
('Recreation', 2, '29', NULL),
('Accounting', 5, '35', NULL),
('Purchasing', 5, '36', NULL),
('Personnel', 5, '37', NULL),
('Marketing', 5, '38', NULL)

UPDATE DEPARTMENT
SET empno = 2
WHERE deptname = 'Marketing'

INSERT INTO SALES (salesno, saleqty, itemname, deptname) VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(117, 1, 'Geo positioning system', 'Equipment'),
(118, 1, 'Geo positioning system', 'Recreation'),
(119, 1, 'Geo positioning system', 'Furniture'),
(120, 1, 'Pocket Knife-Nile', 'Furniture'),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(122, 1, 'How to win foreign friends', 'Books'),
(123, 1, 'Compass', 'Books'),
(124, 1, 'Pith Helmet', 'Books'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation')

INSERT INTO ITEM (itemname, itemtype, itemcolor) VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent - 8 person', 'F', 'Khaki')

ALTER TABLE DEPARTMENT
ALTER COLUMN empno INT NOT NULL

SELECT * FROM DEPARTMENT
SELECT * FROM EMP
SELECT * FROM ITEM
SELECT * FROM SALES
