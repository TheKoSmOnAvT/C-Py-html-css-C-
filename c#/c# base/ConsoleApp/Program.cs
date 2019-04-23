using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC;

namespace ABC
{
    class TestCollectionException : ApplicationException
    {
        // Реализуем стандартные конструкторы,
        public TestCollectionException() : base() { }
        public TestCollectionException(string str) : base(str) { }

        public override string ToString()  // Переопределяем метод  для класса TestCollectionException
        {
            return Message;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите количество элементов");
            int s = Convert.ToInt32(Console.ReadLine());
            while (s < 1)
            {
                Console.WriteLine("ошибка, введите количество элементов");
                s = Convert.ToInt32(Console.ReadLine());
            }

            TestCollections ts = new TestCollections();
            ts.FormCollections(s);
            Console.WriteLine("==формирование и поиск==");
            ts.FoundFirst();
            Console.WriteLine();
            ts.FoundMiddle();
            Console.WriteLine();
            ts.FoundLast();
            Console.WriteLine();
            ts.FoundNone();
            Console.WriteLine();


            Console.WriteLine("=======");
            Parusnik kor1 = new Parusnik("0", "00.00.0000", 0000, 0);
            Parusnik kor2 = new Parusnik("1", "01.01.0001", 0001, 1);
            try
            {
                ts.Add(kor2);
                ts.Add(kor1);
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }
            try
            {
                ts.Add(kor1);
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }
            try
            {
                ts.Remove(kor2);
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }
            try
            {
                ts.Remove(kor1);
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }
            try
            {
                ts.Remove(kor1);
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }

            try
            {
                ts.Clear();
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }

            try
            {
                ts.Clear();
            }
            catch (TestCollectionException m)
            {
                Console.WriteLine(m.Message);
            }
        }
    }
}
