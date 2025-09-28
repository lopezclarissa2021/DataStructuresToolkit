using NUnit.Framework;
using System.Diagnostics;
using DataStructuresToolkit;

namespace DataStructuresToolkit.Tests
{
    [TestFixture]
    public class ComplexityTester_Tests
    {
        private ComplexityTester tester;

        [SetUp]
        public void Setup()
        {
            tester = new ComplexityTester();
        }

        [Test]
        public void Test_RunConstantScenario()
        {
            int[] arr = { 42, 99, 123 };
            var result = tester.RunConstantScenario(arr);
            Assert.That(result, Is.EqualTo(42));


            Stopwatch sw = Stopwatch.StartNew();
            result = tester.RunConstantScenario(arr);
            sw.Stop();
            TestContext.WriteLine($"O(1) test: {sw.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Test_RunLinearScenario()
        {
            foreach (int n in new[] { 100, 1000, 10000 })
            {
                int[] arr = new int[n];
                for (int i = 0; i < n; i++) arr[i] = 1;

                Stopwatch sw = Stopwatch.StartNew();
                var result = tester.RunLinearScenario(arr);
                sw.Stop();

                Assert.That(result, Is.EqualTo(n));
                TestContext.WriteLine($"O(n) n={n}: {sw.ElapsedMilliseconds} ms");
            }
        }

        [Test]
        public void Test_RunQuadraticScenario()
        {
            foreach (int n in new[] { 10, 100, 200 })
            {
                int[] arr = new int[n];
                for (int i = 0; i < n; i++) arr[i] = 1;

                Stopwatch sw = Stopwatch.StartNew();
                var result = tester.RunQuadraticScenario(arr);
                sw.Stop();

                Assert.That(result, Is.EqualTo(n * n));
                TestContext.WriteLine($"O(n²) n={n}: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}

