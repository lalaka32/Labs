using System.Collections.Generic;
using System.Linq;

namespace OOP_3
{
    class ResearchTeam
    {
        string subject;
        string organization;
        int number;
        TimeFrame lengthOfResearch;
        Paper[] papers;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public TimeFrame LengthOfResearch
        {
            get { return lengthOfResearch; }
            set { lengthOfResearch = value; }
        }
        public Paper[] Papers
        {
            get { return papers; }
            set { papers=value ; }
        }
        public Paper LastPaper
        {
            get {
                if (papers[0]!=null)
                {
                    Paper minPaper = Papers[0];
                    foreach (var item in papers)
                    {
                        if (item.Date> minPaper.Date)
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
        public ResearchTeam(string subject,string organization,int number,TimeFrame lengthOfResearch)
        {
            this.subject = subject;
            this.organization = organization;
            this.number = number;
            this.lengthOfResearch = lengthOfResearch;
        }
        public ResearchTeam()
        {
            subject = "";
            organization = "";
            number = 0;
            lengthOfResearch = new TimeFrame();
        }
        public bool this [TimeFrame time]
        {
            get
            {
                if (lengthOfResearch== time)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void AddPapers (params Paper[] paper)
        {
            List<Paper> listofarticles = papers.ToList();
            listofarticles.AddRange(paper);
            papers = listofarticles.ToArray();
        }
        public override string ToString()
        {
            string listPaper="";
            foreach (Paper item in papers)
            {
                listPaper += item.NameOfPublication + " ";
            }
            return subject+" "+organization+" "+number+" "+lengthOfResearch+" "+listPaper;
        }
        public virtual string ToShortString()
        {
            return subject + " " + organization + " " + number + " " + lengthOfResearch;
        }
    }
}
