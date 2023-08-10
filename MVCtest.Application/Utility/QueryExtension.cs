using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Application.Utility
{
    internal static class QueryExtension
    {
        internal static IQueryable<T> Page<T>(this IQueryable<T> query, int pageSize , int pageNum) where T:class
        {
            return query.Skip((pageNum - 1) * pageSize).Take(pageSize);
        }
    }
}
