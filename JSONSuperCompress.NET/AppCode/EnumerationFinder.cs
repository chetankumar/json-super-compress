using JSONSuperCompress.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.AppCode
{
    public class EnumerationFinder<T>
    {
        public  EnumerationList EnumerationList { get; set; }
        public Schema Schema { get; set; }

        public EnumerationFinder()
        {
            EnumerationList = new EnumerationList();
            Schema = SchemaFinder<T>.GenerateSchema();
            EnumerationList.Enumerations = new Dictionary<string, List<dynamic>>();
        }
        public void GenerateEnumeration<TKEY>(IQueryable<T> collection, Expression<Func<T,TKEY>> prop)
        {
            var ordered = collection.GroupBy(prop).Select(x => new { Value = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).Select(x=> (dynamic)x).ToList();
            var propertyName = prop.Name;
            var propInfo = Schema.KeyMap[propertyName];
            EnumerationList.Enumerations.Add(propInfo.NewKey, ordered);
        }
    }
}
