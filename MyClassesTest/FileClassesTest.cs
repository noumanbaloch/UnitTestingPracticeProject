using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileClassesTest : TestBase
    {
        
        private const string BAD_FILE_NAME = @"C:\Winldows\PFRO.log";
        [TestMethod]
        public void FileNameDoesExist()
        {
            var fileProcess = new FileProcess();
            SetGoodFileName();

            if(!string.IsNullOrWhiteSpace(_GoodFileName))
            {
                File.AppendAllText(_GoodFileName, "Some text");
            }

            bool fromCall = fileProcess.FileExists(_GoodFileName);

            if(File.Exists(_GoodFileName))
            {
                File.Delete(_GoodFileName);
            }
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            var fileProcess = new FileProcess();

            bool fromCall = fileProcess.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            var fileProcess = new FileProcess();

            fileProcess.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            try
            {
                var fileProcess = new FileProcess();

                fileProcess.FileExists("");
            }
            catch (ArgumentNullException)
            {

                return;
            }

            Assert.Fail("Call to FileExists() did not throw an ArgumentNullException.");
            
        }

    }
}