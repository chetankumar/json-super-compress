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
        public static PackedData Compress(ICollection<T> collection, Schema schema ,EnumerationList enumerationList)
        {
            PackedData packedData = new PackedData();
            packedData.EnumerationList = enumerationList;
            packedData.PData = new List<Dictionary<string, dynamic>>();

            var enumerationIndexMap = enumerationList.GenerateKeyMap();

            foreach(var item in collection)
            {
                Dictionary<string, dynamic> pItem = new Dictionary<string, dynamic>();
                foreach (var keyVal in schema.KeyMap)
                {
                    PropertyInfo propInfo = keyVal.Value.Property;
                    dynamic itemValue = propInfo.GetValue(item);
                    var newKey = schema.KeyMap[keyVal.Key].NewKey;
                    if (enumerationIndexMap.ContainsKey(newKey))
                    {
                        var enumMapping = enumerationIndexMap[newKey];
                        if (itemValue == null)
                            pItem.Add(newKey, 0); //NULL has a predefined index value of 0
                        else
                            pItem.Add(newKey, enumMapping[itemValue]);
                    }
                    else
                        pItem.Add(keyVal.Value.NewKey, itemValue);
                }
                packedData.PData.Add(pItem);
            }

            return packedData;
        }
    }
}
