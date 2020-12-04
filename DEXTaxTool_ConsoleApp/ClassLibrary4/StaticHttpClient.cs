using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StaticHttpClient
{
    public static class HTTPClientProvider
    {
        public static HttpClient httpClient { get; }
        static HTTPClientProvider()
        {
            httpClient = new HttpClient();
        }
    }
}
