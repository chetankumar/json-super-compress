using JSONSuperCompress.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.AppCode
{
    public class EnumerationFinder<T>
    {
        public  EnumerationList EnumerationList { get; set; }
        public Schema Schema { get; set; }
        public IQueryable<T> Collection { get; set; }

        public EnumerationFinder(List<T> samples)
        {
            Collection = samples.AsQueryable();
            EnumerationList = new EnumerationList();
            Schema = SchemaFinder<T>.GenerateSchema();
            EnumerationList.Enumerations = new Dictionary<string, List<dynamic>>();
        }
        public void GenerateEnumeration<TKEY>(Expression<Func<T,TKEY>> propLamda)
        {
            MemberExpression member = propLamda.Body as MemberExpression;
            PropertyInfo property = member.Member as PropertyInfo;
            var ordered = Collection.GroupBy(propLamda).Where(x=> x.Key != null).Select(x => new { Value = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).Select(x=> (dynamic)x.Value).ToList();
            var propertyName = property.Name;
            var propInfo = Schema.KeyMap[propertyName];
            EnumerationList.Enumerations.Add(propInfo.NewKey, ordered);
        }
    }
}
