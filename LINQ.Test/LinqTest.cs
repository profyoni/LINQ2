using System;
using System.Collections.Generic;
using FluentAssertions;
using LINQ2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ.Test
{
    [TestClass]
    public class LinqTest
    {
        private readonly List<(int, int)> _list = new List<(int, int)> {(1, 2), (3, 4), (5, 6)};
    
        [TestMethod]
        public void Plus()
        {
            Class1.Plus(3, 4).Should().Be(7);
        }

        [TestMethod]
        public void Process()
        {
            Class1.Process(_list)
                .Should()
                .BeEquivalentTo(new List<int> { 3, 7, 11 });
        }

        [TestMethod]
        public void Process2()
        {
            Class1.Process(_list, Class1.Times)
                .Should()
                .BeEquivalentTo(new List<int> { 2, 12, 30 });
        }

        [TestMethod]
        public void Process3()
        {
            Class1.IntMethodThatTakesTwoIntArgs meth = (q,w) => (int)Math.Pow(q,w); // lambda expression
            Class1.Process(_list, meth)
                .Should()
                .BeEquivalentTo(new List<int> { 1, 81, 15625 });
        }
    }
}
