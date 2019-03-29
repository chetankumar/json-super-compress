using System;
using System.Linq;
using JSONSuperCompress.NET.AppCode;
using JSONSuperCompress.NET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSONSuperCompress.Test
{
    [TestClass]
    public class EnumerationTest
    {
        [TestMethod]
        public void EnumerationTest1()
        {
            var samples1_1000 = Sample1.GenerateSamples(1000);
            EnumerationFinder<Sample1> finder = new EnumerationFinder<Sample1>(samples1_1000);

            finder.GenerateEnumeration(x => x.Category);
            finder.GenerateEnumeration(x => x.CategoryId);
            finder.GenerateEnumeration(x => x.Manager);

            var enumerationList = finder.EnumerationList;

            Schema schema = finder.Schema;

            Assert.AreEqual(enumerationList.Enumerations.Count(), 3);
            Assert.IsTrue(enumerationList.Enumerations[schema.KeyMap[nameof(Sample1.Category)].NewKey].Count() <= 6);
            Assert.IsTrue(enumerationList.Enumerations[schema.KeyMap[nameof(Sample1.CategoryId)].NewKey].Count() <= 6);
            Assert.IsTrue(enumerationList.Enumerations[schema.KeyMap[nameof(Sample1.Manager)].NewKey].Count() <= 10);

        }
    }
}
