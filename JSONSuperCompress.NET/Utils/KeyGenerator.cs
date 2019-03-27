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
            var all = CAPS.Concat(LOWERS).Concat(DIGITS).Select(x=> x.ToString()).ToArray();
            if (count > all.Count())
            {
                throw new Exception($"Maximum properties count is {count}. Cannot have more properties.");
            }
            return all.ToList().Skip(0).Take(count).ToList();
        }
    }
}
