using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Grid
{
    [TestClass]
    public class TestWebTable
    {
        [TestMethod]
        public void TestGrid()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/grid/custom-command");

            /* for (int row = 1; row <= 6; row++)
             {
                 for (int col = 1; col <= 5; col++)
                 {
                     //string xpath = "//table[@id='wb-auto-1']//tbody//tr[" + row + "]//td[" + col + "]";
                     //var xpath = string.Format("//table[@id='wb-auto-1']//tbody//tr[{0}]//td[{1}]", row, col);
                     var xpath = $"//table[@id='wb-auto-1']//tbody//tr[{row}]//td[{col}]";
                     //Console.WriteLine(xpath);
                     Console.Write(ObjectRepository.Driver.FindElement(By.XPath(xpath)).Text);
                 }
                 Console.WriteLine();
             }*/
            /* Console.WriteLine(GridHelper.GetColumnValue("//table[@id='wb-auto-1']", 3, 3));
             IList<string> data = GridHelper.GetAllValues("//table[@id='wb-auto-1']");
             foreach (var str in data)
             {
                 Console.WriteLine(str);
             }*/

            GridHelper.ClickButtonInGrid("//div[@class='k-grid-content k-auto-scrollable']//table[@role='grid']", 2, 3);
        }
    }
}
