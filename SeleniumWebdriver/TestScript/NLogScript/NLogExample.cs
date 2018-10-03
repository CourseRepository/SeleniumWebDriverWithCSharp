using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebdriver.TestScript.NLogScript
{
    [TestClass]
    public class NLogExample
    {
        private NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void TestNLogMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Logger.Trace("Sample trace message");
                Logger.Debug("Sample debug message");
                Logger.Info("Sample informational message");
                Logger.Warn("Sample warning message");
                Logger.Error("Sample error message");
                Logger.Fatal("Sample fatal error message");
            }
        }
    }
}
