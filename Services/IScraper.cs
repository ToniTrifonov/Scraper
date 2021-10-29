using System.Collections.Generic;

using HtmlAgilityPack;

namespace Scraper.Services
{
    public interface IScraper
    {
        HtmlDocument Load();

        List<Product> Extract(HtmlDocument htmlDocument);

        string JsonSerialize(List<Product> products);
    }
}
