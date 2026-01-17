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
        public Expression<Func<T, object>> OrderBy { get; set ; } =null!;
        public Expression<Func<T, object>> OrderByDescending { get ; set; } = null!;
        public int Skip { get ; set; }
        public int Take { get ; set; }
        public int Total { get; set; }
        public bool IsPagnationEnable { get ; set ; }


        // new  // GetAll  ->> 
        public BaseSpecification()
        {   
        }
        // GetById
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;    
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        public void ApplyPagnation(int skip, int take)
        {
            IsPagnationEnable = true;
            Skip = skip;
            Take = take;
        }

    }
}
