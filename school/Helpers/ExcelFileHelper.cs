using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using school.Core.Models;

namespace school.Helpers
{
    public class ExcelFileHelper
    {
        public static IXLWorkbook CreateExcelFile(List<Student> table)
        {
                XLWorkbook workbook = new XLWorkbook();
            
                IXLWorksheet worksheet = workbook.Worksheets.Add("Students");
                worksheet.Cell(1, 1).Value = "First Name";
                worksheet.Cell(1, 2).Value = "Last Name";
                worksheet.Cell(1, 3).Value = "Node";
                worksheet.Cell(1, 4).Value = "image";


            for (int i = 0; i < table.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = table[i].FirstName;
                    worksheet.Cell(i + 2, 2).Value = table[i].LastName;
                    worksheet.Cell(i + 2, 3).Value = table[i].Note;
                    string imagePath = table[i].StudentPhoto;
                    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open))
                    {
                   
                        IXLPicture picture = worksheet.AddPicture(imageStream)
                            .MoveTo(worksheet.Cell(i + 2, 4))
                            .WithSize(50, 50); // Set the size of the image as desired
                    }

            }
            worksheet.Rows().Height = 50;
            worksheet.Columns().Width = 20;

            return workbook;
        }
    }
}
