using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IKidRepository
    {
        public Task<KidDTO> CreateKid(KidDTO kidDTO);

        public Task<KidDTO> UpdateKid(int kidId,KidDTO kidDTO);

        public Task<KidDTO> GetKid(int kidId);

        public Task<int> DeleteKid(int kidId);

        public Task<IEnumerable<KidDTO>> GetAllKids();

        public Task<KidDTO> IsKidUnique(string name, int kidId=0);
    }
}
