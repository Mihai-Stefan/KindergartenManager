using Kindergarten_Client.Service.IService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kindergarten_Client.Service
{
    public class KgFacilityService : IKgFacilityService
    {

        private readonly HttpClient _client;

        public KgFacilityService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<KgFacilityDTO>> GetKgFacilities()
        {
            var response = await _client.GetAsync($"/api/kgfacility");
            var content = await response.Content.ReadAsStringAsync();
            var facilities = JsonConvert.DeserializeObject<IEnumerable<KgFacilityDTO>>(content);
            return facilities;
        }
    
    }
}
