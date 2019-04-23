using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace laba13
{

    class MyCollections : Dictionary<int, object>
    {
        public int Count { get; set; }
        public Dictionary<int, Parusnik> DIR { get; set; }

        public void print()
        {
            foreach (KeyValuePair<int, Parusnik> pair in DIR)
            {
                Console.WriteLine("{0}, {1}",
                pair.Key,
                pair.Value.ToString());
            }
        }
        public MyCollections()
        {
            DIR = new Dictionary<int, Parusnik>();
        }
        Random rand = new Random();
        public Parusnik Random()
        {
            string[] nazv = { "ленин", "сталин", "курск", "пермь", "москва", "владивосток", "казань", "молотов", "стрела", "искра", "путин", "мир", "россия", "нижний", "верхний", "питер", "ярославль", "сибирь", "урал", "юг" };
            string[] date = { "01.02.1990", "20.10.2000", "31.12.2020", "04.02.1869", "05.10.2017", "01.07.2001", "09.07.1555", "08.12.1988", "09.11.1000", "10.12.1789", "14.01.1956", "12.12.1758", "10.03.1098", "14.07.2008", "15.03.1999", "16.03.1997", "17.01.1992", "18.01.2006", "19.04.1899", "20.12.2058" };
            int[] cost = { 100, 212122, 3123, 4123, 512313, 6456, 74535, 8111, 945456, 10453465, 11456, 12456, 13456, 146456, 1445, 156, 177, 1888, 1869, 206 };
            int[] kp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int r1 = rand.Next(1, 20);
            int r2 = rand.Next(1, 20);
            int r3 = rand.Next(1, 20);
            int r4 = rand.Next(1, 20);
            Parusnik mas = new Parusnik(nazv[r1], date[r2], cost[r3], kp[r4]);
            return mas;
        }

        public virtual void Add(int key, Parusnik value)
        {
            if (base.ContainsKey(key) == false)
            {
                base.Add(key, value);
                Console.WriteLine("элемент добавлен");
            }
            else { throw new Exception("элемент уже добавлен "); }
        }
        public virtual void Remove(int key)
        {
            if (base.ContainsKey(key) == true)
            {
                base.Remove(key);
                Console.WriteLine("элемент удален");
            }
            else { throw new Exception("элемент уже добавлен "); }
        }

        public virtual void Clear()
        {
            DIR.Clear();
            Console.WriteLine("Коллекция удалена");
        }
        public virtual void FormCollections(int lenght)
        {
            for (int i = 0; i < lenght;)
            {
                Parusnik k = Random();
                if (DIR.ContainsKey(k.GetHashCode()) == false)
                {
                    DIR.Add(k.GetHashCode(), k);
                    i++;
                }
            }
            Console.WriteLine("Коллекция создана");
        }
    }

}
