using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzLib;
using NUnit.Framework;

namespace Test
{
    public class FizzBuzzTest
    {
        private const string Everything = "Everything";
        private const string IS = "Is";
        private const string Awesome = "Awesome";

        readonly FizzBuzz _sut = new FizzBuzz(
                new Dictionary<int, string>
                {
                    [3] = Everything,
                    [5] = IS,
                    [7] = Awesome
                });

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public void When_is_not_multiple_returns_the_same_number(int i)
        {
            var actual = _sut.DoIt(i);

            Assert.That(actual, Is.EqualTo(i.ToString()));
        }

        [TestCaseSource(nameof(TestCases))]
        public string Returns_all_the_words_of_the_matching_numbers(int i)
        {
            return _sut.DoIt(i);
        }

        private static IEnumerable TestCases()
        {
            return new Dictionary<string, IEnumerable<int>>
            {
                {Everything, MultOf3()},
                {IS, MultOf5()},
                {Awesome, MultOf7()},
                {Everything + IS, new[] {15, 30, 45, 60} },
                {Everything + Awesome, new[] { 21, 42, 84} },
                {IS + Awesome, new[] { 35, 70, 140} },
                {Everything + IS + Awesome, Enumerable.Range(1, 10).Select(i => 3 * 5 * 7 * i) },
            }
            .SelectMany(kvp => kvp.Value.Select(v => new TestCaseData(v).Returns(kvp.Key)));
        }

        [Test]
        public void Acceptance()
        {
            // Print the sequence to the console
            Enumerable
                .Range(1, 5 * 7 * 3)
                .Select(_sut.DoIt)
                .ToList()
                .ForEach(Console.Out.WriteLine);
        }

        private static int[] MultOf3()
        {
            return new[] {3, 6, 9, 12, 18, 24, 27, 33, 36, 39};
        }

        private static int[] MultOf5()
        {
            return new[] { 5, 10, 20, 25, 40, 50, 55 };
        }
        private static int[] MultOf7()
        {
            return new[] { 7, 14, 28, 56 };
        }
    }
}
