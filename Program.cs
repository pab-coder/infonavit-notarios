using InfonavitNotarios.Models;
using System.Text.Json;
using ClosedXML.Excel;

// leer archivo
var json = File.ReadAllText("notarios.json");

// parsear JSON
using var doc = JsonDocument.Parse(json);

var notarios = doc
    .RootElement
    .GetProperty("result")
    .GetProperty("data")
    .GetProperty("notarios");

var lista = new List<Notario>();

foreach (var n in notarios.EnumerateArray())
{
    lista.Add(new Notario
    {
        Nombre = n.GetProperty("noNombre").GetString(),
        Notaria = n.GetProperty("notaria").GetString(),
        Telefono = n.TryGetProperty("telefono", out var tel) ? tel.GetString() : "",
        Calle = n.TryGetProperty("calle", out var calle) ? calle.GetString() : "",
        Colonia = n.TryGetProperty("colonia", out var col) ? col.GetString() : "",
        CodigoPostal = n.TryGetProperty("codigopostal", out var cp) ? cp.GetString() : "",
        Localidad = n.TryGetProperty("localidad", out var loc) ? loc.GetString() : "",
        Email = n.TryGetProperty("email", out var email) ? email.GetString() : ""
    });
}

Console.WriteLine($"Total de notarios: {lista.Count}\n");

foreach (var n in lista)
{
    Console.WriteLine($"{n.Nombre} - {n.Localidad}");
}

//Filtrar por localidad
Console.Write("Ingresa municipio: ");
string municipio = Console.ReadLine();

var resultado = lista
    .Where(n => !string.IsNullOrEmpty(n.Localidad) &&
                n.Localidad.Contains(municipio, StringComparison.OrdinalIgnoreCase))
    .ToList();

Console.WriteLine($"Total encontrados: {resultado.Count}");

var workbook = new XLWorkbook();
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

// llenar datos
int row = 2;

foreach (var n in resultado)
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

// encabezados en negritas
var headerRange = worksheet.Range("A1:H1");
headerRange.Style.Font.Bold = true;

// ajustar columnas automáticamente
worksheet.Columns().AdjustToContents();

// Convertir a Tabla
var range = worksheet.RangeUsed();
var table = range.CreateTable();
table.Theme = XLTableTheme.TableStyleMedium2;

// guardar archivo
//workbook.SaveAs("notarios.xlsx");

var nombreArchivo = $"notarios_{municipio}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

var rutaDescargas = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
    "Downloads",
    nombreArchivo
);

workbook.SaveAs(rutaDescargas);

Console.WriteLine("Excel generado 🚀");