using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.ObjectToListConverter;
using System.IO;

namespace LibraryManagement.ReadWriteOperations
{
    public class WriteOnFile
    {
        public void writeOnSourceFile(List<List<string>> dataList, string filePath)
        {
            var writer = new StreamWriter(filePath);

            foreach(var item in dataList)
            {
                string line = "";
                foreach(var item2 in item)
                {
                    line += item2;
                    line += ",";
                }
                writer.WriteLine(line);
                writer.Flush();
            }
        }
    }
}
