using Garage2.DataAccess;
using Garage2.Entities;
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

    public class PIDGenerator
    {
        /// <summary>
        /// Generates slots with the format: A letter and 2 digits. eg: A08
        /// </summary>
        /// <param name="garage"></param>
        public void GenerateSlots(Garage garage, GarageDbContext db)
        {

            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int n = 0;
            string t = "";
            int antal = garage.NumberOfSlots;
            int index = 0;

            List<Slot> tmp = new List<Slot>();

            for (int i = 0; i < antal; i++)
            {
                n += 1;
                if (n > 15)
                {
                    index += 1;
                    n = 1;
                }

                if (n < 10)
                    t = "0" + n.ToString();
                else
                    t = n.ToString("0");
                var slot = new Slot();
                slot.PID = letters[index].ToString() + t;
                slot.Garage = garage;
                slot.Location = "Skellefteå";
                db.Slots.Add(slot);

                tmp.Add(slot);
            }
            //db.Slots.OrderBy(s => s.PID);
            //tmp.OrderBy(s => s.PID);
            garage.Slots = tmp;
            //db.SaveChanges();

        }
    }

}