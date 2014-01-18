using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CopyNoteNumbers
{
    public class Note
    {
        public readonly int Tick;
        public int NoteNumber;

        public Note(int tick, int noteNumber)
        {
            Tick = tick;
            NoteNumber = noteNumber;
        }
    }

    public class USTFilePaster
    {
        public void Paste(string fromPath, string toPath, int offsetTick = 0)
        {
            var fromUSTSections = new USTFileSectionizer().Sectionize(fromPath);
            int tick = -offsetTick;
            var fromNotes = fromUSTSections
                .Where(s => Regex.IsMatch(s.Name, @"^\d{4}$"))
                .Select(s =>
                {
                    var length = int.Parse(s["Length"]);
                    var noteNumber = s["Lyric"] == "R" ? -1 : int.Parse(s["NoteNum"]);
                    var note = new Note(tick, noteNumber);
                    tick += length;
                    return note;
                })
                .Where(n => n.NoteNumber != -1)
                .ToList();

            var toUSTSections = new USTFileSectionizer().Sectionize(toPath);

            tick = 0;
            var toNotes = toUSTSections
                .Where(s => Regex.IsMatch(s.Name, @"^\d{4}$"))
                .Select(s =>
                {
                    var length = int.Parse(s["Length"]);
                    var noteNumber = s["Lyric"] == "R" ? -1 : int.Parse(s["NoteNum"]);
                    var note = new Note(tick, noteNumber);
                    tick += length;
                    return note;
                })
                .ToList();

            var currentIndex = 0;
            foreach (var note in toNotes)
            {
                if (currentIndex + 1 < fromNotes.Count)
                {
                    if (fromNotes[currentIndex + 1].Tick <= note.Tick)
                        currentIndex += 1;
                }

                note.NoteNumber = fromNotes[currentIndex].NoteNumber;
            }

            var toNoteSections = toUSTSections
                .Where(s => Regex.IsMatch(s.Name, @"^\d{4}$"))
                .ToList();

            for (var i = 0; i < toNoteSections.Count; i++)
            {
                toNoteSections[i]["NoteNum"] = toNotes[i].NoteNumber.ToString();
            }

            using (var writer = new StreamWriter(toPath, false, Encoding.GetEncoding(932)))
            {
                var serializer = new USTSectionSerializer();
                foreach (var section in toUSTSections)
                {
                    writer.Write(serializer.Serialize(section));
                }
            }
        }
    }
}
