using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace ConsoleApp1
{
    class Program
    {
        static public void ShipPortName(List<Ship> Port)
        {
            Console.WriteLine("");
            Console.WriteLine("=====имя всех кораблей в порту=======");
            var ships = from shi in Port select shi.Name;
            foreach (var k in ships)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine("============");
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void ShipPort(List<Ship> Port)
        {
            Console.WriteLine("");
            Console.WriteLine("============");
            Console.WriteLine("Корабли в порту");
            Console.WriteLine("============");
            Console.WriteLine("");
            foreach (var k in Port)
            {
                k.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void ShipSea(List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("============");
            Console.WriteLine("Корабли в море");
            Console.WriteLine("============");
            Console.WriteLine("");
            foreach (var k in Sea)
            {
                k.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void ShipData(List<Ship> Port, List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("=====отбор по дате=======");
            Console.WriteLine("Введите год: ");
            string k = Console.ReadLine();
            var ships1 = from ship_300 in Port where (ship_300.Date == k) select ship_300;
            var ships2 = from ship_300 in Sea where (ship_300.Date == k) select ship_300;
            Console.WriteLine();
            Console.WriteLine("количество кораблей " + (ships1.Count() + ships2.Count()));
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void ShipCost(List<Ship> Port, List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("=====пересечение по цене=======");
            Console.WriteLine("");
            var ships = (from ship in Port select ship.Name).Intersect(from ship1 in Sea select ship1.Name);
            foreach (var ooo in ships)
            {
                Console.WriteLine(ooo);
            }
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void ExpensiveShip(List<Ship> Port, List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("=====Самые дорогие корабли=======");
            Console.WriteLine("самый дорогой корабль в порту = {0}", (from t in Port select t.Cost).Max());
            Console.WriteLine("самый дорогой корабль в море = {0}", (from t in Sea select t.Cost).Max());
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void CheapShip(List<Ship> Port, List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("=====Самые дешевые корабли=======");
            Console.WriteLine("самый дешевый корабль в порту = {0}", (from t in Port select t.Cost).Min());
            Console.WriteLine("самый дешевый корабль в море = {0}", (from t in Sea select t.Cost).Min());
            Console.WriteLine("============");
            Console.WriteLine("");
        }

        static public void ShipsS(List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("корабли в море, в имени которых есть пробел");
            Console.WriteLine("");
            var subset = Sea.Where(sh => sh.Name.Contains(" ")).Select(sh => sh);
            foreach (var j in subset)
            {
                j.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("");
        }
        static public void Ship_30(List<Ship> Sea)
        {
            Console.WriteLine("");
            Console.WriteLine("корабли в море, у которых цена выше 30");
            Console.WriteLine("");
            var subset = Sea.Where(h => h.Cost > 30).Select(global => global);
            foreach (var j in subset)
            {
                j.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("");
        }

        static public void Ships_Port_Date(List<Ship> Port)
        {

            Console.WriteLine("");
            Console.WriteLine("=====отбор по дате=======");
            Console.WriteLine("Введите год: ");
            Console.WriteLine("");
            string h = Console.ReadLine();
            var ob = Port.Where(k => k.Date == h).Select(k => k);
            foreach (var j in ob)
            {
                j.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("");
        }

        static public void Ship_Name(List<Ship> Port)
        {
            Console.WriteLine("Сорировка по дате");
            Console.WriteLine("");
            var k = Port.OrderBy(p => p.Date);
            foreach (var j in k)
            {
                j.Show();
            }
            Console.WriteLine("============");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            List<Ship> Sea = new List<Ship>();
            List<Ship> Port = new List<Ship>();
            Sea.Add(new Korvert("Корверт", "1970", 12, 70, 20, 25, 5));
            Port.Add(new Korvert("Корверт", "1970", 18, 55, 70, 71, 3)); //
            Sea.Add(new Korvert("Корверт 2", "1980", 15, 99, 22, 30, 8));
            Port.Add(new Korvert("Корверт 2", "1999", 15, 72, 22, 28, 12)); //

            Sea.Add(new Steamer("Пароход 1", "1955", 300, 80, 10, 10));
            Port.Add(new Steamer("Пароход 2", "1949", 12, 75, 20, 3)); //
            Port.Add(new Steamer("Пароход 3", "2028", 400, 99, 25, 6)); //
            Port.Add(new Steamer("Пароход 4", "1949", 12, 75, 20, 3)); //

            Sea.Add(new Parusnik("Парусник 1", "1922", 12, 3));
            Sea.Add(new Parusnik("Парусник 2", "1999", 12, 4));
            Port.Add(new Parusnik("Парусник", "2010", 9, 2)); //
            Port.Add(new Parusnik("Парусник", "2008", 2, 1)); //

            ShipPort(Port);
            ShipSea(Sea);
            Console.ReadKey();
            Console.WriteLine(" LINQ запросы ");
            ShipPortName(Port); //имена всех кораблей в порту
            Console.ReadKey();
            ShipData(Port, Sea); //отбор по дате
            Console.ReadKey();
            ShipCost(Port, Sea); //пересечение по имени 
            Console.ReadKey();
            ExpensiveShip(Port, Sea); //самые дорогие корабли
            Console.ReadKey();
            CheapShip(Port, Sea); //самые дешевые корабли
            Console.ReadKey();


            Console.WriteLine(" Методы расширения ");
            ShipsS(Sea); //корабли в море, в имени которых есть пробел
            Console.ReadKey();
            Ship_30(Sea); //корабли в море, у которых цена выше 30
            Console.ReadKey();
            Ships_Port_Date(Port); //отбор по дате
            Console.ReadKey();
            Ship_Name(Port); //сортировка по дате
            Console.ReadKey();
        }

    }
}
