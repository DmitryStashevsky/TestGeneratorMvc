using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestImportServiceTest
    {
        [TestMethod]
        public void TestImport()
        {
            using (var stream = File.OpenRead("D://CSharp.xml"))
            {
                //TestImportService.Instance.Import(stream);
            }
        }
    }
}
