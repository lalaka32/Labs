using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    public class ResearchTeamCollection<Tkey>
    {
        public delegate void ResearchTeamsChangedHandler<TKey>(
            object source, ResearchTeamsChangedEventArgs<TKey> args);

        public string ColName { get; set; }

        public event ResearchTeamsChangedHandler<Tkey> ResearchTeamsChanged;
             
        List<ResearchTeam> rteams = new List<ResearchTeam>();
        public Dictionary<Tkey, ResearchTeam> dictionary = new Dictionary<Tkey, ResearchTeam>();

        public bool Remove(ResearchTeam rt)
        {
            var dictionaryWithValue = dictionary.Where(kvp => kvp.Value == rt).ToList();
            if (dictionaryWithValue!=null)
            {
                foreach (var item in dictionaryWithValue)
                {
                    dictionary.Remove(item.Key);
                }
                ResearchTeamsChanged(this,new ResearchTeamsChangedEventArgs<Tkey>(ColName,Revision.Remove, 1,""));
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            var dictionaryWithValue = dictionary.Where(kvp => kvp.Value == rtold).ToList();
            if (dictionaryWithValue != null)
            {
                for (int i = 0; i < dictionaryWithValue.Count; i++)
                {
                    dictionary[dictionaryWithValue[i].Key] = rtnew;
                    ResearchTeamsChanged(this, new ResearchTeamsChangedEventArgs<Tkey>(ColName, Revision.Replace, 1, ""));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public ResearchTeamCollection(string colName = "")
        {
            ColName = colName;
        }

        
        public ResearchTeam this[int index]
        {
            get
            {
                return rteams[index];
            }
            set
            {
                rteams[index] = value;
            }
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < rteams.Count; i++)
            {
                s = s + rteams[i].ToString();
            }
            return s;
        }

        public virtual string ToShortString()
        {
            string s = "";
            for (int i = 0; i < rteams.Count; i++)
            {
                s = s + rteams[i].ToShortString();
            }
            return s;
        }
        public void RnumSort()
        {
            
            ResearchTeam[] temp = rteams.ToArray();
            Array.Sort(temp);
            rteams = temp.ToList();
        }

        public void RnameSort()
        {
            ResearchTeam[] temp = rteams.ToArray();
            Array.Sort(temp, new ResearchTeam());
            rteams = temp.ToList();
        }

        public void DocsSort()
        {
            ResearchTeam[] temp = rteams.ToArray();
            Array.Sort(temp, new HelperIComparer());
            rteams = temp.ToList();
        }

        public int MinRegNum
        {
            get
            {
                int min = 0;
                int[] c = new int[rteams.Count];
                for (int i = 0; i < rteams.Count; i++)
                {
                    c[i] = rteams[i].RegNumber;
                }
                min = Enumerable.Min(c);
                return min;
            }
        }
        public IEnumerable<ResearchTeam> ResLogs
        {
            get
            {
                IEnumerable<ResearchTeam> query = rteams.Where(c1 => c1.LengthOfResearch == TimeFrame.TwoYears);
                return query;
            }
        }
        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> temp = new List<ResearchTeam>();
            IEnumerable<IGrouping<int, ResearchTeam>> query =
            from team in rteams
            where team.Persons.Count == value
            group team by team.Persons.Count;
            foreach (IGrouping<int, ResearchTeam> a in query)
            {
                foreach (ResearchTeam tmp in a)
                {
                    temp.Add(tmp);
                }
            }
            return temp;
        }
    }
}
