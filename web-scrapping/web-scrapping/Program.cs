using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace web_scrapping
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://turbo.az/");
            var models = document.DocumentNode.SelectNodes("//div[@class='products-i__name products-i__bottom-text']");
            var prices = document.DocumentNode.SelectNodes("//div[@class='product-price']");
            foreach (var model in models)
            { Console.WriteLine(model.InnerText + '-' + prices[models.IndexOf(model)].InnerText); }
        }
    }
}
