using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Korvert : Steamer
    {
        private int kolgun;

        public int Kolgun
        {
            get { return kolgun; }
            set
            {
                if (value > 1)
                {
                    kolgun = value;
                }
                else
                {
                    kolgun = 0;
                }
            }
        }

        public Korvert()
           : base() { }

        public Korvert(string name, string date, int cost, int maxspeed, int kolm, int probeg, int kolgun)
            : base(name, date, cost, maxspeed, kolm, probeg)
        {
            Kolgun = kolgun;
        }
        public override void Show()
        {
            Console.Write($"{Name} стоимостью {Cost} млн. рублей, изготовлен {Date}, максимальная скорость {Maxspeed}, колличество моторов{Kolm}, пробег {Probeg}, кол. орудий {Kolgun}" + " шт. \n");
        }

        public Steamer BasePerson
        {
            get
            {
                return new Steamer(name, date, cost, maxspeed, kolm, probeg);
            }
        }

        public override string ToString()
        {
            return Name + " " + Cost + " " + Date + " " + Maxspeed + " " + Kolm + " " + Probeg + " " + Kolgun;
        }
    }
}
