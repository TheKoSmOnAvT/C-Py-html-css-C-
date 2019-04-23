using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameCollection { get; set; } //имя коллекции
        public string Move { get; set; } //действие
        public object Link { get; set; } //ссылка на объект

        public CollectionHandlerEventArgs(string name, string move, object ln)
        {
            NameCollection = name;
            Move = move;
            Link = ln;
        }
    }
}
