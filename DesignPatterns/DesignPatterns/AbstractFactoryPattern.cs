using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// The abstract factory pattern "Provide an interface for creating families of related or dependent objects without specifying their concrete classes".
    /// </summary>
    public class AbstractFactoryPattern : IPattern
    {

        Dictionary<Cloud, IAbstractCloudServiceFactory> _subscriptions = new Dictionary<Cloud, IAbstractCloudServiceFactory>() {
            { Cloud.Azure, new AzureCloudServiceFactory()},
            { Cloud.Aws, new AwsCloudServiceFactory() }
        };

        public void Execute(Cloud cloud)
        {
            Console.WriteLine("Executing Astract Factory Pattern...");
            IAbstractCloudServiceFactory abstractCloudServiceFactory;

            if (_subscriptions.TryGetValue(cloud, out abstractCloudServiceFactory))
            {
                Console.WriteLine($"You have choosen {abstractCloudServiceFactory.GetType().Name}");
                Console.WriteLine($"Your Serverless service is: { abstractCloudServiceFactory.GetServerlessProduct().GetServiceName()}");
                Console.WriteLine($"Your Storage service is: { abstractCloudServiceFactory.GetStorageProduct().GetServiceName()}");
            }
            else
            {
                Console.WriteLine("No Data available...");
            }
        }
    }

    public interface IAbstractCloudServiceFactory
    {
        IServerlessProductService GetServerlessProduct();
        IStorageProductService GetStorageProduct();
    }

    public class AzureCloudServiceFactory : IAbstractCloudServiceFactory
    {
        public IServerlessProductService GetServerlessProduct()
        {
            return new AzureServerlessProductService();
        }

        public IStorageProductService GetStorageProduct()
        {
            return new AzureStorageProductService();
        }
    }

    public class AwsCloudServiceFactory : IAbstractCloudServiceFactory
    {
        public IServerlessProductService GetServerlessProduct()
        {
            return new AwsServerlessProductService();
        }

        public IStorageProductService GetStorageProduct()
        {
            return new AwsStorageProductService();
        }
    }

    public interface IServerlessProductService
    {
        string GetServiceName();
    }

    public interface IStorageProductService
    {
        string GetServiceName();
    }

    public class AzureServerlessProductService : IServerlessProductService
    {
        public string GetServiceName()
        {
            return "Azure Functions...";
        }
    }

    public class AwsServerlessProductService : IServerlessProductService
    {
        public string GetServiceName()
        {
            return "Lambda Functions...";
        }
    }

    public class AzureStorageProductService : IStorageProductService
    {
        public string GetServiceName()
        {
            return "Blob Storage...";
        }
    }

    public class AwsStorageProductService : IStorageProductService
    {
        public string GetServiceName()
        {
            return "S3...";
        }
    }
}
