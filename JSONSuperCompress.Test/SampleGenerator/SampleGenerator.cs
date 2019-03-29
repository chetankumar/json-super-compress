using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONSuperCompress.Test
{
    internal class SampleGenerator<T>
    {
        public T DefaultValue { get; set; }
        public int Count { get; set; }
        public List<T> Set { get; set; }

        public SampleGenerator(T @default, int count)
        {
            this.DefaultValue = @default;
            this.Count = count;
            GenerateSet();
        }

        public void GenerateSet()
        {
            Set = new List<T>();
            var nullableType = Nullable.GetUnderlyingType(typeof(T));
            bool isNullable = nullableType != null;
            var finalType = nullableType ?? typeof(T);
            if (isNullable)
            {
                Set.Add(default(T));
            }
            if (DefaultValue is string)
            {
                for(int i = 0; i < Count; i++)
                {
                    Set.Add((T)Convert.ChangeType(DefaultValue.ToString()+ "_" + i, finalType));
                }
            }
            if (DefaultValue is DateTime)
            {
                DateTime def = (DateTime)Convert.ChangeType(DefaultValue, typeof(DateTime));
                for (int i = 0; i < Count; i++)
                {
                    DateTime val = def.AddMonths(i);
                    Set.Add((T)Convert.ChangeType(isNullable ? (DateTime?)val : val , typeof(T)));
                }
            }
            if (DefaultValue is int)
            {
                int def = (int) Convert.ChangeType(DefaultValue, typeof(int));
                for (int i = 0; i < Count; i++)
                {
                    int val = i + def;
                    Set.Add((T)Convert.ChangeType((int?)val, finalType));
                }
            }
            if (DefaultValue is float)
            {
                float def = (float)Convert.ChangeType(DefaultValue, typeof(float));
                for (int i = 0; i < Count; i++)
                {
                    float val = (i / (i + 1)) + def;
                    Set.Add((T)Convert.ChangeType(isNullable ? (float?)val : val, typeof(T)));
                }
            }
            if (DefaultValue is double)
            {
                double def = (double)Convert.ChangeType(DefaultValue, typeof(double));
                for (int i = 0; i < Count; i++)
                {
                    double val = (i / (i + 1)) + def;
                    Set.Add((T)Convert.ChangeType(isNullable ? (double?)val : val, typeof(T)));
                }
            }
        }

        internal T GenerateRandom(int i)
        {
            var rand = new Random(i);
            var index = rand.Next(0,Count);
            return Set[index];
        }

        internal T Next(int i)
        {
            i = i % Set.Count();
            return Set[i];
        }
    }
}