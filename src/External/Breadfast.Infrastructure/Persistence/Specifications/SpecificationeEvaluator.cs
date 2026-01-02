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

            query = spec.Includes.Aggregate(query, (currentquery, includesExpression) => currentquery.Include(includesExpression));

            return query;

        }

    }
}
