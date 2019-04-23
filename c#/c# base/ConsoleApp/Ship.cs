using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class Ship 
    {
        protected string name;
        protected string date;
        protected int cost;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                if (value > 0)
                    cost = value;
                else
                    cost = 0;
            }
        }

        public Ship() { }
        public Ship(string name, string date, int cost)
        {
            Name = name;
            Date = date;
            Cost = cost;
        }

        public override string ToString()
        {
            return Name + " " + Date + " " + Cost;
        }
        public override bool Equals(object obj)
        {
            Ship k = (Ship)obj;
            return Name == k.Name && Date == k.Date && Cost ==k.Cost ;
        }
    }
}
