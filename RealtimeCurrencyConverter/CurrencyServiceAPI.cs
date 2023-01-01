using Newtonsoft.Json;
using RealtimeCurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealtimeCurrencyConverter
{
    public class CurrencyServiceAPI
    {
        public ToCurrency ConvertCur(string fromCurrency, string toCurrency, double fromCurrencyAmount)
        {


            var responseContent = GetResponseString($"convert_to.json/?to={toCurrency}&from={fromCurrency}&amount={fromCurrencyAmount}");
            return JsonConvert.DeserializeObject<ToCurrency>(responseContent);
        }

        private string GetResponseString(string relativeURI)
        {

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://xecdapi.xe.com/v1/{relativeURI}");
            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("cellcom135900074:hgpolir0v4ve40ure6dkmg4k5h"));
            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
            var response = httpClient.Send(request);
            return response.Content.ReadAsStringAsync().Result;

        }
    }
}
