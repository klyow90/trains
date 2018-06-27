using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using Trains.Helpers;

namespace Trains.Tests.Helpers
{
    [TestFixture]
    public class FileReaderTest
    {
        private readonly string _Directory = "TestData";
        private readonly string _FileName = "Graph.txt";
        private readonly string _Data = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
        private string _TestDataFilePath = string.Empty;

        [SetUp]
        public void SetUp()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), _Directory);

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _TestDataFilePath = Path.Combine(path, _FileName);

            using (FileStream fs = File.Create(_TestDataFilePath))
            {
                var text = Encoding.ASCII.GetBytes(_Data);
                fs.Write(text, 0, text.Length);
            }            
        }

        [Test]
        public void ReadAllText()
        {
            var reader = new FileReader(_TestDataFilePath);
            var expected = _Data;
            Assert.AreEqual(expected, reader.ReadAllText());
        }
    }
}