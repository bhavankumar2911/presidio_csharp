use pubs

select * from sys.tables

select * from sales
select * from titles
select * from publishers
select * from authors
select * from titleauthor
select * from employee

-- 1) Print the storeid and number of orders for the store
select stor_id, count(ord_num) 'No of Orders' from sales group by stor_id

-- 2) print the number of orders for every title
select t.title, count(*) 'No of Orders' from sales s join titles t on s.title_id = t.title_id group by t.title;

-- 3) print the publisher name and book name
select t.title, p.pub_name from titles t join publishers p on t.pub_id = p.pub_id

-- 4) Print the author full name for al the authors
select concat(au_fname, ' ', au_lname) from authors

-- 5) Print the price or every book with tax 
select title, price, price + (price * 12.36 / 100) 'Amount payable' from titles

-- 6) Print the author name, title name
select a.au_fname, t.title
from authors a join
titleauthor ta on a.au_id = ta.au_id join
titles t on ta.title_id = t.title_id

-- 7) print the author name, title name and the publisher name
select a.au_fname, t.title, p.pub_name
from authors a join
titleauthor ta on a.au_id = ta.au_id join
titles t on ta.title_id = t.title_id join
publishers p on t.pub_id = p.pub_id

-- 8) Print the average price of books pulished by every publisher
select p.pub_name, avg(t.price) 'Average price of books publised'
from publishers p join titles t on p.pub_id = t.pub_id
group by p.pub_name

-- 9) print the books published by 'Marjorie'
select p.pub_name, t.title
from publishers p join titles t on p.pub_id = t.pub_id
where p.pub_name = 'Marjorie'

-- 10) Print the order numbers of books published by 'New Moon Books'
select s.ord_num, t.title
from sales s join titles t on s.title_id = s.title_id
join publishers p on t.pub_id = p.pub_id
where p.pub_name = 'New Moon Books'

-- 11) Print the number of orders for every publisher
select p.pub_name, count(s.ord_num) 'No of orders'
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
group by p.pub_name

-- 12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title "book name", s.qty, t.price, (s.qty * t.price) 'total order value'
from sales s
join titles t on s.title_id = t.title_id

-- 13) print the total order quantity for every book
select t.title, sum(s.qty) 'quantity'
from sales s 
join titles t on s.title_id = t.title_id
group by t.title

-- 14) print the total ordervalue for every book
select t.title, sum(s.qty * t.price) 'total order value'
from sales s 
join titles t on s.title_id = t.title_id
group by t.title

-- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.*
from sales s join titles t on s.title_id = t.title_id
join publishers p on p.pub_id = t.pub_id
join employee e on e.pub_id = p.pub_id
where e.fname = 'Paolo'