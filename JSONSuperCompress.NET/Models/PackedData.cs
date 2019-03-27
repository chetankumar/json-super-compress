using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.Models
{
    public class PackedData
    {
       public Schema Schema { get; set; }
       public EnumerationList EnumerationList { get; set; }
       public List<Dictionary<string,dynamic>> PData { get; set; }
    }
}
