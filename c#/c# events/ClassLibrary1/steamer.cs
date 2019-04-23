using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Steamer : Ship
    {
        protected int maxspeed;
        protected int kolm;//колличсетво моторов
        protected int probeg;

        public int Maxspeed
        {
            get { return maxspeed; }
            set
            {
                if (value > 0)
                {
                    maxspeed = value;
                }
                else
                {
                    maxspeed = 0;
                }
            }
        }
        public int Kolm
        {
            get { return kolm; }
            set
            {
                if (value > 0)
                {
                    kolm = value;
                }
                else
                {
                    kolm = 0;
                }
            }
        }
        public int Probeg
        {
            get { return probeg; }
            set
            {
                if (value > 0)
                {
                    probeg = value;
                }
                else
                {
                    probeg = 0;
                }
            }
        }
        public Steamer()
            : base() { }
        public Steamer(string name, string date, int cost, int maxspeed, int kolm, int probeg)
            : base(name, date, cost)
        {
            Kolm = kolm;
            Maxspeed = maxspeed;
            Probeg = probeg;
        }
        public override void Show()
        {
            Console.Write($"{Name} стоимостью {Cost} млн. рублей, изготовлен {Date}, максимальная скорость {Maxspeed}, колличество моторов{Kolm}, пробег {Probeg}" + " т.км. \n");
        }
        public override string ToString()
        {
            return Name + " " + Cost + " " + Date + " " + Maxspeed + " " + Kolm + " " + Probeg;
        }
    }
}
