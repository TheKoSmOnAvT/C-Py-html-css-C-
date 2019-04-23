using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class JournalEntry
    {
        public string NameCollection { get; set; } //имя 
        public string Move { get; set; } //действие
        public object info { get; set; } //информация

        public JournalEntry(string name, string move, object In)
        {
            NameCollection = name;
            Move = move;
            info = In;
        }
        public override string ToString()
        {
            return $"Название: {NameCollection}\n Дейтсвие: {Move}\n Информация: {info}";
        }
    }
}
