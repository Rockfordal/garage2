using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2
{
    public class RandomRegnr
    {
        private string letters = "";
        private string numbers = "";

        public string gimme()
        {
            var rl = new RandomStuff();

            for (int i = 1; i <= 3 ; i++)
            {
                letters += rl.GetLetter();
            }

            for (int i = 1; i <= 3 ; i++)
            {
                letters += rl.GetDigit();
            }

            var regnr = letters + numbers;
            return regnr.ToUpper();
        }

    }

    /// <summary>
    // returns random lowercase letter
    /// </summary>
    class RandomStuff
    {
        Random _random = new Random();
        public char GetLetter()
        {
            int num = _random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
        public string GetDigit()
        {
            int num = _random.Next(0, 9); // Zero to 25
            return num.ToString();
        }
    }

}