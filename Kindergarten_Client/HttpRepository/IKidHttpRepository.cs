using DataAccess.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kindergarten_Client.HttpRepository
{
    public interface IKidHttpRepository
    {
        Task<List<Kid>> GetKids();
    }
}