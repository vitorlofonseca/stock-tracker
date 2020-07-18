using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using StockTracker.Infra.HttpConsumer.NewsAPI.DTOs;
using StockTracker.Infra.HttpConsumer.SPIs;

namespace StockTracker.Infra.Http.NewsAPI
{
    public class NewsAPI : INewsGetter
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public NewsAPI(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<List<News>> GetNewsByCompany(Company Company)
        {
            var queryString = GetQueryString(Company);

            var response = await _httpClient.GetAsync(queryString);

            response.EnsureSuccessStatusCode();
            var responseContent = response.Content.ReadAsStringAsync().Result;

            var responseDto = JsonConvert.DeserializeObject<NewsAPIResponse>(responseContent);

            return responseDto.articles.Select(oneNewsDto =>
                NewsBuilder.ConstructOne()
                    .WithAuthor(oneNewsDto.author)
                    .WithContent(oneNewsDto.content)
                    .WithDescription(oneNewsDto.description)
                    .WithPublishedAt(oneNewsDto.publishedAt)
                    .WithSource(
                        NewsSourceBuilder.ConstructOne()
                        .WithCode(oneNewsDto.source.id)
                        .WithName(oneNewsDto.source.name)
                    )
                    .WithTitle(oneNewsDto.title)
                    .WithUrl(oneNewsDto.url)
            ).ToList();
        }

        private string GetQueryString(Company Company)
        {
            var companyNameUrlEncoded = Company.Name.Replace(" ", "+");
            var apiKey = _config.GetValue<string>("Apis:NewsAPI:Key");

            //for this moment is here. For the future, it can be on some service, or can come in request body
            var retrieveOptions = new Dictionary<string, string>
            {
                { "from", DateTime.Now.ToString("yyyy-MM-dd") },
                { "sortBy", "popularity" },
                { "category", "business" }
            };

            var retrieveOptionsForUrl = string.Join("&",
                retrieveOptions.Select(retrieveOption => $"{retrieveOption.Key}={retrieveOption.Value}")
            );

            return $"top-headlines?q={companyNameUrlEncoded}&{retrieveOptionsForUrl}&apiKey={apiKey}";
        }
    }
}
