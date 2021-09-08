using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Client.Service.IService
{
    public interface IKgFacilityService
    {
        public Task<IEnumerable<KgFacilityDTO>> GetKgFacilities();
    }
}
