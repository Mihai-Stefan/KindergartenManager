using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ICommentRepository
    {
        public Task<KidCommentDTO> CreateKidComment(KidCommentDTO kidComment);

        public Task<KidCommentDTO> UpdateKidComment(int kidCommentId, KidCommentDTO kidComment);

        public Task<KidCommentDTO> GetKidComment(int kidCommentId);

        public Task<int> DeleteKidComment(int kidCommentId);

        public Task<IEnumerable<KidCommentDTO>> GetAllKidComments();
    }
}
