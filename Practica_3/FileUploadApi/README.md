# FileUploadApi - API para Subir Archivos

API Web de ASP.NET Core para subir y gestionar archivos.

## 📋 Requisitos

- .NET SDK 8.0 o superior

## 🚀 Cómo ejecutar el proyecto

### 1. Restaurar dependencias
```bash
dotnet restore
```

### 2. Ejecutar la aplicación
```bash
dotnet run
```

La API estará disponible en:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001
- Swagger UI: http://localhost:5000/swagger

## 📌 Endpoints disponibles

### 📤 POST - Subir archivo
- **Endpoint**: `/api/FileUpload/upload`
- **Body**: form-data con key "file"
- **Respuesta**: Información del archivo subido

### 📋 GET - Listar todos los archivos
- **Endpoint**: `/api/FileUpload/files`
- **Respuesta**: Lista con nombre, tamaño, fechas de todos los archivos

### 🔍 GET - Información de un archivo
- **Endpoint**: `/api/FileUpload/files/{fileName}`
- **Ejemplo**: `/api/FileUpload/files/documento.pdf`
- **Respuesta**: Detalles completos del archivo

### 📥 GET - Descargar archivo
- **Endpoint**: `/api/FileUpload/download/{fileName}`
- **Ejemplo**: `/api/FileUpload/download/documento.pdf`
- **Respuesta**: Descarga el archivo

### ✏️ PUT - Actualizar/Reemplazar archivo
- **Endpoint**: `/api/FileUpload/update/{fileName}`
- **Body**: form-data con key "file" (nuevo archivo)
- **Respuesta**: Confirmación de actualización

### 🔄 PATCH - Renombrar archivo
- **Endpoint**: `/api/FileUpload/rename/{oldFileName}`
- **Body JSON**: `{ "newFileName": "nuevo_nombre.txt" }`
- **Respuesta**: Confirmación de renombrado

### 🗑️ DELETE - Eliminar un archivo
- **Endpoint**: `/api/FileUpload/delete/{fileName}`
- **Ejemplo**: `/api/FileUpload/delete/documento.pdf`
- **Respuesta**: Confirmación de eliminación

### 🗑️ DELETE - Eliminar todos los archivos
- **Endpoint**: `/api/FileUpload/deleteAll`
- **Respuesta**: Número de archivos eliminados

## 🧪 Probar con cURL

### Subir un archivo
```bash
curl -X POST http://localhost:5000/api/FileUpload/upload \
  -F "file=@/ruta/a/tu/archivo.txt"
```

### Listar archivos
```bash
curl http://localhost:5000/api/FileUpload/files
```

## 🧪 Probar con Postman

1. Abre Postman
2. Crea una nueva petición POST a `http://localhost:5000/api/FileUpload/upload`
3. En la pestaña "Body", selecciona "form-data"
4. Agrega una key llamada "file" y cambia el tipo a "File"
5. Selecciona un archivo de tu computadora
6. Haz clic en "Send"

## 📁 Estructura del proyecto

```
FileUploadApi/
├── Controllers/
│   └── FileUploadController.cs    # Controlador para subir archivos
├── Properties/
│   └── launchSettings.json        # Configuración de lanzamiento
├── UploadedFiles/                 # Carpeta donde se guardan los archivos
├── appsettings.json              # Configuración de la aplicación
├── Program.cs                     # Punto de entrada de la aplicación
└── FileUploadApi.csproj          # Archivo del proyecto
```

## ✨ Características

- ✅ Subida de archivos con validación de tipo
- ✅ **Solo acepta documentos**: PDF, Word, Excel, PowerPoint, Texto, OpenOffice
- ✅ Creación automática de carpeta de destino
- ✅ Listado de archivos subidos
- ✅ Documentación con Swagger
- ✅ CORS habilitado
- ✅ Respuestas detalladas en JSON

## 📄 Tipos de archivo permitidos

- **PDF**: .pdf
- **Word**: .doc, .docx
- **Excel**: .xls, .xlsx
- **PowerPoint**: .ppt, .pptx
- **Texto**: .txt
- **OpenOffice**: .odt (texto), .ods (hoja de cálculo), .odp (presentación)

## 🔧 Mejoras sugeridas

- Agregar validación de tipo de archivo
- Implementar límite de tamaño de archivo
- Agregar autenticación y autorización
- Implementar descarga de archivos
- Agregar eliminación de archivos
- Usar almacenamiento en la nube (Azure Blob, AWS S3)
