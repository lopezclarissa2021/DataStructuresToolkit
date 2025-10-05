using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructuresToolkit;

namespace DataStructuresToolkit.Tests
{
    [TestFixture]
    public class ArrayStringListHelpers_Tests
    {
        [Test]
        public void InsertIntoArray_InsertsCorrectly()
        {
            int[] original = { 1, 2, 3 };
            int[] expected = { 1, 99, 2, 3 };
            int[] result = ArrayStringListHelpers.InsertIntoArray(original, 1, 99);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DeleteFromArray_DeletesCorrectly()
        {
            int[] original = { 1, 2, 3 };
            int[] expected = { 1, 3 };
            int[] result = ArrayStringListHelpers.DeleteFromArray(original, 1);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConcatenateNamesNaive_ConcatenatesCorrectly()
        {
            string[] names = { "Alice", "Bob", "Clarissa" };
            string result = ArrayStringListHelpers.ConcatenateNamesNaive(names);
            Assert.That(result, Is.EqualTo("Alice,Bob,Clarissa"));
        }

        [Test]
        public void ConcatenateNamesBuilder_ConcatenatesCorrectly()
        {
            string[] names = { "Alice", "Bob", "Clarissa" };
            string result = ArrayStringListHelpers.ConcatenateNamesBuilder(names);
            Assert.That(result, Is.EqualTo("Alice,Bob,Clarissa"));
        }

        [Test]
        public void InsertIntoList_InsertsCorrectly()
        {
            var list = new List<int> { 1, 2, 3 };
            ArrayStringListHelpers.InsertIntoList(list, 1, 99);
            Assert.That(list, Is.EqualTo(new List<int> { 1, 99, 2, 3 }));

        }

        [Test]
        public void Performance_ConcatenateNamesNaive()
        {
            for (int n = 1000; n <= 5000; n += 1000)
            {
                string[] names = new string[n];
                for (int i = 0; i < n; i++) names[i] = "Name" + i;

                var sw = Stopwatch.StartNew();
                string result = ArrayStringListHelpers.ConcatenateNamesNaive(names);
                sw.Stop();


                Assert.That(result, Does.StartWith("Name0"));
                TestContext.WriteLine($"Naive n={n}: {sw.ElapsedTicks} ticks");
            }
        }

        [Test]
        public void Performance_ConcatenateNamesBuilder()
        {
            for (int n = 1000; n <= 5000; n += 1000)
            {
                string[] names = new string[n];
                for (int i = 0; i < n; i++) names[i] = "Name" + i;

                var sw = Stopwatch.StartNew();
                string result = ArrayStringListHelpers.ConcatenateNamesBuilder(names);
                sw.Stop();

                Assert.That(result, Does.StartWith("Name0"));
                TestContext.WriteLine($"Builder n={n}: {sw.ElapsedTicks} ticks");
            }
        }
    }
}

