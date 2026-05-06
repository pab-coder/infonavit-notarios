</> Markdown

# Infonavit Notarios

Proyecto desarrollado en C# y ASP.NET Core para procesar información de notarías de Infonavit, filtrar por municipio y generar reportes dinámicos en Excel.

## 🚀 Características

- Procesamiento de JSON obtenido desde herramientas de desarrollo del navegador
- API REST con ASP.NET Core
- Filtro dinámico por municipio
- Generación automática de archivos Excel
- Frontend básico con HTML + JavaScript
- Descarga directa de reportes

---

## 🛠️ Tecnologías utilizadas

- C#
- ASP.NET Core
- ClosedXML
- HTML
- JavaScript
- Git / GitHub

---

## 📊 Endpoints

### Obtener notarías

```http
GET /api/notarios
```

### Filtrar por municipio

```http
GET /api/notarios?municipio=Guadalajara
```

### Obtener municipios

```http
GET /api/notarios/municipios
```

### Descargar Excel

```http
GET /api/notarios/excel?municipio=Guadalajara
```

---

## 💻 Frontend

La aplicación incluye una interfaz web básica para:

- seleccionar municipios
- consultar información
- descargar reportes Excel

---

## 🔍 Investigación del problema

Inicialmente el portal únicamente mostraba el número de notaría y el nombre del responsable dentro de un dropdown, dificultando la búsqueda manual de notarías cercanas.

Se realizó exploración utilizando las herramientas de desarrollo del navegador (DevTools F12) para analizar cómo el sitio obtenía la información.

Durante la investigación se detectaron requests que devolvían información en formato JSON, la cual fue utilizada para desarrollar este proyecto.

Posteriormente se creó una aplicación en C# para:

- procesar los datos
- filtrar por localidad
- generar reportes Excel automáticamente


## 📷 Capturas de pantalla

### Exploración del sitio

Se hace la exploración del sitio donde solo muestra el número de notaría y nombre del responsable en
 el DropDown de "Datos de la Notaria INEX".

<img width="1360" height="720" alt="image" src="https://github.com/user-attachments/assets/b07f736b-af48-4a58-83bc-d01128cd43bb" />

### Exploración con DEVTOOLS

Se utliza (DEVTOOLS F12) para la toma de información del listado JSON

<img width="1360" height="720" alt="image" src="https://github.com/user-attachments/assets/b442cfb0-566b-49a6-adf5-11b9b39511ef" />

---

## ⚙️ Cómo ejecutar

1. Clonar repositorio
2. Abrir solución en Visual Studio
3. Ejecutar proyecto ASP.NET Core
4. Abrir:

https://localhost:7012/index.html

---

## Uso de API REST 

### Frontend con dropdown de municipio y botón de descarga en archivo Excel

<img width="1360" height="720" alt="image" src="https://github.com/user-attachments/assets/ddf8b7f0-6474-4518-aab1-9ae62f9e7737" />

### Archivo de Excel con formato de tabla y filtros en las columnas

<img width="1374" height="728" alt="image" src="https://github.com/user-attachments/assets/197106ee-56a3-4557-8116-dfdf6fa56199" />

---

## 📌 Objetivo del proyecto

Automatizar la búsqueda y generación de reportes de notarías de Infonavit para evitar consultas manuales repetitivas.

---





