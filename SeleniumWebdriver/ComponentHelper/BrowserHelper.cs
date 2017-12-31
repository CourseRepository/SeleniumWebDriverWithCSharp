using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper
{
    public class BrowserHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BrowserHelper));
        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
            Logger.Info(" Browser Maximize ");
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();

        }

        public static void Forward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index = 0)
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }

            
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            BrowserMaximize();

        }


        public static void SwitchToParent()
        {
            var windowids = ObjectRepository.Driver.WindowHandles;


            for (int i = windowids.Count - 1; i > 0;)
            {
                ObjectRepository.Driver.Close();
                i = i - 1;
                Thread.Sleep(2000);
                ObjectRepository.Driver.SwitchTo().Window(windowids[i]);
            }
            ObjectRepository.Driver.SwitchTo().Window(windowids[0]);

        }

        public static void SwitchToFrame(By locatot)
        {
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(locatot));
        }
    }
}
