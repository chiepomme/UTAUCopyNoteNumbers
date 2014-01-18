using CopyNoteNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CopyNoteNumbersTest
{
    [TestClass]
    public class USTSectionSerializerTest
    {
        [TestMethod]
        public void 通常のセクションを正しく文字列に変換できる()
        {
            var section = new USTSection("TEST");
            section["miko"] = "pero";
            section["nana"] = "pero";
            var serializer = new USTSectionSerializer();

            string resultString = serializer.Serialize(section);
            var lines = resultString.Split('\n');

            Assert.IsTrue(lines.Contains("[#TEST]"));
            Assert.IsTrue(lines.Contains("miko=pero"));
            Assert.IsTrue(lines.Contains("nana=pero"));
        }

        [TestMethod]
        public void バージョンを正しく文字列に変換できる()
        {
            var section = new USTSection("VERSION");
            section["Version"] = "1.20";
            var serializer = new USTSectionSerializer();

            string resultString = serializer.Serialize(section);
            var lines = resultString.Split('\n');

            Assert.IsTrue(lines.Contains("[#VERSION]"));
            Assert.IsTrue(lines.Contains("UST Version 1.20"));
        }
    }
}
