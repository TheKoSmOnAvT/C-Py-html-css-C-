using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    //дом
    [Serializable]
   public  class House : ObjecrtRealties
    {
        public int number { get; set; } // кол. комнат
        public int count_level { get; set; } //кол. этажей 

        public House() : base()
        {
            number = 0;
            count_level = 0;
        }
        public House(bool ar,string Name, int Cost, int Number, int Count_level) : base(ar,Name, Cost)
        {
            if (Number >= 0)
            {
                number = Number;
            }
            else
            {
                number = 0;
            }
            if (Count_level >= 0)
            {
                count_level = Count_level;
            }
            else
            {
                count_level = 0;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n Количество комнат: {number} \nКоличество этажей: {count_level} ";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + number.GetHashCode() + count_level.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is House == false)
                return false;
            House x = obj as House;
            return base.Equals(obj) && number == x.number && count_level == x.count_level;
        }
        protected static int[] rooms = { 1, 2, 3, 4, 5, 6, 7 };
        protected static int[] levs = { 1, 2, 3, 4, 5, 6, 7 };
        public static House GetRandom()
        {
            return new House(bo[rnd.Next(0, 2)], names[rnd.Next(0, 14)], costs[rnd.Next(0, 14)], rooms[rnd.Next(0, 6)], levs[rnd.Next(0, 6)]);
        }
    }
}
