using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.ExcelReader;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using xl=SeleniumWebdriver.ExcelReader.ExcelReaderHelper;

namespace SeleniumWebdriver.DataDriven.Script
{
    [TestClass]
    public class TestCreateBug
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=C:\downloads\ExcelData.xlsx;", "TestExcelData$", DataAccessMethod.Sequential)]
        //[DeploymentItem(@"DataDriven\TestDataFiles", @"DataDriven\TestDataFiles")]
        public void TestBug()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage =  loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            bugPage.SelectFromCombo(TestContext.DataRow["Severity"].ToString(), TestContext.DataRow["HardWare"].ToString(), TestContext.DataRow["OS"].ToString());
            bugPage.TypeIn(TestContext.DataRow["Summary"].ToString(), TestContext.DataRow["Desc"].ToString());
            bugPage.ClickSubmit();
            bugPage.Logout();
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void TestBugDdF()
        {
            string xlPath = @"C:\downloads\ExcelData.xlsx";
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            //bugPage.SelectFromCombo(TestContext.DataRow["Severity"].ToString(), TestContext.DataRow["HardWare"].ToString(), TestContext.DataRow["OS"].ToString());
            //bugPage.TypeIn(TestContext.DataRow["Summary"].ToString(), TestContext.DataRow["Desc"].ToString());
            bugPage.SelectFromCombo(xl.GetCellData(xlPath, "TestExcelData",1,0).ToString(), xl.GetCellData(xlPath, "TestExcelData", 1, 1).ToString(), ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 2).ToString());
            bugPage.TypeIn(ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 3).ToString(), ExcelReaderHelper.GetCellData(xlPath, "TestExcelData", 1, 4).ToString());
            bugPage.ClickSubmit();
            bugPage.Logout();
            Thread.Sleep(5000);
        }



    }
}
