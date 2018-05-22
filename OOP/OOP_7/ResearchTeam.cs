using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_3
{
    [Serializable]
    public class ResearchTeam : Team,IEnumerable,IComparer<ResearchTeam>, INotifyPropertyChanged
    {
        public delegate void ResearchTeamsChangedHandler<TKey>(
            object source, ResearchTeamsChangedEventArgs<TKey> args);
        TimeFrame lengthOfResearch;
        List<Paper> papers;
        List<Person> persons;

        string subject;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public ResearchTeam _DeepCopy()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    ResearchTeam contact = (ResearchTeam)formatter.Deserialize(stream);
                    return contact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool Save(string filename)
        {
            bool res = false;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
                res = true;
                return res;
            }
            catch
            {
                res = false;
                return res;
            }
        }

        public bool Load(string filename)
        {
            bool res = false;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    ResearchTeam newone = new ResearchTeam();
                    newone = (ResearchTeam)formatter.Deserialize(fs);
                    this.Name = newone.Name;
                    this.NameOfOrganisation = newone.NameOfOrganisation;
                    this.papers = newone.papers;
                    this.Persons = newone.Persons;
                    this.RegNumber = newone.RegNumber;
                }
                res = true;
                return res;
            }
            catch
            {
                res = false;
                return res;
            }
        }
        
        public void AddFromConsole()
        {
            try
            {
                string s = "";
                Console.WriteLine("Введите: Имя и фамилю автора, название документа;  разделитель - пробел");
                s = Console.ReadLine();
                String[] split = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Person per = new Person();
                per.Name = split[0];
                per.Surname = split[1];
                Persons.Add(per);

                Paper pap = new Paper();
                pap.Autor = per;
                pap.NameOfPublication = split[2];
                Papers.Add(pap);
            }
            catch (Exception)
            {

                this.AddFromConsole();
            }
            

        }
        public static bool Save(string filename, ResearchTeam obj)
        {
            bool res = false;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, obj);
                }
                res = true;
                return res;
            }
            catch
            {
                res = false;
                return res;
            }
        }
        public static bool Load(string filename, ResearchTeam obj)
        {
            bool res = false;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    ResearchTeam newone;
                    newone = (ResearchTeam)formatter.Deserialize(fs);
                    obj = newone;
                }
                res = true;
                return res;
            }
            catch
            {
                res = false;
                return res;
            }
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
