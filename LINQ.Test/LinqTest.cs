using System;
using System.Collections.Generic;
using System.Linq;
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
                .BeEquivalentTo(new List<int> {3, 7, 11});
        }

        [TestMethod]
        public void Process2()
        {
            Class1.Process(_list, Class1.Times)
                .Should()
                .BeEquivalentTo(new List<int> {2, 12, 30});
        }

        [TestMethod]
        public void Process3()
        {
            Class1.IntMethodThatTakesTwoIntArgs meth = (q, w) => (int) Math.Pow(q, w); // lambda expression
            Class1.Process(_list, meth)
                .Should()
                .BeEquivalentTo(new List<int> {1, 81, 15625});
        }

        [TestMethod]
        public void LINQ1()
        {

            string sh =
                @";lfsgjdfhg\\\fhgsahgcnjshtvkgfdhuoguuuuuuuuUuuuuuuuuuuuubsljghradghaowehrouweugfoughdsugliuioboiugLugiuhuhoiufglghsjfchsluhmklgiygkhiygygiygyioyigbyvbygygnuilgufygiygygkygluiOIUILGKJNHFSTUNVREHVLUNJGHVSNFG  YDSL;THOSFJFGH;FLJHVGOLTFZHVNL;GHJBNFXLKBHJNGLNVJH;OLYHBN;";

            var group1 = sh.GroupBy(c => c)
                .OrderBy(group1 => group1.Key)
                .First();

            group1.Key.Should().Be(' ');

            group1.Count().Should().Be(2);

            var letterHistogram = sh.GroupBy(c => c)
                .Select(grp => new {Key = grp.Key, Count = grp.Count()})
                .OrderByDescending(lc => lc.Count)
                .ThenBy(lc => lc.Key)
                .First();

            letterHistogram.Count.Should().Be(35);

            var letterHistogramCaseInsensitive = sh.GroupBy(Char.ToUpper)
                .Select(grp => new {Key = grp.Key, Count = grp.Count()})
                .OrderByDescending(lc => lc.Count)
                .ThenBy(lc => lc.Key)
                .First();

            letterHistogramCaseInsensitive.Count.Should().Be(39);

        }

        [TestMethod]
        public void LINQ2()
        {
            string sh = "Bob Carol John Bob Dale Ebony Frank Bob   C  Carol Clarinda Casey Cant ";

            sh.Split()
                .Where(w => w.Length > 0)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .First().Key.Should().Be("Bob");

            var mostCommonFirstLetter = sh.Split()
                .Where(w => w.Length > 0)
                .GroupBy(w => w[0])
                .OrderByDescending(g => g.Count())
                .Single(g => g.Key=='Z').Key.Should().Be('C');


            // var mostCommonLength;

            var _2ndBest= sh.Split()
            .Where(w => w.Length > 0)
                .GroupBy(w => w[0])
                .OrderByDescending(g => g.Count())
            .Take(5)
            .ToList()[1]
            .Key.Should().Be('B');


            var avgCount = sh.Split()
                .Where(w => w.Length > 0)
                .GroupBy(w => w[0])
                .Average(g => g.Count())
                .Should().BeApproximately(2.16666, 0.0001);
        }
    }
}
