using System.Net;

var proxyAddress = "178.48.68.61:18080"; // Sopron

var httpClientHandler = new HttpClientHandler
{
    Proxy = new WebProxy(proxyAddress, true),
    UseProxy = true,
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
};

using var httpClient = new HttpClient(httpClientHandler)
{
    Timeout = TimeSpan.FromSeconds(120)
};
var response = await httpClient.GetStringAsync("https://browserleaks.com/ip");
var cityPattern = "<tr><td>City</td><td>";
var index = response.IndexOf(cityPattern) + cityPattern.Length;
Console.WriteLine($"City: {response.Substring(index, 30)}");
Console.ReadKey();