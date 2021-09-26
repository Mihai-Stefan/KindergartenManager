using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public List<EmployeeDTO> ReadExcell(string filePath)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            //FilePath = "./wwwroot/Worksheets/f7e249a4-d9f8-4375-bc71-a6b5db25a354.xlsx";
            //string FilePath = "C:/___CODE/_c_Sharp_Learn_projects/51_BlazorServerImportFromXcell/helping_files/Employees.xlsx";
            FileInfo existingFile = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                for (int row = 2; row <= rowCount; row++)
                {
                    EmployeeDTO employee = new EmployeeDTO();
                    for (int col = 1; col <= colCount; col++)
                        {
                        if (worksheet.Cells[row, col].Value == null) continue;
                        if (col == 1) employee.FirstName = worksheet.Cells[row, col].Value.ToString();
                        if (col == 2) employee.LastName = worksheet.Cells[row, col].Value.ToString();
                        if (col == 3) employee.Details = worksheet.Cells[row, col].Value.ToString();
                        }
                    employees.Add(employee);

                }

            }

            return employees;
        }
    }
}

