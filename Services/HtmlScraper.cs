using System;
using System.Collections.Generic;
using System.Net;

using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Scraper.Services
{
    public class HtmlScraper : IScraper
    {
        public List<Product> Extract(HtmlDocument htmlDocument)
        {
            var products = new List<Product>();

            var productNames = htmlDocument.DocumentNode.SelectNodes("//figure/a/img");
            var ratings = htmlDocument.DocumentNode.SelectNodes("//div[@class='item']");
            var prices = htmlDocument.DocumentNode.SelectNodes("//span[@class='price-display formatted']/span[contains(@style, 'none')]");

            var productsCount = productNames.Count;

            for (int i = 0; i < productsCount; i++)
            {
                var decodedProductName = WebUtility.HtmlDecode(productNames[i].GetAttributeValue("alt", string.Empty));
                var ratingValue = ratings[i].GetAttributeValue("rating", (decimal)0.0);
                var priceValue = prices[i].InnerText.Substring(1);

                if (ratingValue > (decimal)5.00)
                {
                    ratingValue = Math.Round((ratingValue / 10) * 5, 1);
                }

                var newProduct = new Product(decodedProductName, priceValue, ratingValue);

                products.Add(newProduct);
            }

            return products;
        }

        public string JsonSerialize(List<Product> products)
        {
            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public HtmlDocument Load()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("../../../Resources/HtmlExcerpt.html");

            return htmlDocument;
        }
    }
}
