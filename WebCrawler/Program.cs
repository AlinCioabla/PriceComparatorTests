using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace WebCrawler
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();

			for (var i = 1; i <= 50; i++)
			{
				string url;
				if(i == 1)
				{
					url = $"https://www.emag.ro/telefoane-mobile/c";
				} else
				{
					url = $"https://www.emag.ro/telefoane-mobile/p{i}/c";
				}
			https://www.youtube.com/watch?v=xq5H1cJ-1iw&fbclid=IwAR2VK4S0BmIBwFMhcycwD06d6-upj7ylHmKHsZV9oXL2fhzC1NGW6eA8Ewg&ab_channel=FloareaDragomirFLORICICADANSATOAREAOFICIAL

				HtmlWeb web = new HtmlWeb();

				var htmlDoc = web.Load(url);
				var productNodes = htmlDoc.DocumentNode
					.SelectNodes("//div[@id='card_grid']").Descendants();

				foreach (var productNode in productNodes)
				{
					var productName = productNode.SelectSingleNode("//a[contains(@class, 'product-title')]").InnerText.Trim().Replace("\n", "");
					var currentprice = productNode.SelectSingleNode("//p[contains(@class,'product-new-price')]").FirstChild.InnerText.Replace("&#46;", ".");

					Console.WriteLine($"{productName}: {currentprice}");
					break;
				}

				//Thread.Sleep(1000);
			}

			sw.Stop();

			Console.WriteLine("Elapsed={0}", sw.Elapsed);
		}
	}
}
