using System;

namespace AsmObserver
{
    public class Customer : ProductObserver
    {
        private ProductData product;

        public Customer (ProductData product, string name)
        {
            this.product = product;
            Name = name;
            Position = "Customer";
        }
        public override void Update()
        {
            bool isrunning = true;
            while (isrunning)
            {
                System.Console.WriteLine("------Customer "+ Name +"-----");
                System.Console.WriteLine(" New products have arrived, do you want to buy?");
                System.Console.WriteLine("1. Yes");
                System.Console.WriteLine("0. Exit");
                System.Console.WriteLine("Please Enter Your Choice!!!");
                int answer = System.Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        ConfirmBuyProduct();
                        break;
                    case 0:
                        System.Console.WriteLine("See your again!!");
                        break;
                    default:
                        break;
                }
                if(answer == 0)
                {
                    isrunning = false;
                } 
            }
        }
        public void ConfirmBuyProduct()
        {
            while (true)
            {
                System.Console.WriteLine("--------Amount--------");
                System.Console.Write("Product amount: ");
                int amount = System.Convert.ToInt32(Console.ReadLine());
                if (product.Amount >= amount)
                {
                    product.Amount -= amount;
                    System.Console.WriteLine("Successfull");
                    break;
                }
                else
                {
                    string choice;
                    System.Console.WriteLine("Not enough stock");
                    while (true)
                    {
                        System.Console.WriteLine("Do you want to Pre-Enter (Y,N)!!!");
                        choice = System.Console.ReadLine();
                        if(choice == "N" || choice == "Y")
                        {
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid!");
                        }
                    }
                    if (choice == "N")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine("------Product after buy -------");
            product.ShowInfo();
        }
    }
}