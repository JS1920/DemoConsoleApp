using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp
{
    class Program
    {
        static List<Customer> allCustomers = new List<Customer>();
        static void Main(string[] args)
        {
            GetDummyData();
            PrintCustomersDetails();

            Console.ReadLine();
        }

        static void GetDummyData()
        {
            var listCustOrders = new List<Order>();
            listCustOrders.Add(new Order { OrderId = 1, OrderDate = DateTime.Now.AddDays(-1), Amount = 25, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 2, OrderDate = DateTime.Now.AddDays(-3), Amount = 35, ShippingCost = 5, ShippingMethods = "NA" });
            Customer cust1 = new Customer()
            {
                CustId = 1,
                FirstName = "Cust1",
                LastName = "LName1",
                orders = listCustOrders
            };
            listCustOrders = new List<Order>();
            listCustOrders.Add(new Order { OrderId = 3, OrderDate = DateTime.Now.AddDays(-5), Amount = 45, ShippingCost = 5, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 4, OrderDate = DateTime.Now.AddDays(-4), Amount = 55, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 5, OrderDate = DateTime.Now.AddDays(-3), Amount = 155, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 6, OrderDate = DateTime.Now.AddDays(-2), Amount = 25, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 7, OrderDate = DateTime.Now.AddDays(-1), Amount = 45, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 8, OrderDate = DateTime.Now.AddDays(-4), Amount = 25, ShippingCost = 10, ShippingMethods = "NA" });
            listCustOrders.Add(new Order { OrderId = 9, OrderDate = DateTime.Now.AddDays(-4), Amount = -25, ShippingCost = 10, ShippingMethods = "NA" });

            Customer cust2 = new Customer()
            {
                CustId = 2,
                FirstName = "Cust2",
                LastName = "LName2",
                orders = listCustOrders
            };
            allCustomers.Add(cust1);
            allCustomers.Add(cust2);
        }

        static void PrintCustomersDetails()
        {
            string star = "*";
            Console.WriteLine($"Customers Details:- ");
            foreach (var customer in allCustomers)
            {
                ValidateCustomerOrders(customer);
                Console.WriteLine($"FirstName: {customer.FirstName }  " + (IsPrefferedCustomer(customer) ? star : string.Empty)+ "\n");
                Console.WriteLine($"LastName: {customer.LastName} \n");
                CustomerOrders(customer);
            }

            void CustomerOrders(Customer customer)
            {
                int iorderCounter = 0;
                for (int i = 0; i < customer.orders.Count; i++)
                {
                    /// NOTE: One of the approach to skip order from printing which was not meeting the criteria.
                    //if (!IsOrderAmountValid(customer.orders[i].Amount)) continue;

                    if (iorderCounter == 4) //NOTE: Taking care of condition if the customer's order is 5th order.
                    {
                        //Send Email
                    };

                    Console.WriteLine($"OrderId: {customer.orders[i].OrderId} \n");
                    Console.WriteLine($"OrderDate: {customer.orders[i].OrderDate} \n");
                    Console.WriteLine($"Amount: {customer.orders[i].Amount} \n");
                    Console.WriteLine($"ShippingCost: {customer.orders[i].ShippingCost} \n");
                    Console.WriteLine($"ShippingMethods: {customer.orders[i].ShippingMethods} \n");
                    iorderCounter++;
                }
            }
        }

        static void ValidateCustomerOrders(Customer customer)
        {
            List<int> badOrders = new List<int>();
            foreach (var order in customer.orders)
            {
                if (!IsOrderAmountValid(order.Amount))
                {
                    badOrders.Add(order.OrderId);
                }
            }

            if (badOrders.Count > 0)
                customer.orders.RemoveAll(x => badOrders.Contains(x.OrderId));

        }
        static bool IsOrderAmountValid(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }
            return true;
        }
        static bool IsPrefferedCustomer(Customer customer)
        {
            int prefferedCustomerMinOrders = 5;
            if (customer.orders.Count >= prefferedCustomerMinOrders)
            {
                return true;
            }
            return false;
        }

    }
}
