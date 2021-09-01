using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kindergarten_Client.HttpRepository
{
    public class KidHttpRepository : IKidHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public KidHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Kid>> GetKids()
        {
            var response = await _client.GetAsync("kids");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var kids = JsonSerializer.Deserialize<List<Kid>>(content, _options);
            return kids;
        }
    }
}





