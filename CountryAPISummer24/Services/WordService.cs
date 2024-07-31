using CountryAPISummer24.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryAPISummer24.Services
{
    public class WordService : IWordService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CountryService> _logger;

        public WordService(IHttpClientFactory httpClientFactory, ILogger<CountryService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<Words>> GetWordsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("WordsAPI");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://wordsapiv1.p.rapidapi.com/words/%7Bword%7D"),
                    Headers =
                        {
                            { "x-rapidapi-key", "e20dc61db7msh483d5e5850018dfp149d7ejsn99eafc3e89fd" },
                            { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
                        },
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(jsonString);
                var wordsObject = jObject["words"] as JObject;

                if (wordsObject == null)
                {
                    throw new JsonException("Unexpected JSON structure: 'wodrs' property not found or not an object");
                }

                var words = wordsObject.Properties()
                    .Select(p => new Words {Word = p.Value.ToString() })
                    .ToList();

                return words;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Error fetching words from API");
                throw;
            }
            catch (JsonException e)
            {
                _logger.LogError(e, "Error deserializing API response");
                throw;
            }
        }

    }
}

