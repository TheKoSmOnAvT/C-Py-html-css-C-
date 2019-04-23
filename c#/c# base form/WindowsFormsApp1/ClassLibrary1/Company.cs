using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); // делегат
    [Serializable] //mynewcollection
    public class Company : MyCollections 
    {
        public string Name { get; set; } // название направления
        public event CollectionHandler CollectionChanged; // событие об изменениях

        // конструкторы
        public Company(string CName)
            : base()
        {
            Name = CName;
        }
        public Company(string RName, IEnumerable<ObjecrtRealties> ienum)
            : base(ienum)
        {
            Name = RName;
        }

        // для десериализации
        protected Company(SerializationInfo info, StreamingContext context)
            : base(info, context) // читаем по-элементно
        {
            Name = (string)info.GetValue("CompanyName", typeof(string));  // читаем названия 
        }
        // для сериализации
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CompanyName", Name, typeof(string)); // добавляем информацию о названии
            base.GetObjectData(info, context); // добавляем по-элементно информацию об объектах
        }

        // проверка события на подписчиков
        public void OnCollectionChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionChanged != null) // если есть подписчик, то выполняем событие
                CollectionChanged(source, args);
        }

        // покупка объекта
        public override void Buy(ObjecrtRealties st)
        {
            base.Buy(st);
            OnCollectionChanged(this, new CollectionHandlerEventArgs(Name, "Покупка объекта", st));
        }
        // продажа
        public override void Sold(ObjecrtRealties st)
        {
            base.Sold(st);
            OnCollectionChanged(this, new CollectionHandlerEventArgs(Name, "Продажа объекта", st));
        }
       

        // для получения информации в виде строки
        public override string ToString()
        {
            string s = "";
            foreach (var x in this)
                s += x.ToString() + "\n\n";
            return s;
        }
       // изменение объекта
        public override void ChangeOR(ObjecrtRealties or1, ObjecrtRealties or2)
        {
            base.ChangeOR(or1, or2);
            OnCollectionChanged(this, new CollectionHandlerEventArgs(Name, "Изменение данных объекта", or2));
        }

    }

}
