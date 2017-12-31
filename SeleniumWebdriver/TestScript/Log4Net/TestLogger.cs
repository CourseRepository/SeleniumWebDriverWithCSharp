using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;

namespace SeleniumWebdriver.TestScript.Log4Net
{
    [TestClass]
    public class TestLogger
    {
        [TestMethod]
        public void TestLog4Net()
        {
            // 1. To create the layout
            // 2. Use this lay out in the appender
            // 3. Initialize the configuration
            // 4. Get the instance of the logger

            // var patterLayout = new PatternLayout();
            // patterLayout.ConversionPattern = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";
            // patterLayout.ActivateOptions();

            // var consoleAppender = new ConsoleAppender()
            // {
            //     Name = "ConsoleAppender",
            //     Layout = patterLayout,
            //     Threshold = Level.Error
            // };
            //// consoleAppender.ActivateOptions();
            // var fileAppender = new FileAppender()
            // {
            //     Name = "fileAppender",
            //     Layout = patterLayout,
            //     Threshold = Level.All,
            //     AppendToFile = true,
            //     File = "FileLogger.log",
            // };
            // fileAppender.ActivateOptions();

            // var rollingAppender = new RollingFileAppender()
            // {
            //     Name = "Rolling File Appender",
            //     AppendToFile = true,
            //     File = "RollingFile.log",
            //     Layout = patterLayout,
            //     Threshold = Level.All,
            //     MaximumFileSize = "1MB",
            //     MaxSizeRollBackups = 15 //file1.log,file2.log.....file15.log
            // };
            // rollingAppender.ActivateOptions();


            // BasicConfigurator.Configure(consoleAppender, fileAppender,rollingAppender);

            // ILog Logger = LogManager.GetLogger(typeof (TestLogger));

            ILog Logger = Log4NetHelper.GetLogger(typeof (TestLogger));

            for (var i = 0; i < 3000; i++)
            {
                Logger.Debug("This is Debug Information");
                Logger.Info("This is Info Information");
                Logger.Warn("This is Warn Information");
                Logger.Error("This is Error Information");
                Logger.Fatal("This is Fatal Information");
            }
           

        }

        [TestMethod]
        public void TestLog4NetSec()
        {
            //Log4NetHelper.Layout = "%message%newline";
            //ILog Logger = Log4NetHelper.GetLogger(typeof(TestLogger));
            ILog Logger = Log4NetHelper.GetXmlLogger(typeof (TestLogger));

            for (var i = 0; i < 3000; i++)
            {
                Logger.Debug("This is Debug Information");
                Logger.Info("This is Info Information");
                Logger.Warn("This is Warn Information");
                Logger.Error("This is Error Information");
                Logger.Fatal("This is Fatal Information");
            }


        }
    }
}
