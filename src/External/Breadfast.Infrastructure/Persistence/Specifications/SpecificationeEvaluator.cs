using Breadfast.Domain.Entities;
using Breadfast.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Specifications
{
    public static class SpecificationeEvaluator<T>  where T : BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> inputquery, ISpecification<T> spec)
        {

            var query = inputquery;

            if(spec.Criteria is not null)
            {
              query = query.Where(spec.Criteria);
            }
            spec.Total = query.Count();    
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if(spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            query = query.Skip(spec.Skip).Take(spec.Take);  
            query = spec.Includes.Aggregate(query, (currentquery, includesExpression) => currentquery.Include(includesExpression));

            return query;

        }

    }
}
