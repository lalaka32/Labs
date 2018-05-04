using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    public class ResearchTeamCollection
    {
        public string _colname { get; set; }
        List<ResearchTeam> rteams = new List<ResearchTeam>();

        void InsertAt(int j, ResearchTeam rt)
        {
            rteams.Insert(j, rt);
        }

        //public ResearchTeam this[int index]
        //{
        //    get
        //    {
        //        return rteams[index];
        //    }
        //    set
        //    {
        //        rteams[index] = value;
        //    }
        //}

        public void AddDefaults(List<ResearchTeam> a)
        {
            this.rteams.AddRange(a);
        }

        public void AddResearchTeams(params ResearchTeam[] a)
        {
            rteams.AddRange(a.ToList());
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
            
            //int n = rteams.Count;
            //ResearchTeam tmp;
            //int k = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    k = i + 1;
            //    while (k < n)
            //    {
            //        if (rteams[i].CompareTo(rteams[k]) == -1)
            //        {
            //            tmp = rteams[k];
            //            rteams[k] = rteams[i];
            //            rteams[i] = tmp;
            //            k++;
            //        }
            //        else
            //        {
            //            k++;
            //        }
            //    }
            //}
            Array.Sort(rteams.ToArray()); 
        }

        public void RnameSort()
        {
            //ResearchTeam m = new ResearchTeam();
            //int n = rteams.Count;
            //ResearchTeam tmp;
            //int k = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    k = i + 1;
            //    while (k < n)
            //    {
            //        if (m.Compare(rteams[i], rteams[k]) == 1)
            //        {
            //            tmp = rteams[k];
            //            rteams[k] = rteams[i];
            //            rteams[i] = tmp;
            //            k++;
            //        }
            //        else
            //        {
            //            k++;
            //        }
            //    }
            //}
            //return rteams;
            Array.Sort(rteams.ToArray(), new ResearchTeam());
        }


        public void DocsSort()
        {
            //CompInv<ResearchTeam> m = new CompInv<ResearchTeam>();
            //int n = rteams.Count;
            //ResearchTeam tmp;
            //int k = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    k = i + 1;
            //    while (k < n)
            //    {
            //        if (m.Compare(rteams[i], rteams[k]) == -1)
            //        {
            //            tmp = rteams[k];
            //            rteams[k] = rteams[i];
            //            rteams[i] = tmp;
            //            k++;
            //        }
            //        else
            //        {
            //            k++;
            //        }
            //    }
            //}
            Array.Sort(rteams.ToArray(), new HelperIComparer());
            //return rteams;
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
               // c.ToList();
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
