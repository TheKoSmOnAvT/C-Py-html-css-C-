using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    // Жилая Недвижимость
    [Serializable]
    public class Residential_Real_Estate : ObjecrtRealties
    {
        public string date { get; set; } //дата постройки
        public Residential_Real_Estate() : base() { date = "пусто"; }
        public Residential_Real_Estate(bool ar, string name, int cost, string Date) : base(ar, name, cost)
        {
            date = Date;
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n Дата постройки : {date}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + date.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is Residential_Real_Estate == false)
                return false;
            Residential_Real_Estate x = obj as Residential_Real_Estate;
            return base.Equals(obj) && date == x.date;
        }
        protected static string[] dat = { "1990", "1980", "1970", "2000", "2004", "2006", "2010" };
        public static Residential_Real_Estate GetRandom()
        {
            return new Residential_Real_Estate(bo[rnd.Next(0, 2)], names[rnd.Next(0, 14)], costs[rnd.Next(0, 14)], dat[rnd.Next(0, 6)]);
        }
    }
}
