using System.Text;

namespace CopyNoteNumbers
{
    public class USTSectionSerializer
    {
        public string Serialize(USTSection section)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[#{0}]\n", section.Name);

            foreach (var pair in section)
            {
                if (section.Name == "VERSION" && pair.Key == "Version")
                    sb.AppendFormat("UST Version {0}\n", pair.Value);
                else
                    sb.AppendFormat("{0}={1}\n", pair.Key, pair.Value);
            }

            return sb.ToString();
        }
    }
}