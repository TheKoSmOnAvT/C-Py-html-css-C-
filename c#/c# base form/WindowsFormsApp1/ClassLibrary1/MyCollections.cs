using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
    [Serializable]
    public class MyCollections : LinkedList<ObjecrtRealties>
    {
        public MyCollections()
              : base()
        { }
        public MyCollections(IEnumerable<ObjecrtRealties> st)
            : base(st)
        { }

        // для десериализации
        // Иначе будет ошибка десериализации с требованием конструктора десериализации
        protected MyCollections(SerializationInfo info, StreamingContext context)
        {
            int length = (int)info.GetValue("count", typeof(int)); // читаем информацию о количестве
            ObjecrtRealties x;
            for (int i = 0; i < length; i++) // по элементно читаем объекты и добавляем в конец коллекции
            {
                x = (ObjecrtRealties)info.GetValue(i.ToString(), typeof(ObjecrtRealties));
                base.AddLast(x);
            }
        }
        // для сериализации
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("count", Count);  // добавляем информацию о количестве элементов в компании
            int i = 0;
            for (var x = First; i < Count; x = x.Next, i++) // поэлементно добавляем информацию об объектах
                info.AddValue(i.ToString(), x.Value);
        }

        //изменение
        public virtual void ChangeOR(ObjecrtRealties or1, ObjecrtRealties or2) //старое - новое
        {
            var x = this.First;
            while (x.Value != or1) //идем до старого значения
            {
                x = x.Next;
            }
            x.Value = or2; // меняем значение 
        }
      
        //покупка
        public virtual void Buy(ObjecrtRealties or)
        {
            if (base.Contains(or) == true) throw new Exception("Объект уже есть в списке");
            else base.AddLast(or);
        }
        // Продажа объекта
        public virtual void Sold(ObjecrtRealties or)
        {
            if (base.Contains(or) == false) throw new Exception("Нет заданного объекта");
            else base.Remove(or);
        }


    }
}
