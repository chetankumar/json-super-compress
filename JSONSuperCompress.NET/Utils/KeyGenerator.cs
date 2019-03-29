using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.NET.Utils
{
    public class KeyGenerator
    {
        private static char[] CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        private static char[] LOWERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToArray();
        private static char[] DIGITS = "123456789".ToArray();

        //TODO Genarete a way to calculate keys for any count
        public static List<string> GenerateKeys(int count)
        {
            var all = CAPS.Concat(LOWERS).Concat(DIGITS).Select(x=> x.ToString()).ToArray()
                .Concat(new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9" })
                .Concat(new string[] { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9" }).ToArray();
            if (count > all.Count())
            {
                throw new Exception($"Maximum properties count is {all.Count()}. You have specified {count}");
            }
            return all.ToList().Skip(0).Take(count).ToList();
        }
    }
}
