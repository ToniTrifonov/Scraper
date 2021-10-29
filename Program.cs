using System;

using Scraper.Services;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            IScraper scraper = new HtmlScraper();

            var htmlDocument = scraper.Load();

            var products = scraper.Extract(htmlDocument);

            var jsonProducts = scraper.JsonSerialize(products);

            Console.WriteLine(jsonProducts);
        }
    }
}
