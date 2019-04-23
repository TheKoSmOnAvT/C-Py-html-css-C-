using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    //Коммерческая Недвижмость
    [Serializable]
    public class CommercialRealties : ObjecrtRealties
    {
        public string naznach { get; set; } //назначение
        public int count_room { get; set; } //кол комнат
        public CommercialRealties() :base() { naznach = "пусто";count_room = 0; }
        public CommercialRealties(bool ar,string name, int cost, string Naznach, int Count_room):base(ar,name,cost)
        {
            naznach = Naznach;
            if (Count_room >= 0)
            {
                count_room = Count_room;
            }
            else
            {
                count_room = 0;
            }
        }
        public override string  ToString()
        {
            return $"{base.ToString()} \n Назначение: {naznach} \nКоличество комнат: {count_room} ";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() +naznach.GetHashCode() + count_room.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is CommercialRealties == false)
                return false;
            CommercialRealties x = obj as CommercialRealties;
            return base.Equals(obj) && count_room == x.count_room && naznach ==x.naznach;
        }
        protected static int[] rooms = { 1, 2, 3, 4, 5, 6, 7 };
        protected static string[] nazn = {"Склад", "Магазин","Аптека","Офис","Серверная","Хостел","Выставка"};
        public static CommercialRealties GetRandom()
        {
            return new CommercialRealties(bo[rnd.Next(0,2)],names[rnd.Next(0, 14)], costs[rnd.Next(0, 14)], nazn[rnd.Next(0,6)], rooms[rnd.Next(0,6)]);
        }
    }
}
