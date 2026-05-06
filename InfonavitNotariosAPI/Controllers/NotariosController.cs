using Microsoft.AspNetCore.Mvc;
using InfonavitNotariosAPI.Services;

namespace InfonavitNotariosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotariosController : ControllerBase
    {
        private readonly NotarioService _service;

        public NotariosController()
        {
            _service = new NotarioService();
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? municipio)
        {
            var data = _service.ObtenerNotarios(municipio);
            return Ok(data);
        }

        [HttpGet("excel")]
        public IActionResult DescargarExcel([FromQuery] string? municipio)
        {
            var data = _service.ObtenerNotarios(municipio);

            var excelService = new ExcelService();

            var fileBytes = excelService.GenerarExcel(data);

            var nombreArchivo = $"notarios_{municipio ?? "todos"}.xlsx";

            return File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                nombreArchivo
            );
        }

        [HttpGet("municipios")]
        public IActionResult GetMunicipios()
        {
            var municipios = _service.ObtenerMunicipios();

            return Ok(municipios);
        }
    }
}


