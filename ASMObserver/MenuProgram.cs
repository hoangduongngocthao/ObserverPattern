using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace AsmObserver
{
    public class MenuProgram 
    {
        List<ProductData> products = new List<ProductData>();
        public void Run()
        {
            bool running = true;
            while (running)
            {
                PrintMenu();
                int opt = GetOption();
                DoTask(opt);
                if (opt == 0) running = false;
            }
        }

        protected int GetOption()
        {
            System.Console.Write("Enter Your Choice: ");
            int opt = Convert.ToInt32(Console.ReadLine());
            return opt;
        }

        protected void PrintMenu()
        {
            System.Console.WriteLine("------Menu-----");
            System.Console.WriteLine("1. AddNewProduct");
            System.Console.WriteLine("2. AddObserverSeller");
            System.Console.WriteLine("3. AddObserverCustomer");
            System.Console.WriteLine("4. UpdateProduct");
            System.Console.WriteLine("5. ShowAllProduct");
            System.Console.WriteLine("6. ShowFollower");
            System.Console.WriteLine("0. Exit");
            System.Console.WriteLine("Please Enter Your Choice!!!");
        }
        protected void DoTask(int option)
        {
            switch (option)
            {
                case 1: AddNewProduct(); break;
                case 2: AddObserverSeller(); break;
                case 3: AddObserverCustomer(); break;
                case 4: UpdateProduct(); break;
                case 5: ShowAllProduct(); break;
                case 6: ShowFollower(); break;
                case 0: System.Console.WriteLine("GoodBye!"); break;
                default: System.Console.WriteLine("Invalid choice!"); break;
            }
        }

        public void AddNewProduct()
        {
            try
            {
                System.Console.WriteLine("------Add Product-----");
                System.Console.Write("Enter brand of product: ");
                string brand = Console.ReadLine();
                System.Console.Write("Enter cost of product: ");
                double cost = System.Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Enter amount of product: ");
                int amount = System.Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("--------Information of Product--------");
                ProductData p = new ProductData(brand, cost, amount);
                p.ShowInfo();
                products.Add(p);
                System.Console.WriteLine("You have add " + p.ID + " successfull");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error, please enter again!!!");
            }
        }


        public void UpdateProduct() 
        {
            System.Console.Write("Enter ID Product: ");
            string id = Console.ReadLine();
            bool flag = true;
            foreach (ProductData product in products)
            {
                if (product.ID == id)
                {
                    flag = false;
                    System.Console.Write("Enter amount product want to add: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write("Enter cost product want to add: ");
                    int cost = Convert.ToInt32(Console.ReadLine());
                    product.Amount += amount;
                    product.Cost += cost;
                    product.Notify();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Product does not exist");
            }
        }

        public void AddObserverCustomer()
        {
            System.Console.Write("Enter ID Product: ");
            string id = Console.ReadLine();
            bool flag = true;
            foreach (ProductData product in products)
            {
                if (product.ID == id)
                {
                    flag = false;
                    System.Console.Write("Enter name customer: ");
                    string name = Console.ReadLine();
                    Customer customer = new Customer(product, name);
                    product.Add(customer);
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Product does not exist");
            }
        }
        public void AddObserverSeller()
        {
            System.Console.Write("Enter ID Product: ");
            string id = Console.ReadLine();
            bool flag = true;
            foreach (ProductData product in products)
            {
                if (product.ID == id)
                {
                    flag = false;
                    System.Console.Write("Enter name Seller: ");
                    string name = Console.ReadLine();
                    Seller seller = new Seller(product, name);
                    product.Add(seller);
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Product does not exist");
            }
        }

        public void ShowAllProduct()
        {
            foreach(ProductData p in products)
            {
                System.Console.WriteLine("-------Information--------");
                p.ShowInfo();
            }
        }

        public void ShowFollower()
        {
            System.Console.Write("Enter ID Product: ");
            string id = Console.ReadLine();
            bool flag = true;
            foreach (ProductData product in products)
            {
                if (product.ID == id)
                {
                    flag = false;
                    System.Console.WriteLine("--------Information-------");
                    product.ShowInfo();
                    System.Console.WriteLine("-------Follower-------");
                    product.ShowAllInfo();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Does not exist");
            }
        }


    }
}
