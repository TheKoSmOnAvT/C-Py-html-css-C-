using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace ClassLibrary1
{
    [Serializable]
    public class Realties : ISerializable
    {
        public List<Company> OR { get; set; }
        public Journal log { get; set; }
        public Realties()
        {
            OR = new List<Company>();
            OR.Add(new Company("Квартира"));
            OR.Add(new Company("Коммерческая Недвижмость"));
            OR.Add(new Company("Дом"));
            OR.Add(new Company("Жилая Недвижимость"));
            OR.Add(new Company("Магазин"));
            log = new Journal();

            foreach (var x in OR)
                // подписка на событие каждого отдела
                x.CollectionChanged += log.AddActions;
        }

        protected Realties(SerializationInfo info, StreamingContext context)
        {
            OR = (List<Company>)info.GetValue("OR", typeof(List<Company>));
            log = (Journal)info.GetValue("log", typeof(Journal));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OR", this.OR);
            info.AddValue("log", this.log);
        }

       
        public Journal Log
        {
            get
            {
                return log;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var x in OR)
                s += x.Name + "\n" + x.ToString() + "\n\n";
            return s;
        }
        public Company this[string c]
        {
            get
            {
                foreach (var x in OR)
                    if (x.Name == c)
                        return x;
                return null;
            }
        }
    }
}

