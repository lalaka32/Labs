using System;

namespace OOP_3
{
    public class ResearchTeamsChangedEventArgs<TKey> : EventArgs
    {
        public ResearchTeamsChangedEventArgs(string name, Revision sender, int index, string sourse)
        {
            Name = name;
            Sender = sender;
            Index = index;
            Sourse = sourse;
        }

        public string Name { get; set; }
        public Revision Sender { get; set; }
        public int Index { get; set; }
        public string Sourse { get; set; }
        public override string ToString()
        {
            return string.Format($"Name :{Name}, Sender :{Sender}, Index :{Index}, Sourse :{Sourse}");
        }
    }
}