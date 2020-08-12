using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly IOptions<BlobDetails> config;
        private readonly IConfiguration configuration;

        public BlobStorageController(IOptions<BlobDetails> _config, IConfiguration _configuration)
        {
            this.config = _config;
            this.configuration = _configuration;
        }

        [HttpGet("ListFiles")]
        public async Task<List<string>> ListFiles()
        {
            string BlobConnectionString = configuration.GetConnectionString("BlobStorageCS");
            string ContainerConnectionString = configuration.GetConnectionString("Container");

            List<string> blobs = new List<string>();
            try
            {
                if (CloudStorageAccount.TryParse(BlobConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(ContainerConnectionString);

                    BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null);
                    foreach (IListBlobItem item in resultSegment.Results)
                    {
                        if (item.GetType() == typeof(CloudBlockBlob))
                        {
                            CloudBlockBlob blob = (CloudBlockBlob)item;
                            blobs.Add(blob.Name);
                        }
                        else if (item.GetType() == typeof(CloudPageBlob))
                        {
                            CloudPageBlob blob = (CloudPageBlob)item;
                            blobs.Add(blob.Name);
                        }
                        else if (item.GetType() == typeof(CloudBlobDirectory))
                        {
                            CloudBlobDirectory dir = (CloudBlobDirectory)item;
                            blobs.Add(dir.Uri.ToString());
                        }
                    }
                }
            }
            catch
            {
            }
            return blobs;
        }

        [HttpPost("InsertFile")]
        public async Task<bool> InsertFile(IFormFile asset)
        {
            string BlobConnectionString = configuration.GetConnectionString("BlobStorageCS");
            string ContainerConnectionString = configuration.GetConnectionString("Container");
            try
            {
                if (CloudStorageAccount.TryParse(BlobConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(ContainerConnectionString);

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(asset.FileName);

                    await blockBlob.UploadFromStreamAsync(asset.OpenReadStream());

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        [Route("DeleteFile/{fileName}")]
        [HttpGet]
        public async Task<bool> DeleteFile(string fileName)
        {
            string BlobConnectionString = configuration.GetConnectionString("BlobStorageCS");
            string ContainerConnectionString = configuration.GetConnectionString("Container");
            try
            {
                if (CloudStorageAccount.TryParse(BlobConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = BlobClient.GetContainerReference(ContainerConnectionString);

                    if (await container.ExistsAsync())
                    {
                        CloudBlob file = container.GetBlobReference(fileName);

                        if (await file.ExistsAsync())
                        {
                            await file.DeleteAsync();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

