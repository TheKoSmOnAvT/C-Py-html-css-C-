using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace laba13
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
            Console.WriteLine("формируем myCollections, добавляем элемент, удаляем его и очищаем коллекцию.");
            MyCollections cl = new MyCollections();
            cl.Add(000, new Parusnik("1", "1", 123, 2));

            Console.WriteLine($"добавлен {cl[000].ToString()}");
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();
            cl.Remove(000);
            Console.WriteLine("======вывод словаря=====");
            cl.print();
            Console.WriteLine("========================");
            Console.WriteLine("введите количество элементов");
            int s = Convert.ToInt32(Console.ReadLine());
            while (s < 1)
            {
                Console.WriteLine("ошибка, введите количество элементов");
                s = Convert.ToInt32(Console.ReadLine());
            }
            cl.FormCollections(s);
            Console.WriteLine("===========");
            Console.WriteLine("======вывод словаря=====");
            cl.print();
            Console.WriteLine("===========");
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();
            Console.WriteLine("===========");
            cl.Clear();
            Console.WriteLine("===========");
            cl.print();
            Console.WriteLine("===========");
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();
            Console.WriteLine("Созданы 2 коллекции типа MyNewCollection");
            MyNewCollection fr = new MyNewCollection("First Collection");
            fr.FormCollections(s);
            Console.WriteLine(fr);
            MyNewCollection sc = new MyNewCollection("Second Collection");
            sc.FormCollections(s);
            Console.WriteLine(sc);

            Journal jornal_1 = new Journal();
            Journal jornal_2 = new Journal();

            Journal journalSecond = new Journal();
            fr.CollectionCoundChanged += new CollectionHandler(jornal_1.CollectionCountChanged);
            fr.CollectionReferenceChanged += new CollectionHandler(jornal_1.CollectionReferenceChanged); 

            sc.CollectionCoundChanged += new CollectionHandler(jornal_2.CollectionReferenceChanged);

            Console.WriteLine("====Добавляем====");

            fr.Add(000, new Parusnik("добавленный", "00,00,0000", 123, 2));
            fr.Add(123, new Parusnik("добавленный 1.1", "00,00,0000", 123, 2));
            sc.Add(001, new Parusnik("добавленный второй", "00,00,0000", 123, 2));
            Console.WriteLine(fr);
            Console.WriteLine(sc);
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();

            Console.WriteLine("====Удаляем====");
            fr.Remove(000);
            sc.Remove(001);


            Console.WriteLine(fr);
            Console.WriteLine(sc);
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();

            Console.WriteLine("====изменяем ссылку====");
            fr[123] = new Parusnik("изменение 2", "00,00,0000", 123, 2);
            Console.WriteLine(fr);
            Console.WriteLine("нажмите кнопку, чтобы продолжить ");
            Console.ReadKey();
            Console.WriteLine("Вывод конечных коллекций");
            Console.WriteLine(fr);
            Console.WriteLine("\n" + sc);
            Console.WriteLine("\n" + jornal_1);
            Console.WriteLine("\n" + jornal_2);
        }
    }
}
