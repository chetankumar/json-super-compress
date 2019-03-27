using JSONSuperCompress.NET.Models;
using JSONSuperCompress.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.AppCode
{
    public class SchemaFinder<T>
    {
        public static Schema GenerateSchema()
        {
            var properties = typeof(T).GetProperties();
            var propCount = properties.Count();
            
            var propName = properties.Select(x => x.Name).ToList();
            var keyNames = KeyGenerator.GenerateKeys(propCount);

            Dictionary<string, SchemaPropertyInfo> keyValuePairs = new Dictionary<string, SchemaPropertyInfo>();
            for(int i = 0; i < propName.Count(); i++)
            {
                keyValuePairs.Add(propName[i], new SchemaPropertyInfo { NewKey = keyNames[i], Property = properties[i] });
            }
            return new Schema { KeyMap = keyValuePairs };
        }
    }
}
