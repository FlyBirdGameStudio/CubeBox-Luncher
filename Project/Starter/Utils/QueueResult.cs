using BoardServer.AppBasic.Models.SizeUtils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Utils
{
    class QueueResult
    {
        private readonly WebClient client = new WebClient();
        private byte[] Result;
        private readonly string url;

        public QueueResult(string url)
        {
            this.url = url;
        }

        public void Queue()
        {//Gzip.CompressBytes
            Result = (client.DownloadData(url));
            client.Dispose();
        }

        public string GetResult()
        {//Gzip.Decompress Gzip.Decompress
            return Encoding.UTF8.GetString((Result));
        }

        public void Clear()
        {
            Result = null;
        }
    }
}
