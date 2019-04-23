using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    //магазин
    [Serializable]
    public class Shop : ObjecrtRealties
    {
        public string nazvanie { get; set; }
        public Shop():base()
        {
            nazvanie = "Пусто";
        }
        public Shop(bool ar,string name, int cost, string Nazvanie) : base(ar,name, cost)
        {
            nazvanie = Nazvanie;
        }
        public override string ToString()
        {
            return $"{ base.ToString()} \nНазвание магазина: {nazvanie}" ;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + nazvanie.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is Shop == false)
                return false;
            Shop x = obj as Shop;
            return base.Equals(obj) && nazvanie == x.nazvanie;
        }
        protected static string[] naz = { "DNS", "Продукты", "М.Видео", "Nike", "Семья", "Виват", "Магнит", "Спортмастер", "Аптека", "Puma", };
        public static Shop GetRandom()
        {
            return new Shop(bo[rnd.Next(0, 2)], names[rnd.Next(0, 14)], costs[rnd.Next(0, 14)], naz[rnd.Next(0,9)]);
        }
    }
}
