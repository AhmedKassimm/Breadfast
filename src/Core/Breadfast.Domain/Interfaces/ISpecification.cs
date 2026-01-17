using Breadfast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {

        // Property --> Where Specification (E => E.Id == id)
        public Expression<Func<T,bool>>? Criteria { get; set; }
        public List<Expression<Func<T,object>>> Includes { get; set; }  // --> Includes  Return Object  not BaseEntity 

        public Expression<Func<T,object>> OrderBy { get; set; }
        public int Total { get; set; }
        public Expression<Func<T,object>> OrderByDescending { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagnationEnable { get; set; }

    }
}
