using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class CustomerRepositoryTest
    {
        IRepository<int, Customer> _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            Customer newCustomer = new Customer(1, "+91 9090909090", "bhavan", 21);
            _customerRepository.Add(newCustomer);
        }

        [Test]
        public void AddCustomerPassTest()
        {
            Customer newCustomer = new Customer(2, "+91 0909090909", "john", 23);
            _customerRepository.Add(newCustomer);
            List<Customer> customers = (List<Customer>)_customerRepository.GetAll();
            Assert.AreEqual(2, customers.Count);
        }

        [Test]
        public void AddCustomerExceptionTest()
        {
            Customer newCustomer = new Customer(1, "+91 9090909090", "bhavan", 21);
            var exception = Assert.Throws<CustomerDuplicationException>(() => _customerRepository.Add(newCustomer));

            Assert.AreEqual($"Customer with this id {newCustomer.Id} already exists", exception.Message);
        }

        [Test]
        public void GetCustomerByIdPassTest()
        {
            Customer customer = _customerRepository.GetByKey(1);
            Assert.AreEqual("bhavan", customer.Name);
        }

        [Test]
        public void GetCustomerByIdExceptionTest()
        {
            var exception = Assert.Throws<CustomerNotFoundException>(() => _customerRepository.GetByKey(5));

            Assert.AreEqual($"No customer is found with this id: {5}", exception.Message);
        }

        [Test]
        public void GetAllCustomersPassTest()
        {
            List<Customer> customers = (List<Customer>)_customerRepository.GetAll();
            Assert.AreEqual(1, customers.Count);
        }

        [Test]
        public void GetAllCustomersExceptionTest()
        {
            IRepository<int, Customer> _customerRepository = new CustomerRepository();

            var exception = Assert.Throws<NoCustomersFoundException>(() => _customerRepository.GetAll());

            Assert.AreEqual("No customers are available", exception.Message);
        }

        [Test]
        public void DeleteCustomerPassTest()
        {
            Customer newCustomer = new Customer(2, "+91 0909090909", "john", 23);
            _customerRepository.Add(newCustomer);
            Customer deletedCustomer = _customerRepository.Delete(1);

            Assert.AreEqual(1, _customerRepository.GetAll().Count);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            var exception = Assert.Throws<CustomerNotFoundException>(() => _customerRepository.Delete(5));

            Assert.AreEqual("No customer is found with this id: 5", exception.Message);
        }

        [Test]
        public void CustomerUpdatePassTest()
        {
            Customer customerWithChanges = new Customer(1, "+91 9090909090", "bhavan kumar", 21);
            _customerRepository.Update(customerWithChanges);

            Customer updatedCustomer = _customerRepository.GetByKey(1);

            Assert.AreEqual("bhavan kumar", updatedCustomer.Name);
        }

        [Test]
        public void CustomerUpdateExceptionTest()
        {
            Customer customerWithChanges = new Customer(5, "+91 9090909090", "bhavan kumar", 21);

            var exception = Assert.Throws<CustomerNotFoundException>(() => _customerRepository.Update(customerWithChanges));

            Assert.AreEqual("No customer is found with this id: 5", exception.Message);
        }

    }
}