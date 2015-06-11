using System;
using System.Linq;
using FizzBuzzLib;
using NUnit.Framework;

namespace Test
{
    public class FizzBuzzTest
    {
        readonly FizzBuzz _sut = new FizzBuzz();

        [TestCaseSource(nameof(MultOf3))]
        public void When_is_multiple_of_3_returns_fizz(int i)
        {
            var actual = _sut.DoIt(i);

            Assert.That(actual, Is.EqualTo("Fizz"));
        }

        [TestCaseSource(nameof(MultOf5))]
        public void When_is_multiple_of_5_returns_buzz(int i)
        {
            var actual = _sut.DoIt(i);

            Assert.That(actual, Is.EqualTo("Buzz"));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public void When_is_not_multiple_returns_the_same_number(int i)
        {
            var actual = _sut.DoIt(i);

            Assert.That(actual, Is.EqualTo(i.ToString()));
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        public void When_is_multiple_of_both_returns_fizzbuzz(int i)
        {
            var actual = _sut.DoIt(i);

            Assert.That(actual, Is.EqualTo("FizzBuzz"));
        }


        [Test]
        public void Acceptance()
        {
            // Print the sequence to the console
            Enumerable
                .Range(1, 100)
                .Select(_sut.DoIt)
                .ToList()
                .ForEach(Console.Out.WriteLine);
        }

        private static int[] MultOf3()
        {
            return new[] {3, 6, 9, 12, 18, 21, 24, 27, 33, 36, 39};
        }

        private static int[] MultOf5()
        {
            return new[] { 5, 10, 20, 25, 35, 40, 50, 55 };
        }
    }
}
