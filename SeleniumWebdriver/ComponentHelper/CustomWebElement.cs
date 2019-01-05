using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class CustomWebElement : RemoteWebElement
    {
        private string ElementName = "Default Name";
        public string Name
        {
            set
            {
                ElementName = value;
            }
        }

        public CustomWebElement(RemoteWebDriver parentDriver, string id) : base(parentDriver,id)
        {

        }

        public override string ToString()
        {
            return ElementName;
        }


    }
}
