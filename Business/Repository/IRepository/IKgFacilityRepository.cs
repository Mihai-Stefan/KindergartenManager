using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IKgFacilityRepository
    {
        public Task<KgFacilityDTO> CreateKgFacility(KgFacilityDTO kgFacility);

        public Task<KgFacilityDTO> UpdateKgFacility(int KgFacilityId, KgFacilityDTO kgFacility);

        public Task<KgFacilityDTO> GetKgFacility(int KgFacilityId);

        public Task<int> DeleteKgFacility(int KgFacilityId);

        public Task<IEnumerable<KgFacilityDTO>> GetAllKgFacilities();

        public Task<KgFacilityDTO> IsKgFacilityUnique(string name);
    }
}
