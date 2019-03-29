using System;
using System.Linq;
using JSONSuperCompress.NET.AppCode;
using JSONSuperCompress.NET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSONSuperCompress.Test
{
    [TestClass]
    public class SchemaTest
    {
        [TestMethod]
        public void TestSchema1()
        {
            Schema schema1 = SchemaFinder<Sample1>.GenerateSchema();
            Assert.AreEqual(schema1.KeyMap.Count(), 4);
            Assert.IsTrue(schema1.KeyMap.Keys.Contains(nameof(Sample1.Category)));
            Assert.IsTrue(schema1.KeyMap.Keys.Contains(nameof(Sample1.CategoryId)));
            Assert.IsTrue(schema1.KeyMap.Keys.Contains(nameof(Sample1.Name)));
            Assert.IsTrue(schema1.KeyMap.Keys.Contains(nameof(Sample1.Manager)));
        }
    }
}
