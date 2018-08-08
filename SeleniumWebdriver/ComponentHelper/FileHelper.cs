using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    class FileHelper
    {
        public static String SaveScreenShot(String absolutePath, String fileName)
        {
            var dir = Directory.Exists(absolutePath);
            if (!dir)
            {
                Directory.CreateDirectory(absolutePath);
            }

            return absolutePath;

        }
    }
}
