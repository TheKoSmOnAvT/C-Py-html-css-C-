using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ABC
{
    public class TestCollections
    {
        public class ShipName : IComparer<object>
        {
            public int Compare(object x, object y)
            {
                Ship x1 = (Ship)x;
                Ship y1 = (Ship)y;
                if (x1.Name[0] > y1.Name[0])
                {
                    return 1;
                }
                else if (x1.Name[0] < y1.Name[0])
                {
                    return -1;
                }

                return -1;
            }
        }

        public Queue<Ship> queue_1 {  get ;set;}
        public Queue<string> queue_2 {  get; set; }
        public SortedDictionary <Ship,Parusnik> sd_1 {  get; set; }
        public SortedDictionary <string, Parusnik> sd_2 {  get; set; }
        static public int Count;
        public TestCollections() 
        {
            queue_1 = new Queue<Ship>();
            queue_2 = new Queue<string>();
            sd_1 = new SortedDictionary<Ship, Parusnik>(new ShipName());
            sd_2 = new SortedDictionary<string, Parusnik>();
        }
        public void Clear()
        {
            if (Count!=0)
            {
                queue_1.Clear();
                queue_1.Clear();
                sd_1.Clear();
                sd_2.Clear();
                Count = 0;
                Console.WriteLine("коллекция удалена");
            }
            else throw new TestCollectionException("коллекция уже пуста");
        }
        static Random rand = new Random();
        static public Parusnik Random()
        {
            string[] nazv = { "ленин", "сталин", "курск", "пермь", "москва", "владивосток", "казань", "молотов", "стрела", "искра", "путин", "мир", "россия", "нижний", "верхний", "питер", "ярославль", "сибирь", "урал", "юг" };
            string[] date = { "01.02.1990", "20.10.2000", "31.12.2020", "04.02.1869", "05.10.2017", "01.07.2001", "09.07.1555", "08.12.1988", "09.11.1000", "10.12.1789", "14.01.1956", "12.12.1758", "10.03.1098", "14.07.2008", "15.03.1999", "16.03.1997", "17.01.1992", "18.01.2006", "19.04.1899", "20.12.2058" };
            int[] cost = {100,212122,3123,4123,512313,6456,74535,8111,945456,10453465,11456,12456,13456,146456,1445,156,177,1888,1869,206 };
            int[] kp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int r1 = rand.Next(1, 20);
            int r2 = rand.Next(1, 20);
            int r3 = rand.Next(1, 20);
            int r4 = rand.Next(1, 20);
            Parusnik mas = new Parusnik(nazv[r1],date[r2],cost[r3],kp[r4]);
            return mas;
        }
        public void Add(Parusnik obj)
        {
            if (queue_1.Contains(obj.BaseShip) == false)
            {
                queue_1.Enqueue(obj.BaseShip);
                queue_2.Enqueue(obj.BaseShip.ToString());
                sd_1.Add(obj.BaseShip, obj);
                sd_2.Add(obj.BaseShip.ToString(), obj);
                Console.WriteLine("добавлен новый элемент.");
                Count++;
            }
            else
            {
                throw new TestCollectionException("Данный ключ уже есть в коллекции!");
            }
        }
        public bool Containss(Ship k)
        {
            bool ok = false;
            foreach (Ship x in queue_1)
            {
                if(x ==k)
                {
                    ok = true;
                }
            }
            return ok;
        }
        public void FormCollections(int count)
        {
            Count = count;
            for(int i = 0;i<count;)
            {
                Parusnik k = Random();
                if(queue_1.Contains(k.BaseShip) == false)
                {
                    queue_1.Enqueue(k.BaseShip);
                    queue_2.Enqueue(k.BaseShip.ToString());

                    sd_1.Add(k.BaseShip, k);
                    sd_2.Add(k.BaseShip.ToString(), k);

                    i++;
                }
            }
        }
        Queue<Ship> Removeq(Parusnik obj)
        { 
            Queue<Ship> queue_13 = new Queue<Ship>();
            foreach(Ship i in queue_1)
            {
                if(i != obj.BaseShip)
                {
                    queue_13.Enqueue(i);
                }
            }
            queue_1 = queue_13;
            return queue_1;
        }
        Queue<string> Removeq(string obj)
        {
            Queue<string> queue_13 = new Queue<string>();    
            foreach (string i in queue_2)
            {
                if (i != obj)
                {
                    queue_13.Enqueue(i);
                }
            }
            queue_2 = queue_13;
            return queue_2;
        }
        public void Remove(Parusnik obj)
        {
            if (sd_2.ContainsValue(obj) == true)
            { 
                queue_1 = Removeq(obj);
                queue_2 = Removeq(obj.BaseShip.ToString());
                sd_1.Remove(obj.BaseShip);
                sd_2.Remove(obj.BaseShip.ToString());
                Console.WriteLine("элемент удален.");
                Count--;
            }
            else
            {
                throw new TestCollectionException("Данного ключа нет в коллекции!");
            }
        }

        // подсчет времени поиска  
        //в тиках
        public void FoundFirst() //первый 
        {
            int index = 0;
            Parusnik sh = new Parusnik();
            Ship prod = new Ship();
            foreach (Parusnik x in sd_1.Values)
            {
                if (index == 0)
                {
                    sh = x;
                    prod = x.BaseShip;
                }
                index++;
            }
            Console.WriteLine("первый элемент - ");
            Stopwatch time = new Stopwatch();
            time.Start();
            long start = time.ElapsedTicks;
            bool t = queue_1.Contains(prod);
            time.Stop();
            long end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = queue_2.Contains(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_1.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsKey(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

        }
        public void FoundMiddle() //середина 
        {
            int index = 0;
            Parusnik sh = new Parusnik();
            Ship prod = new Ship();
            foreach (Parusnik x in sd_1.Values)
            {
                if (index == Count/2)
                {
                    sh = x;
                    prod = x.BaseShip;
                }
                index++;
            }
            Console.WriteLine("средний элемент - ");
            Stopwatch time = new Stopwatch();
            time.Start();
            long start = time.ElapsedTicks;
            bool t = queue_1.Contains(prod);
            time.Stop();
            long end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = queue_2.Contains(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_1.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsKey(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

        }
        public void FoundLast() //последний 
        {
            int index = 0;
            Parusnik sh = new Parusnik();
            Ship prod = new Ship();
            foreach (Parusnik x in sd_1.Values)
            {
                if (index == (Count-1))
                {
                    sh = x;
                    prod = x.BaseShip;
                }
                index++;
            }
            Console.WriteLine("последний элемент - ");
            Stopwatch time = new Stopwatch();
            time.Start();
            long start = time.ElapsedTicks;
            bool t = queue_1.Contains(prod);
            time.Stop();
            long end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = queue_2.Contains(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_1.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsKey(prod.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsValue(sh);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

        }

        public void FoundNone() //элемента нет
        {
            Parusnik kors = new Parusnik("0","0",0,0);
            Ship kor = kors.BaseShip;
            Console.WriteLine("Элемент, которого нет - ");
            Stopwatch time = new Stopwatch();
            time.Start();
            long start = time.ElapsedTicks;
            bool t = queue_1.Contains(kor);
            time.Stop();
            long end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = queue_2.Contains(kor.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " queue_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_1.ContainsKey(kor);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_1 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsKey(kor.ToString());
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));

            time.Start();
            start = time.ElapsedTicks;
            t = sd_2.ContainsValue(kors);
            time.Stop();
            end = time.ElapsedTicks;
            Console.WriteLine(t + " sd_2 - " + (end - start));
        }
    }
}
