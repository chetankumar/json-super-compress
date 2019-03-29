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

        public Dictionary<string, Dictionary<dynamic, int>> GenerateKeyMap()
        {
            // Converts the List to a dictionary, with index as key, and value as .. dictionary value.
            var enumerationIndexToValueMap = new Dictionary<string, Dictionary<dynamic, int>>();
            foreach (var en in Enumerations)
            {
                var enValMap = new Dictionary<dynamic, int>();
                var list = en.Value;
                for(int i = 0; i < list.Count(); i++)
                {
                    enValMap.Add(list[i],i+1); // We need to leave the 0 position as the static position for null. NULL cannot be added as a key in the dictionary
                }
                enumerationIndexToValueMap.Add(en.Key, enValMap);
            }
            return enumerationIndexToValueMap;
        }
    }
}
