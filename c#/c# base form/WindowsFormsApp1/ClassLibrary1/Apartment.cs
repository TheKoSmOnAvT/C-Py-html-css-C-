using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    //квартира
    [Serializable]
    public class Apartment : ObjecrtRealties
    {
        public  int count_room { get; set; } //кол комнат

        public Apartment() : base()
        {
            count_room = 0;
        }
        public Apartment(bool ar, string name, int cost, int count) : base(ar, name, cost)
        {
            if (count >= 0)
            {
                count_room = count;
            }
            else
            {
                count_room = 0;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} \nКоличество комнат: {count_room} ";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode()+ count_room.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is Apartment == false)
                return false;
            Apartment x = obj as Apartment;
            return base.Equals(obj) && count_room == x.count_room;
        }
        protected static int[] rooms = { 1,2,3,4,5,6,7 };
        public static Apartment GetRandom()
        {
            return new Apartment(bo[rnd.Next(0,2)],names[rnd.Next(0,14)],costs[rnd.Next(0,14)],rooms[rnd.Next(0,6)]);
        }

    }
}
