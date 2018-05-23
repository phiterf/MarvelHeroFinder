using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;

namespace TesteAcerto.Utils
{
    public static class MarvelAPI
    {
        public static String GerarHash(String ts)
        {
            return Hash.GenerateMD5(ts + GetPrivateKey + GetPublicKey);
        }

        public static String BaseURL = "http://gateway.marvel.com/v1/public";
        public static String GetPublicKey => ConfigurationManager.AppSettings["marvel_public_key"];
        public static String GetPrivateKey => ConfigurationManager.AppSettings["marvel_private_key"];

        public static String _ts => DateTime.Now.ToString("yyyyMMddHHmmss");


        public static dynamic Call(String url, List<GetParam> @params)
        {
            var getParams = @params.Select((p) => p.QueryString).ToList();
            var ts = _ts;
            getParams.Add(new GetParam("ts", ts).QueryString);
            getParams.Add(new GetParam("apikey", GetPublicKey).QueryString);
            getParams.Add(new GetParam("hash", GerarHash(ts)).QueryString);

            var qs = string.Join("&", getParams);
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(BaseURL + url + "?" + qs).Result;
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                }

                string content = response.Content.ReadAsStringAsync().Result;


                return JsonConvert.DeserializeObject(content);
            }
        }
    }
}