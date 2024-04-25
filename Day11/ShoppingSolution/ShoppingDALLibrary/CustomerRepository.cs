using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Add(Customer newCustomer)
        {
            bool customerExists = false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == newCustomer.Id) throw new CustomerDuplicationException(newCustomer.Id);
            }

            items.Add(newCustomer);
            return newCustomer;
        }

        public override List<Customer> GetAll()
        {
            if (items.Count == 0) throw new NoCustomersFoundException();

            return items;
        }

        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new CustomerNotFoundException(key);
        }

        public override Customer Update(Customer item)
        {
            Customer customerToBeUpdated = items.Find(customer => customer.Id == item.Id);

            if (customerToBeUpdated == null) throw new CustomerNotFoundException(item.Id);

            customerToBeUpdated.Id = item.Id;
            customerToBeUpdated.Name = item.Name;
            customerToBeUpdated.Age = item.Age;
            customerToBeUpdated.Phone = item.Phone;

            return customerToBeUpdated;
        }

    }
}
