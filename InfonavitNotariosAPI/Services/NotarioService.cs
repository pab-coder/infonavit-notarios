using InfonavitNotariosAPI.Services;
using InfonavitNotariosAPI.Models;
using System.Text.Json;

namespace InfonavitNotariosAPI.Services
{
    public class NotarioService
    {
        public List<Notario> ObtenerNotarios(string municipio = null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "notarios.json");
            var json = File.ReadAllText(path);

            using var doc = JsonDocument.Parse(json);

            var notariosJson = doc
                .RootElement
                .GetProperty("result")
                .GetProperty("data")
                .GetProperty("notarios");

            var lista = new List<Notario>();

            foreach (var n in notariosJson.EnumerateArray())
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

            // 🔥 filtro por municipio
            if (!string.IsNullOrEmpty(municipio))
            {
                lista = lista
                    .Where(n => !string.IsNullOrEmpty(n.Localidad) &&
                                n.Localidad.Contains(municipio, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return lista;
        }

        public List<string> ObtenerMunicipios()
        {
            return ObtenerNotarios()
                .Where(n => !string.IsNullOrEmpty(n.Localidad))
                .Select(n => n.Localidad)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }
    }
}

