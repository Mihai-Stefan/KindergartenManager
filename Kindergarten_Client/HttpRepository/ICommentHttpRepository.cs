using DatabaseAccess.Data;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kindergarten_Client.HttpRepository
{
    public interface ICommentHttpRepository
    {
        Task<List<KidComment>> GetComments();


        public Task<KidCommentDTO> CreateKidComment(KidCommentDTO kidCommentDTO);

        public Task<KidCommentDTO> UpdateKidComment(int kidCommentId, KidCommentDTO kidCommentDTO);

        public Task<KidCommentDTO> GetKidComment(int kidCommentId);


        public Task<int> DeleteKidComment(int kidCommentId);

    }
}
