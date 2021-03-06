using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Data.Repository;
using Assignment1.Data.Model;

namespace Assignment1
{
    class ManageCustomer
    {
        IRepository<Customer> customerRepository;
        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
        }
        void AddCustomer()
        {
            Customer c = new Customer();
            Console.Write("Enter id = ");
            c.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter firstname = ");
            c.FirstName = Console.ReadLine();
            Console.Write("Enter lastname = ");
            c.LastName = Console.ReadLine();
            Console.Write("Enter mobile = ");
            c.Mobile = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter emailid = ");
            c.EmailId = Console.ReadLine();
            Console.Write("Enter city = ");
            c.City = Console.ReadLine();
            Console.Write("Enter state = ");
            c.State = Console.ReadLine();

            if (customerRepository.Insert(c) > 0)
                Console.WriteLine("Customer added successfully");
            else
                Console.WriteLine("Add customer failed");
        }
        void UpdateCustomer()
        {

        }
        void DeleteCustomer()
        {
            Console.Write("Enter id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (customerRepository.Delete(id) > 0)
                Console.WriteLine("Customer deleted successfully");
            else
                Console.WriteLine("Delete customer failed");
        }
        void PrintCustomers()
        {
            var collection = customerRepository.GetAll();
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FirstName} \t {item.LastName} \t {item.Mobile} \t {item.EmailId} \t {item.City} \t {item.State}");
                }
            }
        }
        void PrintCustomerById()
        {
            Console.Write("Enter id =");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer c = customerRepository.GetById(id);
            if (c != null)
            {
                Console.WriteLine($"{c.Id} \t {c.FirstName} \t {c.LastName} \t {c.Mobile} \t {c.EmailId} \t {c.City} \t {c.State}");
            }
            else
                Console.WriteLine("No customer found");
        }
        public void Run()
        {
            PrintCustomerById();
        }



    }
}
