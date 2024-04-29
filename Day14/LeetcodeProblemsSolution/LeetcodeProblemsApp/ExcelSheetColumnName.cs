using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblemsApp
{
    internal class ExcelSheetColumnName
    {
        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder columnName = new StringBuilder();

            while (columnNumber > 0)
            {
                columnNumber--;
                char charToAdd = (char)('A' + columnNumber % 26);
                columnName.Insert(0, charToAdd);
                columnNumber = columnNumber / 26;
            }

            return columnName.ToString();
        }

        static void Main(string[] args)
        {
            ExcelSheetColumnName excelSheetColumnName = new ExcelSheetColumnName();
            Console.WriteLine(excelSheetColumnName.ConvertToTitle(70));
        }
    }
}
