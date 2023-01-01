using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeCurrencyConverter.Models
{
    public class ToCurrency
    {
        public ToCurrency(string terms, string privacy, FromCurrency[] from, double amount, DateTime timestamp, string to)
        {
            Terms = terms;
            Privacy = privacy;
            From = from;
            Amount = amount;
            Timestamp = timestamp;
            To = to;
        }

        public string Terms { get; set; }
        public string Privacy { get; set; }
        public FromCurrency[] From { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string To { get; set; }
    }
}
