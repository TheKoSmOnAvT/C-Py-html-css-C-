using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba13
{
    class Journal
    {
        private List<JournalEntry> journal = new List<JournalEntry>();

        public void CollectionCountChanged(object sourse, CollectionsHandlerEventArgs e)
        {
            JournalEntry ne = new JournalEntry(e.NameCollection, e.Information, e.Link);
            journal.Add(ne);

        }
        public void CollectionReferenceChanged(object sourse, CollectionsHandlerEventArgs e)
        {
            JournalEntry ne = new JournalEntry(e.NameCollection, e.Information, e.Link.ToString());
            journal.Add(ne);
        }

        public override string ToString()
        {
            Console.WriteLine("====Журнал изменений====");
            foreach (JournalEntry x in journal)
                Console.WriteLine(x + "\n");
            return "";
        }
    }
}
