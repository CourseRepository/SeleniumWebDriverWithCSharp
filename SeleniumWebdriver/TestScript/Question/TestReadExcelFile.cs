using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    [TestClass]
    public class TestReadExcelFile
    {
        [TestMethod]
        public void TestReadExcel()
        {
            FileStream stream = new FileStream(@"C:\Users\rathr1\Desktop\KDD.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataTable table = reader.AsDataSet().Tables["TC01"];

            for(int i = 0; i < table.Rows.Count; i++)
            {
                var col = table.Rows[i];
                for(int j = 0; j < col.ItemArray.Length; j++)
                {
                    Console.WriteLine(col.ItemArray[j]);
                }
            }

            reader.Close();
            stream.Close();

        }
    }
}
