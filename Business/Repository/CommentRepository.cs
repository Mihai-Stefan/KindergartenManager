using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DatabaseAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<KidCommentDTO> CreateKidComment(KidCommentDTO kidComment)
        {
            var comment = _mapper.Map<KidCommentDTO, KidComment>(kidComment);
            comment.CreatedBy = "";
            comment.CreatedDate = DateTime.UtcNow;
            var addedKidComment = await _context.KidComments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return _mapper.Map<KidComment, KidCommentDTO>(addedKidComment.Entity);
        }


        public async Task<int> DeleteKidComment(int kidCommentId)
        {
            var commentDetails = await _context.KidComments.FindAsync(kidCommentId);
            if (commentDetails != null)
            {
                _context.KidComments.Remove(commentDetails);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }


        public async Task<IEnumerable<KidCommentDTO>> GetAllKidComments()
        {
            return _mapper.Map<IEnumerable<KidComment>, IEnumerable<KidCommentDTO>>(await _context.KidComments.ToListAsync());
        }


        public async Task<KidCommentDTO> GetKidComment(int kidCommentId)
        {
            var commentData = await _context.KidComments
                .FirstOrDefaultAsync(x => x.Id == kidCommentId);

            if (commentData == null)
            {
                return null;
            }
            return _mapper.Map<KidComment, KidCommentDTO>(commentData);
        }


        public async Task<KidCommentDTO> UpdateKidComment(int kidCommentId, KidCommentDTO kidComment)
        {
            var commentDetails = await _context.KidComments.FindAsync(kidCommentId);
            var comment = _mapper.Map<KidCommentDTO, KidComment>(kidComment, commentDetails);
            comment.UpdatedBy = "";
            comment.UpdatedDate = DateTime.UtcNow;
            var updatedComment = _context.KidComments.Update(comment);
            await _context.SaveChangesAsync();
            return _mapper.Map<KidComment, KidCommentDTO>(updatedComment.Entity);
        }
    }
}
