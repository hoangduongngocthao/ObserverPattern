using System;

namespace AsmObserver
{
    public class ProductData : Product
    {
        public string Brand { get; set; }
        public double Cost { get; set; }
        public string ID;
        public int Amount { get; set; }

        private static int nProducts = 0;
        public ProductData(string brand, double cost, int amount)
        {
            Brand = brand;
            Cost = cost;
            Amount = amount;
            ID = "sp" + ++nProducts;
        }

        public void ShowInfo()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Cost: " + Cost);
            Console.WriteLine("Amount: " + Amount);
        }
    }
}