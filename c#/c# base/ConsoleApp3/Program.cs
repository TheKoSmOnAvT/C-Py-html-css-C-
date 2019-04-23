using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC;

namespace ConsoleApp3
{
    class TestCollectionException : ApplicationException
    {
        public TestCollectionException() : base() { }
        public TestCollectionException(string str) : base(str) { }
        // Переопределяем метод ToStringO для класса TestCollectionException.
        public override string ToString()
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
            while(s<1)
            {
                Console.WriteLine("ошибка, введите количество элементов");
                s = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}
