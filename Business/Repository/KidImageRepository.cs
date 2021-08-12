using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class KidImageRepository : IKidImageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public KidImageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<int> CreateKidImage(KidImageDTO imageDTO)
        {
            var image = _mapper.Map<KidImageDTO, KidImage>(imageDTO);
            await _db.KidImages.AddAsync(image);
            return await _db.SaveChangesAsync();
        }


        public async Task<int> DeleteKidImageByImageId(int imageId)
        {
            var image = await _db.KidImages.FindAsync(imageId);
            _db.KidImages.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public Task<int> DeleteKidImageByImageUrl(string imageUrl)
        {
            throw new NotImplementedException();
        }


        public async Task<int> DeleteKidImageByKidId(int kidId)
        {
            var imageList = await _db.KidImages.Where(x => x.KidId == kidId).ToListAsync();
            _db.KidImages.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<KidImageDTO>> GetKidImages(int kidId)
        {
            return _mapper.Map<IEnumerable<KidImage>, IEnumerable<KidImageDTO>>(
                await _db.KidImages.Where(x => x.KidId == kidId).ToListAsync());

        }
    }
}
