using Microsoft.VisualStudio.TestTools.UnitTesting;
using SikuliSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.SikuliScript
{
    [TestClass]
    public class TestSikuliScript
    {

        private ISikuliSession session;
        private IPattern patterns;

        [TestMethod]
        public void TestSikuliIntegration()
        {
            try
            {
                session = Sikuli.CreateSession();
                patterns = Patterns.FromFile(@"C:\Data\win.PNG");
                if (session.Exists(patterns))
                {
                    Console.WriteLine("Patteren Exist " + patterns.ToString());
                    session.Wait(patterns, 60);
                    session.Click(patterns);
                }
            }
            finally
            {
                session?.Dispose();
            }
        }

    }
}
