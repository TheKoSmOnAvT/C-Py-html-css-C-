using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    //абстрактный
    [Serializable]
    public abstract class ObjecrtRealties
    {
       // public int Number { get; set; }
        public bool pur { get; set; } //сдается ли в аренду
        public string name { get; set; } //улица
        public int cost { get; set; } //стоимпость объекта в млн

        public string AR()
        {
            if (pur == true) return "Сдается";
            else return "Не сдается";
        }
        public ObjecrtRealties() { pur = false; name = "Пусто"; cost = 0; }
        public ObjecrtRealties(bool p, string Name, int Cost)
        {
            pur = p;
            name = Name;
            if (Cost >= 0)
            {
                cost = Cost;
            }
            else
            {
                cost = 0;
            }
        }
        public override string ToString()
        {
            return $"Аренда: {AR()} \n Улица: {name} \n Стоимость(млн.): {cost}";
        }
        public override int GetHashCode()
        {
            return pur.GetHashCode() + name.GetHashCode() + cost.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj is ObjecrtRealties == false) return false;
            ObjecrtRealties o = obj as ObjecrtRealties;
            return name == o.name && cost == o.cost && pur == o.pur;
        }

        protected static Random rnd = new Random();
        protected static string[] names = { "Пушкина", "9-го Мая", "Академика Королева", "Белая", "Голева", "Мира", "Ленина", "Зеленая", "Камская", "Космонавтов шоссу", "Краснова", "Крылова", "Лесная", "Мысовая", "Озерная" };//15 штук
        protected static int[] costs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        protected static bool[] bo = { true, false };


    }
}
