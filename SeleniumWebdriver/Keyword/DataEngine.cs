using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.ExcelReader;

namespace SeleniumWebdriver.Keyword
{
    public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameterCol;

        public DataEngine(int keywordCol = 2, int locatorTypeCol = 3, int locatorValueCol = 4, int parameterCol = 5)
        {
            this._keywordCol = keywordCol;
            this._locatorTypeCol = locatorTypeCol;
            this._locatorValueCol = locatorValueCol;
            this._parameterCol = parameterCol;
        }

        private By GetElementLocator(string locatorType,string locatorValue)
        {
            switch (locatorType)
            {
                case "ClassName":
                    return By.ClassName(locatorValue);
                case "CssSelector":
                    return By.CssSelector(locatorValue);
                case "Id":
                    return By.Id(locatorValue);
                case "PartialLinkText":
                    return By.PartialLinkText(locatorValue);
                case "Name":
                    return By.Name(locatorValue);
                case "XPath":
                    return By.XPath(locatorValue);
                case "TagName":
                    return By.TagName(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }

        private void PerformAction(string keyword,string locatorType, string locatorValue,params string[] args)
        {
            switch (keyword)
            {
                case "Click":
                    ButtonHelper.ClickButton(GetElementLocator(locatorType,locatorValue));
                    break;
                case "SendKeys":
                   TextBoxHelper.TypeInTextBox(GetElementLocator(locatorType,locatorValue),args[0]);
                    break;
                case "Select":
                    ComboBoxHelper.SelectElementByValue(GetElementLocator(locatorType,locatorValue),args[0]);
                    break;
                case "WaitForEle":
                    GenericHelper.WaitForWebElementInPage(GetElementLocator(locatorType, locatorValue),
                        TimeSpan.FromSeconds(50));
                    break;
                case "Navigate":
                   NavigationHelper.NavigateToUrl(args[0]);
                    break;
                default:
                    throw new NoSuchKeywordFoundException("Keyword Not Found : " + keyword);
            }
        }

        public void ExecuteScript(string xlPath, string sheetName)
        {
            int totalRows = ExcelReaderHelper.GetTotalRows(xlPath, sheetName);
            for (int i = 1; i < totalRows; i++)
            {
                var lctType = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorTypeCol).ToString();
                var lctValue = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorValueCol).ToString();
                var keyword = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _keywordCol).ToString();
                var param = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _parameterCol).ToString();
                PerformAction(keyword,lctType,lctValue,param);
            }
        }
      
    }
}
