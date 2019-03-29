using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.Utils
{
    public class JsonUtils
    {
        public static String ConvertToJson(dynamic content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
