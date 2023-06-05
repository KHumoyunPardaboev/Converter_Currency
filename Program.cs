using Newtonsoft.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Converter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bu yerda siz pullaringizni dollar va so'm ko'rinishida hisoblab olishingiz mumkin.");
            Console.ResetColor();
            Console.WriteLine();

            string url = "https://raw.githubusercontent.com/KHumoyunPardaboev/Converter_Currency/main/file%20(1).json";
            HttpClient client = new HttpClient();

            try
            {
                var httpResponse = client.GetAsync(url).Result;
                string json = httpResponse.Content.ReadAsStringAsync().Result;
                var jsonDates = JsonConvert.DeserializeObject<Kurs[]>(json);

                foreach(var item in jsonDates)
                {
                    Console.WriteLine("1$ Dollar narxi: {0} UZB", item.cb_price);         
                    Console.WriteLine("Sotib olish: {0} UZB", item.nbu_buy_price);
                    Console.WriteLine("Sotish: {0} UZB", item.nbu_cell_price);
                    Console.WriteLine("Sana: {0}", item.date);
                    Console.WriteLine();

                    // kiritganimzda Dollarni so'mda hisoblab beradi.
                    int a = (int)11095.31;
                    int b = (int)11410.00;
                    int c = (int)11460.00;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Olmoqchi bo'lgan dollar valyutangizni kiriting!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Kiritilgan USD qiymat: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Dollar narxi: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(x*a);
                    Console.ResetColor();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.Write("Sotib olish: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(x * b) ;
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Sotish: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(x * c);
                    Console.ResetColor();
                    Console.WriteLine() ;

                }
                Console.WriteLine();
                Console.WriteLine("UZB dan USD ga o'tkazish!");
                Console.WriteLine();
                foreach (var item in jsonDates)
                {
                  

                    // kiritganimzda Dollarni so'mda hisoblab beradi.
                    int a = (int)11095.31;
                    int b = (int)11410.00;
                    int c = (int)11460.00;
                    float a1 = 1 / 11095.31f;
                    float a2 = 1 / 11410.00f;
                    float a3 = 1 / 11460.00f;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Olmoqchi bo'lgan summa valyutangizni kiriting!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Kiritilgan UZB qiymat: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Summa: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(y*a1);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Dollar olish: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(y*a2);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Dollarda Sotish: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(y*a3);
                    Console.ResetColor();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }

    public class Kurs
    {
        public string title { get; set; }
        public string code { get; set; }
        public string cb_price { get; set; }
        public string nbu_buy_price { get; set; }
        public string nbu_cell_price { get; set; }
        public string date { get; set; }

    }
}