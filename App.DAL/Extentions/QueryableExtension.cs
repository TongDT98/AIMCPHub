using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Extentions
{
    public static class QueryableExtension
    {      
            /// <summary>
            /// Phân trang cho `IQueryable<T>`. Có thể được sử dụng thay thế cho chuỗi `Skip(...).Take(...)`.
            /// </summary>
            public static IQueryable<T> PageBy<T>([NotNull] this IQueryable<T> query, int skipCount, int maxResultCount)
            {
                return query.Skip(skipCount).Take(maxResultCount);
            }

            /// <summary>
            /// Phân trang cho `TQueryable`. Có thể được sử dụng thay thế cho chuỗi `Skip(...).Take(...)`.
            /// </summary>
            public static TQueryable PageBy<T, TQueryable>([NotNull] this TQueryable query, int skipCount,
                int maxResultCount)
                where TQueryable : IQueryable<T>
            {
                return (TQueryable)query.Skip(skipCount).Take(maxResultCount);
            }

            /// <summary>
            /// Phân trang và trả về thông tin phân trang.
            /// </summary>
            public static PagingResponse<T> Paging<T>([NotNull] this IQueryable<T> query, int skipCount, int maxResultCount, int currentPageNumber)
            {
                var TotalPage = 0;
                var datasCount = query.Count();
                if (maxResultCount != 0)
                    TotalPage = (datasCount / maxResultCount == 0) ? 1
                    : ((datasCount % maxResultCount > 0) ? (datasCount / maxResultCount + 1) : (datasCount / maxResultCount));
                var LastPage = currentPageNumber == TotalPage ? true : false;
                return new PagingResponse<T>
                {
                    Data = query.Skip(skipCount).Take(maxResultCount),
                    TotalPage = TotalPage,
                    LastPage = LastPage,
                    ObjectCount = datasCount,
                    CurrentPageNumber = currentPageNumber,
                    PerPage = maxResultCount
                };
            }

            public class PagingResponse<T>
            {
                public IQueryable<T> Data { get; set; }
                public int TotalPage { get; set; }
                public bool LastPage { get; set; }
                public int ObjectCount { get; set; }
                public int CurrentPageNumber { get; set; }
                public int PerPage { get; set; }
            }

            /// <summary>
            /// Lọc `IQueryable<T>` bằng predicate cho một điều kiện nhất định.
            /// </summary>
            public static IQueryable<T> WhereIf<T>([NotNull] this IQueryable<T> query, bool condition,
                Expression<Func<T, bool>> predicate)
            {
                return condition
                    ? query.Where(predicate)
                    : query;
            }

            /// <summary>
            /// Sắp xếp `IEnumerable<T>` theo thuộc tính và hướng sắp xếp chỉ định.
            /// </summary>
            public static IEnumerable<T> Sort<T>(this IEnumerable<T> source, string sortBy, string sortDirection)
            {
                try
                {
                    if (string.IsNullOrEmpty(sortBy) || string.IsNullOrEmpty(sortDirection))
                    {
                        return source;
                    }
                    var param = Expression.Parameter(typeof(T), "item");
                    Expression nameProperty = Expression.Property(param, sortBy);
                    var sortExpression = Expression.Lambda<Func<T, object>>
                        (Expression.Convert(nameProperty, typeof(object)), param);

                    switch (sortDirection.ToLower())
                    {
                        case "asc":
                            return source.AsQueryable().OrderBy(sortExpression);

                        case "desc":
                            return source.AsQueryable().OrderByDescending(sortExpression);

                        default:
                            return source.AsQueryable();
                    }
                }
                catch
                {
                    return source;
                }
            }

            /// <summary>
            /// Sắp xếp `IQueryable<T>` theo thuộc tính và hướng sắp xếp chỉ định.
            /// </summary>
            public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy, string sortDirection)
            {
                try
                {
                    if (string.IsNullOrEmpty(sortBy) || string.IsNullOrEmpty(sortDirection))
                    {
                        return source;
                    }
                    var param = Expression.Parameter(typeof(T), "item");
                    MethodInfo toStringMethod = typeof(object).GetMethod("ToString", Array.Empty<Type>());
                    Expression nameProperty = Expression.Property(param, sortBy);
                    nameProperty = Expression.Call(nameProperty, toStringMethod, null);
                    var sortExpression = Expression.Lambda<Func<T, object>>
                        (Expression.Convert(nameProperty, typeof(object)), param);

                    switch (sortDirection.ToLower())
                    {
                        case "asc":
                            return source.OrderBy(sortExpression);

                        case "desc":
                            return source.OrderByDescending(sortExpression);

                        default:
                            return source;
                    }
                }
                catch
                {
                    return source;
                }
            }

            /// <summary>
            /// Lọc `IQueryable<T>` bằng predicate cho một điều kiện nhất định.
            /// </summary>
            public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition,
                Expression<Func<T, bool>> predicate)
                where TQueryable : IQueryable<T>
            {
                return condition
                    ? (TQueryable)query.Where(predicate)
                    : query;
            }

            /// <summary>
            /// Lọc `IQueryable<T>` bằng predicate với chỉ số cho một điều kiện nhất định.
            /// </summary>
            public static IQueryable<T> WhereIf<T>([NotNull] this IQueryable<T> query, bool condition,
                Expression<Func<T, int, bool>> predicate)
            {
                return condition
                    ? query.Where(predicate)
                    : query;
            }

            /// <summary>
            /// Lọc `IQueryable<T>` bằng predicate với chỉ số cho một điều kiện nhất định.
            /// </summary>
            public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition,
                Expression<Func<T, int, bool>> predicate)
                where TQueryable : IQueryable<T>
            {
                return condition
                    ? (TQueryable)query.Where(predicate)
                    : query;
            }

            /// <summary>
            /// Tìm kiếm toàn văn trong `IQueryable<T>` theo từ khóa tìm kiếm và kiểu khớp chính xác.
            /// </summary>
            public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey, bool exactMatch)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "c");

                MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                MethodInfo toStringMethod = typeof(object).GetMethod("ToString", Array.Empty<Type>());

                var publicProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(p => p.PropertyType == typeof(string));
                Expression orExpressions = null;

                string[] searchKeyParts;
                if (exactMatch)
                {
                    searchKeyParts = new[] { searchKey };
                }
                else
                {
                    searchKeyParts = searchKey.Split(' ');
                }

                foreach (var property in publicProperties)
                {
                    Expression nameProperty = Expression.Property(parameter, property);
                    foreach (var searchKeyPart in searchKeyParts)
                    {
                        Expression searchKeyExpression = Expression.Constant(searchKeyPart);
                        Expression callContainsMethod = Expression.Call(nameProperty, containsMethod, searchKeyExpression);
                        if (orExpressions == null)
                        {
                            orExpressions = callContainsMethod;
                        }
                        else
                        {
                            orExpressions = Expression.Or(orExpressions, callContainsMethod);
                        }
                    }
                }

                MethodCallExpression whereCallExpression = Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { queryable.ElementType },
                    queryable.Expression,
                    Expression.Lambda<Func<T, bool>>(orExpressions, new ParameterExpression[] { parameter }));

                return queryable.Provider.CreateQuery<T>(whereCallExpression);
            }

            /// <summary>
            /// Lọc `IQueryable<T>` theo thuộc tính và giá trị.
            /// </summary>
            public static IQueryable<T> WhereExistsOrAll<T>(this IQueryable<T> source, string propertyName, object value)
            {
                // Kiểm tra xem thuộc tính có tồn tại hay không
                var propertyInfo = typeof(T).GetProperty(propertyName);
                if (propertyInfo == null)
                {
                    return source;
                }

                // Tạo các biểu thức cần thiết
                var parameterExpression = Expression.Parameter(typeof(T), "p");
                var property = Expression.Property(parameterExpression, propertyName);

                // Chuyển đổi giá trị value sang kiểu của thuộc tính
                var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                var constant = Expression.Constant(convertedValue, propertyInfo.PropertyType);

                // Tạo biểu thức so sánh
                var expression = Expression.Equal(property, constant);

                // Tạo biểu thức lambda
                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

                // Trả về nguồn đã lọc
                return source.Where(lambda);
            }

            /// <summary>
            /// Lọc `IQueryable<T>` theo thuộc tính và giá trị boolean.
            /// </summary>
            public static IQueryable<T> WhereExistsOrAll<T>(this IQueryable<T> source, string propertyName, bool value)
            {
                if (typeof(T).GetProperty(propertyName) == null)
                {
                    return source;
                }
                var parameterExpression = Expression.Parameter(typeof(T), "p");
                var constant = Expression.Constant(value);
                var property = Expression.Property(parameterExpression, propertyName);
                var expression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
                return source.Where(lambda);
            }

            /// <summary>
            /// Tìm kiếm trong `IQueryable<T>` theo thuộc tính và giá trị.
            /// </summary>
            //public static IQueryable<T> FindByProperty<T, T2>(this IQueryable<T> source, string propertyName, T2? value)
            //{
            //    var valueConverted = value.ConvertDataType<T2>();
            //    if (typeof(T).GetProperty(propertyName) == null)
            //    {
            //        return source;
            //    }
            //    var parameterExpression = Expression.Parameter(typeof(T), "p");
            //    var constant = Expression.Constant(valueConverted);
            //    var property = Expression.Property(parameterExpression, propertyName);
            //    var expression = Expression.Equal(property, constant);
            //    var lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
            //    return source.Where(lambda);
            //}
        
    }
}
