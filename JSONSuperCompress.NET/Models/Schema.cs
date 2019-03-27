using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.Models
{
    public class Schema
    {
        public Dictionary<string,SchemaPropertyInfo> KeyMap { get; set; }
    }

    public class SchemaPropertyInfo
    {
        public PropertyInfo Property { get; set; }
        public string NewKey { get; set; }
    }
}
