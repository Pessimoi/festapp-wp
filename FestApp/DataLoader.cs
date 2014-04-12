﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading;

namespace FestApp
{
    public enum LoadSource
    {
        NETWORK,
        CACHE
    }

    public class DataLoader
    {
        public async Task<BitmapImage> LoadImage(string path, CancellationToken? ct = null)
        {
            string url = Config.ServerUrl + path;
            WebRequest req = WebRequest.CreateHttp(url);

            return null;
            /*using (var response = await req.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            {
                MemoryStream memStream = new MemoryStream();
                if (ct.HasValue)
                {
                    await stream.CopyToAsync(memStream, 4096, ct.Value);
                }
                else
                {
                    await stream.CopyToAsync(memStream);
                }
                memStream.Seek(0, SeekOrigin.Begin);

                BitmapImage bitmapImage = new BitmapImage() { CreateOptions = BitmapCreateOptions.BackgroundCreation };
                bitmapImage.SetSource(memStream);
                return bitmapImage;
            }*/
        }

        public async Task<T> Load<T>(string apiPath, LoadSource source)
        {
            switch (source)
            {
                case LoadSource.NETWORK:
                    return await LoadFromNet<T>(apiPath) ;
                case LoadSource.CACHE:
                    return await LoadFromCache<T>(apiPath);
                default:
                    throw new Exception("Unknown source");
            }
        }

        public async Task<T> LoadFromCache<T>(string apiPath)
        {
            var cachedResource = Application.GetResourceStream(new Uri("Cache/" + apiPath, UriKind.Relative));
            using (StreamReader reader = new StreamReader(cachedResource.Stream))
            {
                string json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public async Task<T> LoadFromNet<T>(string apiPath)
        {
            return default(T);
            /*
            string url = Config.ServerUrl + "api/" + apiPath;
            WebRequest req = WebRequest.CreateHttp(url);
            using (WebResponse response = await req.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                var serializer = JsonSerializer.CreateDefault();
                return serializer.Deserialize<T>(jsonReader);
            }
             * */
        }

        void web_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void test(object sender, OpenReadCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
