using JSONSuperCompress.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.AppCode
{
    public class DataCompressor<T>
    {
        public PackedData Compress(ICollection<T> collection, Schema schema ,EnumerationList enumerationList)
        {
            PackedData packedData = new PackedData();
            packedData.EnumerationList = enumerationList;
            packedData.PData = new List<Dictionary<string, dynamic>>();

            var enumerationIndexMap = enumerationList.Finalize();

            foreach(var item in collection)
            {
                Dictionary<string, dynamic> pItem = new Dictionary<string, dynamic>();
                foreach (var keyVal in schema.KeyMap)
                {
                    PropertyInfo propInfo = keyVal.Value.Property;
                    dynamic itemValue = propInfo.GetValue(item);
                    pItem.Add(keyVal.Value.NewKey, enumerationIndexMap[keyVal.Key][itemValue]);
                }
                packedData.PData.Add(pItem);
            }

            return packedData;
        }
    }
}
