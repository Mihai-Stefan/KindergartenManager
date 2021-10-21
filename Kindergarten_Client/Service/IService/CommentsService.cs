using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten_Client.Service.IService
{
    public class CommentsService : ICommentsService
    {
        private readonly HttpClient _client;

        public CommentsService(HttpClient client)
        {
            _client = client;
        }

        // SAVE Comments
        public async Task<KidCommentDTO> SaveComments(KidCommentDTO comments)
        {
            var content = JsonConvert.SerializeObject(comments);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/comment/create", bodyContent);
            //string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<KidCommentDTO>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
