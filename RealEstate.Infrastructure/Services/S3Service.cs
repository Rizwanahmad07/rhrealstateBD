using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Interfaces;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:S3BucketName"];
        }

        public async Task<string> UploadBase64ImageAsync(string base64String, string folderName = "projects")
        {
            if (string.IsNullOrEmpty(base64String))
                return base64String;

            // If it's already a URL, just return it
            if (base64String.StartsWith("http://") || base64String.StartsWith("https://"))
                return base64String;

            // Extract base64 data and mime type
            var match = Regex.Match(base64String, @"data:(?<type>.+?);base64,(?<data>.+)");
            if (!match.Success)
            {
                // Not a valid base64 data URI, return as-is
                return base64String;
            }

            var base64Data = match.Groups["data"].Value;
            var contentType = match.Groups["type"].Value;

            // Determine extension from content type
            var ext = contentType switch
            {
                "image/jpeg" => ".jpg",
                "image/png" => ".png",
                "image/gif" => ".gif",
                "image/svg+xml" => ".svg",
                "image/webp" => ".webp",
                _ => ".jpg"
            };

            var fileName = $"{folderName}/{Guid.NewGuid()}{ext}";
            byte[] bytes = Convert.FromBase64String(base64Data);

            using var memoryStream = new MemoryStream(bytes);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = memoryStream,
                Key = fileName,
                BucketName = _bucketName,
                ContentType = contentType
                // Note: To make public, CannedACL = S3CannedACL.PublicRead (but depends on bucket policy)
            };

            using var transferUtility = new TransferUtility(_s3Client);
            await transferUtility.UploadAsync(uploadRequest);

            // Construct the public URL
            var bucketRegion = _s3Client.Config.RegionEndpoint.SystemName;
            return $"https://{_bucketName}.s3.{bucketRegion}.amazonaws.com/{fileName}";
        }
    }
}
