using Breadfast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } 
        public  List<Expression<Func<T, object>>> Includes { get ; set ; } = new List<Expression<Func<T, object>>>();


        // new  // GetAll  ->> 
        public BaseSpecification()
        {   
        }
        // GetById
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;    
        }
    }
}
