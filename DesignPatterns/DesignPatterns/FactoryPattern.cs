using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// The factory pattern "Define an interface for creating an object, but let the subclasses decide which class to instantiate. 
    /// The Factory method lets a class defer instantiation to subclasses".
    /// </summary>
    public class FactoryPattern : IPattern
    {
        Dictionary<Cloud, CloudSubscription> _subscriptions = new Dictionary<Cloud, CloudSubscription>() {
            { Cloud.Azure, new AzureCloud()},
            { Cloud.Aws, new AwsCloud() }
        };

        public void Execute(Cloud cloud)
        {
            Console.WriteLine("Executing Factory Pattern...");
            CloudSubscription cloudSubscription;

            if(_subscriptions.TryGetValue(cloud, out cloudSubscription))
            {
                Console.WriteLine("Subscribing to Top Cloud...");
                Console.WriteLine($"And Its name is {cloudSubscription.GetName()}");
            }
            else
            {
                Console.WriteLine("No Data available...");
            }
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

    public class AwsCloud : CloudSubscription
    {
        public override IProduct FactoryMethod()
        {
            return new ProductAws();
        }
    }

    public class AzureCloud : CloudSubscription
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
