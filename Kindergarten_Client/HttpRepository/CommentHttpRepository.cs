using DatabaseAccess.Data;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kindergarten_Client.HttpRepository
{
    public class CommentHttpRepository : ICommentHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CommentHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        // Create comment:
        public async Task<KidCommentDTO> CreateKidComment(KidCommentDTO kidCommentDTO)
        {
            var content = JsonConvert.SerializeObject(kidCommentDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"comment/", bodyContent);

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



        // Unnecessary - test purposes only
        public async Task<List<KidComment>> GetComments()
        {
            var response = await _client.GetAsync("comment");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var comments = System.Text.Json.JsonSerializer.Deserialize<List<KidComment>>(content, _options);
            return comments;
        }


        public Task<KidCommentDTO> GetKidComment(int kidCommentId)
        {
            throw new NotImplementedException();
        }

        public Task<KidCommentDTO> UpdateKidComment(int kidCommentId, KidCommentDTO kidCommentDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteKidComment(int kidCommentId)
        {
            var commentDetails = await _client.DeleteAsync($"comment/{kidCommentId}");

            return 0;
        }

    }
}
