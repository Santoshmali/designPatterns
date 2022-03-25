using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class StrategyPattern
    {
    }

    public interface ICloudStorageService
    {
        void SaveFile(FileStream fileStream);
    }

    public class AzureCloudStorageService : ICloudStorageService
    {
        public void SaveFile(FileStream fileStream)
        {
            //Use Azure Blob Storage
        }
    }

    public class AwsCloudStorageService : ICloudStorageService
    {
        public void SaveFile(FileStream fileStream)
        {
            //Use Aws S3
        }
    }

    public class GcpCloudStorageService : ICloudStorageService
    {
        public void SaveFile(FileStream fileStream)
        {
            //Use Google Cloud Storage
        }
    }

    public class CloudStorage
    {
        private readonly ICloudStorageService _cloudStorageService;
        public CloudStorage(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        public void SaveFile(FileStream fileStream)
        {
            _cloudStorageService.SaveFile(fileStream);
        }
    }
}
