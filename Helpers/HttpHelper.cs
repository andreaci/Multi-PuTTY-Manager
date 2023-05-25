using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement
{
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new();

        public static async void DownloadFileAsync(string uri, string outputPath)
        {
            if (!Uri.TryCreate(uri, UriKind.Absolute, out _))
                throw new InvalidOperationException("URI is invalid.");

            //if (!File.Exists(outputPath))
            //    throw new FileNotFoundException("File not found.", nameof(outputPath));

            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
            File.WriteAllBytes(outputPath, fileBytes);
        }
    }

}
