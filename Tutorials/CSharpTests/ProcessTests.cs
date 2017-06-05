using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        [TestMethod()]
        public void RunProcessFromRelatvieFolderTest()
        {
            Process.ExecuteCommandSync(@".\ProcessTest\echo.bat");
        }
    }
}
