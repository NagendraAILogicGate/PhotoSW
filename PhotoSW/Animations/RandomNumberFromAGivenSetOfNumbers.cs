using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.Animations
    {
    public class RandomNumberFromAGivenSetOfNumbers
        {

        List<int> _setOfNumbers = new List<int>();
        Random _random = new Random();

        public RandomNumberFromAGivenSetOfNumbers ( int min, int max )
            {
            for(int i = min; i <= max; i++)
                {
                _setOfNumbers.Add(i);
                }
            }

        public int Next ()
            {
            if(_setOfNumbers.Count > 0)
                {
                int nextNumberIndex = _random.Next(_setOfNumbers.Count);
                int val = _setOfNumbers[nextNumberIndex];
                _setOfNumbers.RemoveAt(nextNumberIndex);
                return val;
                }
            return -1;

            }
        }
    }
