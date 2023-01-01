using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeCurrencyConverter.Models
{
    public class FromCurrency
    {
        public string QuoteCurrency { get; set; }

        public double Mid { get; set; }
        public FromCurrency(string quoteCurrency, double mid)
        {
            QuoteCurrency = quoteCurrency;
            Mid = mid;
        }
    }
}
