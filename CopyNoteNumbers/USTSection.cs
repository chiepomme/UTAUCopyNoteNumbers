using System.Collections.Generic;

namespace CopyNoteNumbers
{
    public class USTSection : Dictionary<string, string>
    {
        public string Name { get; private set; }

        public USTSection(string name)
        {
            this.Name = name;
        }
    }
}
