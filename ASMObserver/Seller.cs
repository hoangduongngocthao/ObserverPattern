using System;

namespace AsmObserver
{
    public class Seller : ProductObserver
    {
        private ProductData product;

        public Seller(ProductData product, string name)
        {
            this.product = product;
            Name = name;
            Position = "Seller";
        }
        public override void Update()
        {   
            bool isrunnings = true;
            while (isrunnings)
            {
                System.Console.WriteLine("------Seller " + Name + "------");
                System.Console.WriteLine("Product have arrived, do you want to sell?");
                System.Console.WriteLine("1. Yes");
                System.Console.WriteLine("0. Exit");
                System.Console.WriteLine("Please enter your choice!!!");
                int answer = System.Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1: 
                        ConfirmSellProduct();
                        break;
                    case 0: 
                        System.Console.WriteLine("See you again!!!");
                        break;
                    default:
                        break;
                }
                if (answer == 0)
                {
                    isrunnings = false;
                }
            }   
        }

        public void ConfirmSellProduct()
        {
            while (true)
            {
                System.Console.WriteLine("------Amount------");
                System.Console.Write("Product Amount: ");
                int amounts = System.Convert.ToInt32(Console.ReadLine());
                if (product.Amount >= amounts)
                {
                    product.Amount -= amounts;
                    System.Console.WriteLine("Success!");
                    break;
                }
                else
                {
                    string choice;
                    System.Console.WriteLine("Not enough product!!!");
                    while (true)
                    {
                        System.Console.WriteLine("Do you want to Pre-Enter (Y,N)!!!");
                        choice = Console.ReadLine();
                        if (choice == "N" || choice == "Y")
                        {
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid choice!!!");
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

            Console.WriteLine("------Product after sell -------");
            product.ShowInfo();
        }
    }
}