using Breadfast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces
{
    public interface IGenericRepositry<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<T?>GetWithSpec(ISpecification<T> spec);

    }
}
