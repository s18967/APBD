using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var URL = Console.ReadLine();

            var httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync(URL);

            //var content = string.Join(',', ExtractEmail(result));

            Console.WriteLine(result);
        }
        //public static string[] ExtractEmail(String str)
        //{
           // string regexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";
            //System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.MatchCollecti
            //return list;

        //}

    }
}
