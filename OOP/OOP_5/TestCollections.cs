using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_3
{
    public class TestCollections
    {
        List<Team> teams = new List<Team>();
        List<string> strings = new List<string>();
        Dictionary<Team, ResearchTeam> dictionary1 = new Dictionary<Team, ResearchTeam>();
        Dictionary<string, ResearchTeam> dictionary2 = new Dictionary<string, ResearchTeam>();

        public static List<ResearchTeam> Generate(int n)
        {
            ResearchTeam[] a = new ResearchTeam[n];
            Person a1 = new Person();
            Paper a2 = new Paper();
            a2.Autor = a1;

            for (int i = 0; i < n; i++)
            {
                a[i] = new ResearchTeam();
                a[i].NameOfOrganisation = string.Format($"{i}");
                a[i].Persons.Add(a1);
                a[i].Papers.Add(a2);
            }

            return a.ToList();
        }

        public TestCollections(int value)
        {
            List<ResearchTeam> a = new List<ResearchTeam>(value);
            a = Generate(value);

            for (int i = 0; i < value; i++)
            {
                teams.Add(a[i].Team);
                strings.Add(teams[i].ToString() + teams[i].GetHashCode());
                dictionary1.Add(teams[i], a[i]);
                dictionary2.Add(strings[i], a[i]);
            }
        }

        public string GetTime()
        {
            string s = "";

            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < teams.Count; i++)
            {
                Thread.Sleep(1);
                if (i + 1 >= teams.Count) break;
                if (teams[i] == teams[i + 1])
                {
                    break;
                }
            }
            t.Stop();
            TimeSpan ts = t.Elapsed;
            int tt = ts.Milliseconds;

            t.Start();
            for (int i = 0; i < strings.Count; i++)
            {
                Thread.Sleep(1);
                if (i + 1 >= strings.Count) break;
                if (strings[i] == strings[i + 1])
                {
                    break;
                }
            }
            t.Stop();
            TimeSpan ts2 = t.Elapsed;
            int tt2 = ts.Milliseconds;

            t.Start();
            for (int i = 0; i < dictionary1.Count; i++)
            {
                Thread.Sleep(1);
                if (i + 1 >= dictionary1.Count) break;
                if (dictionary1[teams[i]] == dictionary1[teams[i + 1]])
                {
                    break;
                }
            }
            t.Stop();
            TimeSpan ts3 = t.Elapsed;
            int tt3 = ts.Milliseconds;

            t.Start();
            for (int i = 0; i < dictionary2.Count; i++)
            {
                Thread.Sleep(1);
                if (i + 1 >= dictionary2.Count) break;
                if (dictionary2[strings[i]] == dictionary2[strings[i + 1]])
                {
                    break;
                }
            }
            t.Stop();
            TimeSpan ts4 = t.Elapsed;
            int tt4 = ts.Milliseconds;
            s = "Time List<Team>:" + tt + " " + "Time List<string>:" + tt2 + " " + "Time Dictionary<Team,ResearchTeam>:" + tt3 + " " + "Time Dictionary<Team,ResearchTeam>:" + tt4;
            return s;
        }
    }
}
