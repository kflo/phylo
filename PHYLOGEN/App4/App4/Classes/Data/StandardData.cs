using System.Collections.Generic;

namespace Phylogen.Classes.Data
{
     internal class StandardData : IDataType
     {
          public StandardData(int numberOfEntries)
          {
               NumberOfEntries = numberOfEntries;
          }

          public static int NumberOfEntries { get; set; }

          private Dictionary<string, string> _charStateLabels = new Dictionary<string, string>(NumberOfEntries);

          public void AddEntry(string name, string state)
          {
               _charStateLabels.Add(name, state);
          }

          public void RemoveEntry(string name)
          {
               _charStateLabels.Remove(name);
          }

          public int DataCount()
          {
               return _charStateLabels.Count;
          }
     }
}