using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSuperCompress.Test
{
    public class Sample1
    {
        public string Name { get; set; }
        public string Manager { get; set; }
        public string Category { get; set; }
        public int? CategoryId { get; set; }

        public static List<Sample1> GenerateSamples(int count)
        {
            
            List<Sample1> list = new List<Sample1>();

            SampleGenerator<string> nameGenerator = new SampleGenerator<string>(nameof(Name),count);
            SampleGenerator<string> managerGenerator = new SampleGenerator<string>(nameof(Manager), 10);
            SampleGenerator<string> categoryGenerator = new SampleGenerator<string>(nameof(Category), 6);
            SampleGenerator<int?> categoryIdGenerator = new SampleGenerator<int?>(0, 6);

            for (int i= 0; i < count; i++)
            {
                list.Add(new Sample1
                {
                    Name = nameGenerator.Next(i),
                    Manager = managerGenerator.GenerateRandom(i),
                    Category = categoryGenerator.GenerateRandom(i),
                    CategoryId = categoryIdGenerator.GenerateRandom(i)
                });
            }
            return list;
        }
    }


}
