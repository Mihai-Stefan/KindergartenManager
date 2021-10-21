using DatabaseAccess.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Models;

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


        public Task<KidCommentDTO> CreateKidComment(KidCommentDTO kidCommentDTO)
        {
            throw new NotImplementedException();
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

            var comments = JsonSerializer.Deserialize<List<KidComment>>(content, _options);
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
            //var commentDetails = await _db.Comments.FindAsync(kidComment);
            //if (commentDetails != null)
            //{
            //    _db.Comments.Remove(commentDetails);
            //    return await _db.SaveChangesAsync();

            //}
            return 0;
        }

    }
}
