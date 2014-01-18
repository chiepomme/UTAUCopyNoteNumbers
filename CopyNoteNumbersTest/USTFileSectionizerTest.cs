using CopyNoteNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CopyNoteNumbersTest
{
    [TestClass]
    public class USTFileSectionizerTest
    {
        [TestMethod]
        public void USTのバージョンを取得できる()
        {
            var sectionizer = new USTFileSectionizer();
            List<USTSection> sections = sectionizer.Sectionize(@"Fixture\Fixture.ust");
            USTSection section = sections.First(e => e.Name == "VERSION");
            Assert.AreEqual("1.20", section["Version"]);
        }

        [TestMethod]
        public void PREVセクションのパラメータを文字列として読める()
        {
            var sectionizer = new USTFileSectionizer();
            List<USTSection> sections = sectionizer.Sectionize(@"Fixture\Fixture.ust");
            USTSection section = sections.First(e => e.Name == "PREV");
            Assert.AreEqual("1260", section["Length"]);
            Assert.AreEqual("あ", section["Lyric"]);
            Assert.AreEqual("65,180,14,20,20,0,0,0", section["VBR"]);
        }

        [TestMethod]
        public void NEXTセクションのパラメータを文字列として読める()
        {
            var sectionizer = new USTFileSectionizer();
            List<USTSection> sections = sectionizer.Sectionize(@"Fixture\Fixture.ust");
            USTSection section = sections.First(e => e.Name == "NEXT");
            Assert.AreEqual("1620", section["Length"]);
            Assert.AreEqual("あ", section["Lyric"]);
            Assert.AreEqual("-57", section["PBS"]);
        }

        [TestMethod]
        public void 最初のノートのパラメータを文字列として読める()
        {
            var sectionizer = new USTFileSectionizer();
            List<USTSection> sections = sectionizer.Sectionize(@"Fixture\Fixture.ust");
            USTSection section = sections.First(e => e.Name == "0001");
            Assert.AreEqual("1440", section["Length"]);
            Assert.AreEqual("あ", section["Lyric"]);
            Assert.AreEqual("65,180,14,20,20,0,0,0", section["VBR"]);
            Assert.AreEqual("69", section["NoteNum"]);
        }
    }
}
