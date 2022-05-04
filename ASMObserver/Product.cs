using System;
using System.Collections.Generic;

namespace AsmObserver
{
    public class Product
    {
        protected List<ProductObserver> observers;
        public Product()
        {
            observers = new List<ProductObserver>();
        }

        public void Add(ProductObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify()
        {
            if (observers.Count == 0)
            {
                Console.WriteLine("No Follower!!");
            }
            foreach(ProductObserver observer in observers)
            {
                observer.Update();
            }
        }

        public void ShowAllInfo()
        {
            foreach (ProductObserver ob in observers)
            {
                Console.WriteLine(ob.Name + " --- " + ob.Position); 
            }
        }

        public void Remove()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            bool flag = true;
            foreach (ProductObserver ob in observers)
            {
                if (ob.Name == name)
                {
                    flag = false;
                    observers.Remove(ob);
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Does not exist object!!!");
            }
        }
    }
}