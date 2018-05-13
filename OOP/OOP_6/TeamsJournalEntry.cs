using System;

namespace OOP_3
{
    class TeamsJournalEntry
    {
        public string NameOfColl { get; set; }
        public Revision TypeOfEvent { get; set; }


        public TeamsJournalEntry(string nameOfColl, Revision typeOfEvent)
        {
            NameOfColl = nameOfColl;
            TypeOfEvent = typeOfEvent;
        }

        public override string ToString()
        {
            return string.Format($"NameOfColl :{NameOfColl}, TypeOfEvent :{TypeOfEvent}");
        }
    }
}