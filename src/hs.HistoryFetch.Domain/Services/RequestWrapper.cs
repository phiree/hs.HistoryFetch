using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace hs.HistoryFetch.Services
{
    internal class RequestWrapper
    {
        
        public async  Task<T> Request<T>(string url,dynamic jsonParam) {
            var handler = new HttpClientHandler();
            handler.UseCookies = false;

            // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
            handler.AutomaticDecompression = ~DecompressionMethods.None;

            // In production code, don't destroy the HttpClient through using, but better use IHttpClientFactory factory or at least reuse an existing HttpClient instance
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
            // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://www.pzds.com/api/v2/homepage/public/game/all"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en,zh-CN;q=0.9,zh;q=0.8,zh-TW;q=0.7");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://www.pzds.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://www.pzds.com");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-origin");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("channelInfo", "{\"channelCode\":null,\"tag\":null,\"channelType\":\"\"}");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    request.Headers.TryAddWithoutValidation("token", "076278de312d4603a32673e34bf4201a");
                    request.Headers.TryAddWithoutValidation("Cookie", "UM_distinctid=1867ca4babfc82-08446aef298b67-26031951-1fa400-1867ca4bac0e07; Hm_lvt_947868393d96f11898b790b759dc4b88=1677128416; Hm_lvt_8e2c03f98f8af83cf09317d232baf903=1678173308,1678432304,1678670628,1678680214; CNZZDATA1279695818=1233974175-1677126046-%7C1678685660; Hm_lpvt_8e2c03f98f8af83cf09317d232baf903=1678686247");

                    request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jsonParam));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;charset=UTF-8");

                    var response = await httpClient.SendAsync(request);
                    return await response.Content.ReadFromJsonAsync<T>();
                }
            }
        }
    }
}
