using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JSONSuperCompress.NET.AppCode;
using JSONSuperCompress.NET.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSONSuperCompress.Test
{
    [TestClass]
    public class CompressionTests
    {
        [TestMethod]
        public void TestCompression1()
        {
            var samples1_1000 = Sample1.GenerateSamples(100000);
            //TestSample1Sanity(1000, samples1_1000);

            Stopwatch w = new Stopwatch();
            w.Start();
            EnumerationFinder<Sample1> finder = new EnumerationFinder<Sample1>(samples1_1000);
            finder.GenerateEnumeration(x => x.Category);
            finder.GenerateEnumeration(x => x.CategoryId);
            finder.GenerateEnumeration(x => x.Manager);

            var packedData = DataCompressor<Sample1>.Compress(samples1_1000, finder.Schema, finder.EnumerationList);
            w.Stop();
            var elapsedMillis = w.Elapsed.TotalMilliseconds;

            var originalJson = JsonUtils.ConvertToJson(samples1_1000).ToCharArray().Length;
            var compressedJson = JsonUtils.ConvertToJson(packedData).ToCharArray().Length;
            Assert.IsNotNull(packedData);
        }

        private void TestSample1Sanity(int count, List<Sample1> samples1_1000)
        {
            Assert.AreEqual(samples1_1000.Count(), count);
            Assert.AreEqual(samples1_1000.Select(x => x.Category).Distinct().Count(), 6);
            Assert.AreEqual(samples1_1000.Select(x => x.CategoryId).Distinct().Count(), 6);
            Assert.AreEqual(samples1_1000.Select(x => x.Manager).Distinct().Count(), 10);
            Assert.AreEqual(samples1_1000.Select(x => x.Name).Distinct().Count(), 1000);
        }
    }
}
