using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ___namespace___.Application.___entity___s.Dtos;
using ___namespace___.Core;
using ___namespace___.Persistence;
using ___namespace___.Utilities.Collections;
using ___namespace___.Utilities.Extensions.Collections;
using ___namespace___.Utilities.Extensions.PrimitiveTypes;

namespace ___namespace___.Application.___entity___s
{
    public class ___entity___sService : I___entity___sService
    {
        private readonly IMapper _mapper;
        private readonly ___namespace___DbContext _dbContext;

        public ___entity___sService(IMapper mapper, ___namespace___DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IPagedList<___entity___ListOutput>> GetAllAsync(___entity___ListInput input)
        {
            var query = _dbContext.___entity___s.Where(
                    !input.Filter.IsNullOrEmpty(),
                    predicate => predicate.___sort___.Contains(input.Filter) ||
                                 predicate.Desciption.Contains(input.Filter))
                .OrderBy(string.IsNullOrEmpty(input.SortBy) ? "___sort___" : input.SortBy);
            var ___entity___sCount = await query.CountAsync();
            var ___entity___s = query.PagedBy(input.PageIndex, input.PageSize).ToList();
            var userListOutput = _mapper.Map<List<___entity___ListOutput>>(___entity___s);

            return userListOutput.ToPagedList(___entity___sCount);
        }

        public async Task<___entity___Dto> GetByIdAsync(int id)
        {
            var ___entity___ = await _dbContext.___entity___s.FindAsync(id);
            return _mapper.Map<___entity___Dto>(___entity___);
        }

        public async void CreateAsync(___entity___Dto ___entity___)
        {
            var new___entity___ = _mapper.Map<___entity___>(___entity___);
            await _dbContext.___entity___s.AddAsync(new___entity___);
            _dbContext.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {
            var ___entity___ = await _dbContext.___entity___s.FindAsync(id);
            _dbContext.Remove(___entity___);
            _dbContext.SaveChanges();
        }

        public void Update(___entity___Dto ___entity___)
        {
            var updated___entity___ = _mapper.Map<___entity___>(___entity___);
            _dbContext.Update(updated___entity___);
            _dbContext.SaveChanges();
        }
    }
}