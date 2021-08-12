using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IKidImageRepository
    {
        public Task<int> CreateKidImage(KidImageDTO image);
        public Task<int> DeleteKidImageByImageId(int imageId);
        public Task<int> DeleteKidImageByKidId(int kidId);
        public Task<int> DeleteKidImageByImageUrl(string imageUrl);
        public Task<IEnumerable<KidImageDTO>> GetKidImages(int kidId);
    }
}
