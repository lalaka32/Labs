using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class TeamsJournal<Kkey>
    {
        List<TeamsJournalEntry> list = new List<TeamsJournalEntry>();
        public void Add(object obj, ResearchTeamsChangedEventArgs<Kkey> e)
        {
            list.Add(new TeamsJournalEntry(e.Name,e.Sender));
        }
        public override string ToString()
        {
            string temp = "";
            foreach (TeamsJournalEntry item in list)
            {
                temp += item.ToString()+"\n";
            }
            return temp;
        }

    }
}
