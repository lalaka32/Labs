using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOP_3
{
    public class ResearchTeam : Team,IEnumerable,IComparer<ResearchTeam>
    {

        TimeFrame lengthOfResearch;
        List<Paper> papers;
        List<Person> persons;

        string subject;

        public TimeFrame LengthOfResearch
        {
            get { return lengthOfResearch; }
            set { lengthOfResearch = value; }
        }
        public List<Paper> Papers
        {
            get { return papers; }
            set { papers = value; }
        }
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }
        public Paper LastPaper
        {
            get {
                if (papers.Count != 0)
                {
                    Paper minPaper = (Paper)Papers[0];
                    foreach (Paper item in papers)
                    {
                        if (item.Date > minPaper.Date)
                        {
                            minPaper = item;
                        }
                    }
                    return minPaper;
                }
                else
                {
                    return null;
                }
            }
        }

        public Team Team
        {
            get { return new Team(Name,NameOfOrganisation,regNumber); }
            set {
                Name = value.Name;
                nameOfOrganisation = value.NameOfOrganisation;
                regNumber = value.RegNumber;
            }
        }

        public ResearchTeam(string name="", string organization="", int number=1, string subject = "", TimeFrame lengthOfResearch=TimeFrame.Year) : base(name, organization, number)
        {
            this.lengthOfResearch = lengthOfResearch;
            this.subject = subject;
            papers = new List<Paper>();
            persons = new List<Person>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int n = papers.Count;
            int n1 = persons.Count;
            for (int i = 0; i < n1; i++)
            {
                int k = 0;
                for (int j = 0; j < n; j++)
                {
                    if (persons[i] != ((Paper)papers[j]).Autor)
                    {
                        k++;
                    }
                    if (k == n)
                    {
                        yield return ((Person)persons[i]).ToString();
                    }
                }
            }
            yield break;
        }

        public IEnumerable Publications(int t)
        {
            int n = papers.Count;
            for (int i = 0; i < n; i++)
            {
                if (((Paper)papers[i]).Date.Year >= t)
                {
                    yield return ((Paper)papers[i]).NameOfPublication;
                }
            }
            yield break;
        }
        public void AddPapers(params Paper[] paper)
        {
            papers.AddRange(paper);
        }
        public void AddMembers(params Person[] person)
        {
            persons.AddRange(person);
        }
        public override string ToString()
        {
            string listPaper = "";
            foreach (Paper item in papers)
            {
                listPaper += item.NameOfPublication + " ";
            }
            return Name + " " + NameOfOrganisation + " " + regNumber + " " + lengthOfResearch + " " + listPaper;
        }
        public virtual string ToShortString()
        {
            return Name + " " + NameOfOrganisation + " " + regNumber + " " + lengthOfResearch;
        }
        public override object DeepCopy()
        {
            ResearchTeam copy= (ResearchTeam)MemberwiseClone();
            copy.Papers = new List<Paper>(papers);
            copy.Persons = new List<Person>(persons);
            return copy;
        }

        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.subject!=null && y.subject != null)
            {
                return x.subject.CompareTo(y.subject);
            }
            else
            {
                throw new ArgumentNullException("Fail to compare cause null");
            }
           
        }
    }
}
