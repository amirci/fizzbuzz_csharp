using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        private readonly IDictionary<int, string> _dictionary;

        public FizzBuzz(IDictionary<int, string> dictionary)
        {
            this._dictionary = dictionary;
        }

        public string DoIt(int i)
        {
            var words = this._dictionary
                .Where(kvp => i%kvp.Key == 0)
                .Select(kvp => kvp.Value)
                .Aggregate("", (a, b) => a+ b);

            return words == string.Empty ? i.ToString() : words;
        }
    }
}