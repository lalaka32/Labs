using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    [Serializable]
   public class Team : INameAndCopy,IComparable
    {
        public string Name { get; set ; }
        protected string nameOfOrganisation;
        protected int regNumber;
        public string NameOfOrganisation { get; set; }
        public int RegNumber
        {
            get { return regNumber; }
            set {
                if (value <=0)
                {
                    throw new ArgumentException(" <=0 ");
                }
                regNumber = value;
            }
        }

        public Team(string name="", string nameOfOrganisation="", int regNumber=1)
        {
            Name = name;
            this.NameOfOrganisation = nameOfOrganisation;
            this.RegNumber = regNumber;
        }
        public override bool Equals(object obj)
        {
            if (obj is Team)
            {
                return this == (Team)obj;
            }
            return false;
        }
        static public bool operator ==(Team obj1, Team obj2)
        {
            if (obj1 is Team && obj2 is Team)
            {
                return obj1.Name == obj1.Name && obj1.NameOfOrganisation == obj2.NameOfOrganisation && obj1.RegNumber == obj2.RegNumber;
            }
            return false;
        }
        static public bool operator !=(Team obj1, Team obj2)
        {
            return !(obj1 == obj2);
        }
        public virtual object DeepCopy()
        {
            return this.MemberwiseClone() ;
        }
        public override string ToString()
        {
            return this.Name+" "+this.NameOfOrganisation+" "+this.regNumber;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode()*NameOfOrganisation.GetHashCode()*regNumber.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Team temp = obj as Team;
            if (temp == null)
            {
                throw new ArgumentException("Not a team");
            }
            else
            {
                return regNumber.CompareTo(temp.regNumber);
            }
        }
    }
}
