using ClosedXML.Excel;
using InfonavitNotariosAPI.Models;

namespace InfonavitNotariosAPI.Services
{
    public class ExcelService
    {
        public byte[] GenerarExcel(List<Notario> lista)
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Notarios");

            // encabezados
            worksheet.Cell(1, 1).Value = "Nombre";
            worksheet.Cell(1, 2).Value = "Notaria";
            worksheet.Cell(1, 3).Value = "Telefono";
            worksheet.Cell(1, 4).Value = "Calle";
            worksheet.Cell(1, 5).Value = "Colonia";
            worksheet.Cell(1, 6).Value = "Codigo Postal";
            worksheet.Cell(1, 7).Value = "Localidad";
            worksheet.Cell(1, 8).Value = "Email";

            int row = 2;

            foreach (var n in lista)
            {
                worksheet.Cell(row, 1).Value = n.Nombre;
                worksheet.Cell(row, 2).Value = n.Notaria;
                worksheet.Cell(row, 3).Value = n.Telefono;
                worksheet.Cell(row, 4).Value = n.Calle;
                worksheet.Cell(row, 5).Value = n.Colonia;
                worksheet.Cell(row, 6).Value = n.CodigoPostal;
                worksheet.Cell(row, 7).Value = n.Localidad;
                worksheet.Cell(row, 8).Value = n.Email;

                row++;
            }

            // estilos
            var headerRange = worksheet.Range("A1:H1");
            headerRange.Style.Font.Bold = true;

            worksheet.Columns().AdjustToContents();

            var range = worksheet.RangeUsed();
            var table = range.CreateTable();
            table.Theme = XLTableTheme.TableStyleMedium2;

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}
