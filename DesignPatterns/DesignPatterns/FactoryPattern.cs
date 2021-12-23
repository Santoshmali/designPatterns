using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// The factory pattern "Define an interface for creating an object, 
    /// but let the subclasses decide which class to instantiate. 
    /// The Factory method lets a class defer instantiation to subclasses".
    /// </summary>
    public class FactoryPattern : IPattern
    {
        public void Execute()
        {
            Console.WriteLine("Executing Factory Pattern...");

            CloudSubscription cloudSubscription;
            Console.WriteLine("Subscribing to Top Cloud...");
            cloudSubscription = new TopCloud();
            Console.WriteLine($"And Its name is {cloudSubscription.GetName()}");
        }

        public void ProcessSubscription()
        {
            
        }
    }

    /// <summary>
    /// This class Define an interface i.e. "Factory Method" for creating an object, but allow subclasses to decide which class to instantiate
    /// </summary>
    public abstract class CloudSubscription
    {
        public string GetName()
        {
            return FactoryMethod().GetMySubscriptionName();
        }
        public abstract IProduct FactoryMethod();
    }

    public class TopCloud : CloudSubscription
    {
        public override IProduct FactoryMethod()
        {
            return new ProductAws();
        }
    }

    public class YouLiked : CloudSubscription
    {
        public override IProduct FactoryMethod()
        {
            return new ProductAzure();
        }
    }

    public interface IProduct
    {
        string GetMySubscriptionName();
    }

    public class ProductAzure : IProduct
    {
        public string GetMySubscriptionName()
        {
            return "Its Azure...";
        }
    }

    public class ProductAws : IProduct
    {
        public string GetMySubscriptionName()
        {
            return "Its AWS...";
        }
    }
}
