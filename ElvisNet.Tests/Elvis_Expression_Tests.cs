using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace ElvisNet.Tests
{
    [TestClass]
    public class Elvis_Expression_Tests
    {
        [TestMethod]
        public void Expression_Test()
        {
            Expression<Func<int>> expression = () => Environment.CommandLine.Length;
            var expect = Elvis.SafeNull(expression);

            Console.WriteLine(expect);
            Assert.AreEqual(expect, Environment.CommandLine.Length);
        }

        [TestMethod]
        public void Func_Test()
        {
            Func<int> func = () => Environment.CommandLine.Length;
            var expect = Elvis.SafeNull(func);
            
            Console.WriteLine(expect);
            Assert.AreEqual(expect, Environment.CommandLine.Length);
        }
    }
}
