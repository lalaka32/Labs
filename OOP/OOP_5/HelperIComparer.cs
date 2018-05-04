using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class HelperIComparer : IComparer<ResearchTeam>
    {
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.Papers != null && y.Papers != null)
            {
                return x.Papers.Count.CompareTo(y.Papers.Count);
            }
            else
            {
                throw new ArgumentNullException("Fail to compare cause null");
            }

        }
    }
}
