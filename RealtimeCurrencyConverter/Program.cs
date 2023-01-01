using RealtimeCurrencyConverter;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string[] arr = new[]
        {
            "USD/ILS",
            "GBP/EUR",
            "EUR/JPY",
            "EUR/USD"
        };

        BL bL = new(arr);

        var reusultConvertsList = bL.BuildReusultConverts();
        var linesOfDataList = bL.AddResultConverts(reusultConvertsList);

        MainDataFlow(linesOfDataList);

        static async Task MainDataFlow(List<string> linesOfDataList)
        {
            var buffer = new BufferBlock<string>();

            string filePath = @"../../../../CurrencyDataSaved.txt";
            if (File.Exists(filePath))
            {
                using StreamWriter file = new(filePath, append: true);
                for (int i = 0; i < linesOfDataList.Count; i++)
                {
                    if (i == 0)
                    {
                        await file.WriteLineAsync("");
                        await file.WriteLineAsync(linesOfDataList[i]);
                    }
                    else
                    {
                        await file.WriteLineAsync(linesOfDataList[i]);
                    }
                }
                buffer.Post(filePath);
            }
            else
            {
                await File.WriteAllLinesAsync(filePath, linesOfDataList);
                buffer.Post(filePath);
            }

            while (buffer.Count != 0)
            {
                string text = File.ReadAllText(@"../../../../CurrencyDataSaved.txt");
                Console.WriteLine(text);
                await buffer.ReceiveAsync();
            }
        }
    }
}



