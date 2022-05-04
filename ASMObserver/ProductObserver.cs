using System;

namespace AsmObserver
{
    public abstract class ProductObserver
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public abstract void Update();
    }
}




