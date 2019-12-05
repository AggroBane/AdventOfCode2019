using System;
using System.Collections.Generic;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 278384;
            int max = 824795;
            int[] digits = new int[6];

            List<int> answer1 = new List<int>();
            List<int> answer2 = new List<int>();

            for (int number = min; number < max; number++)
            {
                //Getting the 6 digits of the current number
                string strNumber = number.ToString();
                for (int j = 0; j < digits.Length; j++)
                {
                    digits[j] = int.Parse(strNumber.Substring(j, 1));
                }

                //Checking the conditions
                int lastDigit = 0;
                int nbRepetition = 0;
                bool neverDecrease = true;
                bool sameDigits = false;
                for (int j = 0; j < digits.Length; j++)
                {
                    //Each digits must never decrease
                    if (digits[j] > lastDigit)
                    {
                        lastDigit = digits[j];
                        nbRepetition = 1;
                    }
                    //Two digits must be the same
                    else if(digits[j] == lastDigit)
                    {
                        sameDigits = true;
                        nbRepetition++;
                    }
                    else
                    {
                        neverDecrease = false;
                        break;
                    }
                }

                if (neverDecrease && sameDigits) answer1.Add(number);
                if (neverDecrease && sameDigits && nbRepetition == 2) answer2.Add(number);
            }

            Console.WriteLine("Number of possibilities (part1): " + answer1.Count);
            Console.WriteLine("Number of possibilities (part2): " + answer2.Count);
            //253 too low
            //300 too low
            //ITS 603
        }
    }
}
