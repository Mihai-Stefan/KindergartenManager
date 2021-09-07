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
    public class KgFacilityRepository : IKgFacilityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public KgFacilityRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<KgFacilityDTO> CreateKgFacility(KgFacilityDTO kgFacility)
        {
            var facility = _mapper.Map<KgFacilityDTO, KgFacility>(kgFacility);
            facility.CreatedBy = "";
            facility.CreatedDate = DateTime.UtcNow;
            var addedKgFacility = await _context.KgFacilities.AddAsync(facility);
            await _context.SaveChangesAsync();
            return _mapper.Map<KgFacility, KgFacilityDTO>(addedKgFacility.Entity);
        }


        public Task<int> DeleteKgFacility(int KgFacilityId)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<KgFacilityDTO>> GetAllKgFacilitys()
        {
            return _mapper.Map<IEnumerable<KgFacility>, IEnumerable<KgFacilityDTO>>(await _context.KgFacilities.ToListAsync());
        }


        public async Task<KgFacilityDTO> GetKgFacility(int kgFacilityId)
        {
            var facilityData = await _context.KgFacilities
                .FirstOrDefaultAsync(x => x.Id == kgFacilityId);

            if (facilityData == null)
            {
                return null;
            }
            return _mapper.Map<KgFacility, KgFacilityDTO>(facilityData);
        }


        public async Task<KgFacilityDTO> IsKgFacilityUnique(string name)
        {
            try
            {
                var facilityDetails =
                    await _context.KgFacilities.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim()
                    );
                return _mapper.Map<KgFacility, KgFacilityDTO>(facilityDetails);
            }
            catch (Exception ex)
            {

            }
            return new KgFacilityDTO();
        }


        public async Task<KgFacilityDTO> UpdateKgFacility(int kgFacilityId, KgFacilityDTO kgFacility)
        {
            var facilityDetails = await _context.KgFacilities.FindAsync(kgFacilityId);
            var facility = _mapper.Map<KgFacilityDTO, KgFacility>(kgFacility, facilityDetails);
            facility.UpdatedBy = "";
            facility.UpdatedDate = DateTime.UtcNow;
            var updatedFacility = _context.KgFacilities.Update(facility);
            await _context.SaveChangesAsync();
            return _mapper.Map<KgFacility, KgFacilityDTO>(updatedFacility.Entity);
        }


        public async Task<int> DeleteKgFacility(int facilityId, string userId)
        {
            var facilityDetails = await _context.KgFacilities.FindAsync(facilityId);
            if (facilityDetails != null)
            {
                _context.KgFacilities.Remove(facilityDetails);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
