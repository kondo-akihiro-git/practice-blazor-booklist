using System;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Azure;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using EllipticCurve.Utils;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Regex reg1 = new Regex(".*[:]");
            //var client = new HttpClient();
            //var client = HttpGetAttribute();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://api.pwnedpasswords.com/range/5baa6").Result;
            //var responseB = client.GetFromJsonAsync("https://api.pwnedpasswords.com/range/5baa6").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            
            result = reg1.Replace(result, "");

            //int length = result.Length();
            var wordList = result.Replace("\r\n", "\n").Split(new[] { '\n', '\r' });
            //配列の要素数の回数だけループ

            int sum = 0;
            int b = wordList.Length;
            //int number = Integer.(wordList);
            for (int i = 0; i < b; i++)
            {
                //配列の要素を変数に足す

                sum += int.Parse(wordList[i]);
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                hash = sum.ToString(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            })
            .ToArray();
        }

        public string GetHash()
        {
            using HashAlgorithm hashProvider = SHA1.Create();
            //byte hash;
            var use = User.FindFirstValue(ClaimTypes.NameIdentifier);
            byte[] str = Encoding.UTF8.GetBytes(use.ToString());
            byte[] hashByte = hashProvider.ComputeHash(str);
            string hash = string.Join("", hashByte);
            hash = hash.Substring(0, 5);
            //hashByte.;
            return hash;
        }
            
    }
}