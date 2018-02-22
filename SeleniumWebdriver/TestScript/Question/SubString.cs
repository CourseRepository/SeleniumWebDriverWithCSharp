using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.Question
{
    public class SubString
    {

        public static String GetSubString(String sentance,int begIndex,int endIndex)
        {
            if (endIndex > sentance.Length || begIndex < 0)
                throw new Exception(string.Format("Index value is not proper {0},{1}", begIndex, endIndex));
            return sentance.Substring(begIndex, (endIndex - begIndex));
        }
    }
}
