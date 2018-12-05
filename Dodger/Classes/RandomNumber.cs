﻿using System;
using System.Security.Cryptography;

namespace Dodger.Classes
{
    class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Get(int min, int max)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = max - min + 1;
            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(min + randomValueInRange);
        }
    }
}
