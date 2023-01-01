using RealtimeCurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeCurrencyConverter
{
    public class BL
    {
        string[] ConversionPairs { get; set; }

        List<ToCurrency> ReusultConverts { get; set; }

        List<string> LinesDataAddToFile { get; set; }

        CurrencyServiceAPI currencyServiceAPI = new();

        public BL(string[] conversionPairs)
        {
            ConversionPairs = conversionPairs;
            ReusultConverts = new List<ToCurrency>();
            LinesDataAddToFile = new List<string>();
        }

        public List<ToCurrency> BuildReusultConverts()
        {
            for (int i = 0; i < ConversionPairs.Length; i++)
            {
                string[] temp = ConversionPairs[i].Split("/");
                ReusultConverts.Add(currencyServiceAPI.ConvertCur(temp[0], temp[1], 1));
            }
            return ReusultConverts;
        }

        public List<string> AddResultConverts(List<ToCurrency> dataToConvert)
        {
            for (int i = 0; i < dataToConvert.Count; i++)
            {
                string to = dataToConvert[i].To;
                string timeStamp = dataToConvert[i].Timestamp.ToString();
                FromCurrency result = dataToConvert[i].From[0];
                string from = result.QuoteCurrency;
                double mid = result.Mid;
                var lineData = $"{from}/{to} {mid} {timeStamp}";
                LinesDataAddToFile.Add(lineData);
            }
            return LinesDataAddToFile;
        }
    }
}
