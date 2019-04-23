using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class Journal
    {
        private List<JournalEntry> journal;

        public Journal()
        {
            journal = new List<JournalEntry>();
        }
        public override string ToString()
        {
            string str = "";
            foreach (JournalEntry x in journal)
                str = str + x.ToString() + "\n\n";
            return str;
        }
        public void AddActions(object s, CollectionHandlerEventArgs arg)
        {
            journal.Add(new JournalEntry(arg.NameCollection,arg.Move,arg.Link));
        }
    }
}
