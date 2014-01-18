using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CopyNoteNumbers
{
    public class USTFileSectionizer
    {
        const string SectionNamePattern = @"^\[#(.+)\]$";
        const string KeyValuePattern = @"^([^=]+?)=(.*)$";
        const string VersionPattern = @"^UST Version ([0-9.]+)$";

        USTSection CurrentSection;

        public List<USTSection> Sectionize(string ustPath)
        {
            var sections = new List<USTSection>();
            using (var reader = new StreamReader(ustPath, Encoding.GetEncoding(932)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var versionMatch = Regex.Match(line, VersionPattern);
                    if (versionMatch.Success)
                    {
                        ReadVersion(versionMatch);
                        continue;
                    }

                    var keyValueMatch = Regex.Match(line, KeyValuePattern);
                    if (keyValueMatch.Success)
                    {
                        if (CurrentSection == null)
                            throw new InvalidDataException("こんなファイル絶対おかしいよ！！\n" + ustPath + "\n" + line);
                        ReadKeyValue(keyValueMatch);
                        continue;
                    }

                    var sectionNameMatch = Regex.Match(line, SectionNamePattern);
                    if (sectionNameMatch.Success)
                    {
                        if (CurrentSection != null)
                        {
                            sections.Add(CurrentSection);
                            CurrentSection = null;
                        }
                        ReadSectionName(sectionNameMatch);
                        continue;
                    }

                    throw new InvalidDataException("こんなファイル絶対おかしいよ！！\n" + ustPath + "\n" + line);
                }
            }
            if (CurrentSection != null)
                sections.Add(CurrentSection);
            return sections;
        }

        void ReadVersion(Match match)
        {
            var version = match.Groups[1].Value;
            CurrentSection["Version"] = version;
        }

        void ReadKeyValue(Match match)
        {
            var key = match.Groups[1].Value;
            var value = match.Groups[2].Value;
            CurrentSection[key] = value;
        }

        void ReadSectionName(Match match)
        {
            var name = match.Groups[1].Value;
            CurrentSection = new USTSection(name);
        }
    }
}
