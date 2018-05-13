using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_3
{
    public class TeamListHandlerEventArgs : System.EventArgs
    {
        public string NameOfCollection { get; set; }
        public string TypeOfChange { get; set; }
        public int IndexOfChange { get; set; }

        public TeamListHandlerEventArgs(string nameOfCollection, string typeOfChange, int indexOfChange)
        {
            NameOfCollection = nameOfCollection;
            TypeOfChange = typeOfChange;
            IndexOfChange = indexOfChange;
        }
        public override string ToString()
        {
            return string.Format( $"NameOfCollection : {NameOfCollection}, TypeOfChange {TypeOfChange}, IndexOfChange {IndexOfChange}");
        }
    }
}
