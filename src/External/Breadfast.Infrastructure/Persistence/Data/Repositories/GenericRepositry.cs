using Breadfast.Domain.Entities;
using Breadfast.Domain.Entities.Products;
using Breadfast.Domain.Interfaces;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Breadfast.Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepositry<T> where T : BaseEntity
    {
        private readonly BreadfastDbContext _dbContext;

        public GenericRepository(BreadfastDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            // if(typeof(T) == typeof(Product))
            // return  (IEnumerable<T>) await _dbContext.Set<Product>().AsNoTracking().Include(P =>P.Brand).Include(P => P.Category).ToListAsync();
          
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
               
        }

        public async Task<T?> GetById(int id)
        {
           //  if (typeof(T) == typeof(Product))
           //  return   await _dbContext.Set<Product>().Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;

            return await _dbContext.Set<T>().FindAsync(id); 

        }

        public async Task<T?> GetWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().ToListAsync();
        }



        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationeEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }

    }
}
