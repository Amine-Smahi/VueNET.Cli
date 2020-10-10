using System.Threading.Tasks;
using ___namespace___.Application.___entity___s.Dtos;
using ___namespace___.Utilities.Collections;

namespace ___namespace___.Application.___entity___s
{
    public interface I___entity___sService
    {
        Task<IPagedList<___entity___ListOutput>> GetAllAsync(___entity___ListInput input);
        Task<___entity___Dto> GetByIdAsync(int id);
        void CreateAsync(___entity___Dto ___entity___);
        void Update(___entity___Dto ___entity___);
        void DeleteAsync(int id);
    }
}