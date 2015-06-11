using System;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";

        public string DoIt(int i)
        {
            Func<bool> isFizz = () => i%3 == 0;
            Func<bool> isBuzz = () => i%5 == 0;
            Func<bool> isBoth = () => isFizz() && isBuzz();

            if (isBoth()) return Fizz + Buzz;

            if (isFizz()) return Fizz;

            if (isBuzz()) return Buzz;

            return i.ToString();
        }
    }
}