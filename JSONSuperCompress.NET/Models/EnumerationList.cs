using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.Models
{
    public class EnumerationList
    {
        public Dictionary<string,List<dynamic>> Enumerations { get; set; }

        //public Dictionary<string,Dictionary<string,int>> EnumerationValueMap { get; set; }

        public Dictionary<string, Dictionary<string, int>> Finalize()
        {
            var enumerationValueMap = new Dictionary<string, Dictionary<string, int>>();
            foreach (var en in Enumerations)
            {
                Dictionary<string, int> enValMap = new Dictionary<string, int>();
                var list = en.Value;
                for(int i = 0; i < en.Value.Count(); i++)
                {
                    enValMap.Add(en.Value[i], i);
                }
                enumerationValueMap.Add(en.Key, enValMap);
            }
            return enumerationValueMap;
        }
    }
}
