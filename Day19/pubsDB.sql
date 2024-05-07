use pubs

select * from sys.tables

select * from titleauthor
select * from jobs
select * from stores
select * from employee
select * from publishers
select * from authors
select * from sales
select * from titles

-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
create proc prop_GetTitleAndPublisherName(@authorFirstName varchar(20)) as
select t.title, p.pub_name from titles t
join titleauthor ta on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
join publishers p on t.pub_id = p.pub_id
where a.au_fname = @authorFirstName

exec prop_GetTitleAndPublisherName 'Cheryl'

-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
create proc prop_GetTitlePriceQuantityAndCost(@employeeFirstName varchar(20)) as
select t.title, t.price, s.qty, (t.price * s.qty) 'cost' from publishers p 
join employee e on p.pub_id = e.pub_id
join titles t on t.pub_id = p.pub_id
join sales s on s.title_id = t.title_id
where e.fname = @employeeFirstName

exec prop_GetTitlePriceQuantityAndCost 'Paolo'

-- 3) Create a query that will print all names from authors and employees
select concat(au_fname, ' ', au_lname) 'All employees and authors' from authors
union
select concat(fname, ' ', lname) from employee

-- 4) Create a  query that will float the data from
-- sales,titles, publisher and authors table to print title name,
-- Publisher's name, author's full name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price

select top 5 t.title, p.pub_name, concat(a.au_fname, ' ', a.au_lname) 'author', s.qty, (s.qty * t.price) 'price' from titles t
join sales s on s.title_id = t.title_id
join publishers p on p.pub_id = t.pub_id
join titleauthor ta on ta.title_id = t.title_id
join authors a on a.au_id = ta.au_id
order by (s.qty * t.price) desc