using System;

namespace BasicLearning
{
    public class SimpleFactory
    {
        public static Product CreateProduct(string type)
        {
            Product product;
            switch (type)
            {
                case "1":
                    product = new Product1();
                    break;
                case "2":
                    product = new Product2();
                    break;
                default:
                    product = null;
                    break;
            }
            return product;
        }
    }

    public abstract class Product
    {
        public abstract void AbstractFun();
    }

    public class Product1:Product
    {
        public override void AbstractFun()
        {
            Console.WriteLine("执行 Product1 AbstractFun");
        }
    }

    public class Product2:Product
    {
        public override void AbstractFun()
        {
            Console.WriteLine("执行 Product2 AbstractFun");
        }
    }
}