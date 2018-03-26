using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get { return Subject; }
            set { Subject = value; }
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
                if (papers.Last()!=null)
                {
                    return papers.Last();
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

    }
}
