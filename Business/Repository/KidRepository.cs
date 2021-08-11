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
    public class KidRepository : IKidRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public KidRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<KidDTO> CreateKid(KidDTO kidDTO)
        {
            Kid kid = _mapper.Map<KidDTO, Kid>(kidDTO);
            kid.CreatedDate = DateTime.Now;
            kid.CreatedBy = "whhen we will have users";
            var addedKid = await _db.Kids.AddAsync(kid);
            await _db.SaveChangesAsync();
            return _mapper.Map<Kid, KidDTO>(addedKid.Entity);
        }

        public async Task<IEnumerable<KidDTO>> GetAllKids()
        {
            try
            {
                IEnumerable<KidDTO> kidDTOs = 
                    _mapper.Map<IEnumerable<Kid>, IEnumerable<KidDTO>>(_db.Kids);

                return kidDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<KidDTO> GetKid(int kidId)
        {
            try
            {
                KidDTO kid = _mapper.Map<Kid,KidDTO>(
                    await _db.Kids.FirstOrDefaultAsync(x => x.Id == kidId));

                return kid;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }


        // if unique returns null else returns the kid object
        public async Task<KidDTO> IsKidUnique(string fullName)
        {
            try
            {
                KidDTO kid = _mapper.Map<Kid, KidDTO>(
                    await _db.Kids.FirstOrDefaultAsync(x => x.FirstName.ToLower() + " " + x.LastName.ToLower() == fullName.ToLower()));

                return kid;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<KidDTO> UpdateKid(int kidId, KidDTO kidDTO)
        {
            try
            {
                if (kidId == kidDTO.Id)
                {
                    // valid kid
                    Kid kidDetails = await _db.Kids.FindAsync(kidId);
                    // do the mapping:
                    Kid kid = _mapper.Map<KidDTO, Kid>(kidDTO, kidDetails);
                    kid.UpdatedBy = "";
                    kid.UpdatedDate = DateTime.Now;
                    var updatedKid = _db.Kids.Update(kid);
                    await _db.SaveChangesAsync();
                    // map again to Kid.DTO:
                    return _mapper.Map<Kid, KidDTO>(updatedKid.Entity);

                }
                else
                {
                    // invalid
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // we return how many kids are deleted
        public async Task<int> DeleteKid(int kidId)
        {
            var kidDetails = await _db.Kids.FindAsync(kidId);
            if (kidDetails != null)
            {
                _db.Kids.Remove(kidDetails);
                return await _db.SaveChangesAsync();

            }
            return 0;
        }
    }
}
