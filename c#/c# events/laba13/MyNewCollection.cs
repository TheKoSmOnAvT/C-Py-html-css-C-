using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace laba13
{
    public delegate void CollectionHandler(object sourse, CollectionsHandlerEventArgs args);
    class MyNewCollection : MyCollections
    {
        public event CollectionHandler CollectionCoundChanged; //событие добавление/удаление
        public event CollectionHandler CollectionReferenceChanged; //изменение ссылкок
        public string NameCollections { get; set; }
       
        public MyNewCollection(string n):base()
        {
            NameCollections = n; 
        }

        public override void Add(int k, Parusnik v)
        {
            if (base.ContainsKey(k) == true) throw new Exception("Ключ уже есть.");

            DIR.Add(k, v);
            if (CollectionCoundChanged != null)
                CollectionCoundChanged(this, new CollectionsHandlerEventArgs(NameCollections, "добавление", v));
        }
        public override void Remove(int key)
        {
            if (DIR.ContainsKey(key) == false) throw new Exception("Ключа нет.");

            
            if (CollectionCoundChanged != null)
                CollectionCoundChanged(this, new CollectionsHandlerEventArgs(NameCollections, "удаление", DIR[key]));
            DIR.Remove(key);
        }
        public override string ToString()
        {
            Console.WriteLine(NameCollections);
            int i = 0;
            foreach (object x in DIR)
                Console.WriteLine((i++) + ") " + x);
            return "";
        }
        public override void FormCollections(int size)
        {
            base.FormCollections(size);
        }
        public Parusnik this[int b]
        {
            get
            {
                return DIR[b];
            }
            set
            {
                DIR[b] = value;
                if (CollectionReferenceChanged != null)
                    CollectionReferenceChanged(this, new CollectionsHandlerEventArgs(NameCollections, "В коллекции изменена ссылка", DIR[b]));
               
            }
        }
    }
}
