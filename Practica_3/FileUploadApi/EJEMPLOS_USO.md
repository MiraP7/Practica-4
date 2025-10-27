# 📘 Ejemplos de Uso - File Upload API

## 🧪 Pruebas con cURL

### 1. Subir un archivo (POST)
```bash
curl -X POST http://localhost:5000/api/FileUpload/upload \
  -F "file=@/ruta/a/tu/archivo.txt"
```

### 2. Listar todos los archivos (GET)
```bash
curl http://localhost:5000/api/FileUpload/files
```

### 3. Obtener información de un archivo específico (GET)
```bash
curl http://localhost:5000/api/FileUpload/files/archivo.txt
```

### 4. Descargar un archivo (GET)
```bash
curl -O http://localhost:5000/api/FileUpload/download/archivo.txt
```

### 5. Actualizar un archivo existente (PUT)
```bash
curl -X PUT http://localhost:5000/api/FileUpload/update/archivo.txt \
  -F "file=@/ruta/a/nuevo_archivo.txt"
```

### 6. Renombrar un archivo (PATCH)
```bash
curl -X PATCH http://localhost:5000/api/FileUpload/rename/archivo_viejo.txt \
  -H "Content-Type: application/json" \
  -d '{"newFileName":"archivo_nuevo.txt"}'
```

### 7. Eliminar un archivo (DELETE)
```bash
curl -X DELETE http://localhost:5000/api/FileUpload/delete/archivo.txt
```

### 8. Eliminar todos los archivos (DELETE)
```bash
curl -X DELETE http://localhost:5000/api/FileUpload/deleteAll
```

---

## 🔵 Pruebas con Postman

### POST - Subir archivo
1. Método: **POST**
2. URL: `http://localhost:5000/api/FileUpload/upload`
3. Body → form-data
4. Key: `file` (tipo: File)
5. Selecciona tu archivo
6. Send

### PUT - Actualizar archivo
1. Método: **PUT**
2. URL: `http://localhost:5000/api/FileUpload/update/nombre_archivo.txt`
3. Body → form-data
4. Key: `file` (tipo: File)
5. Selecciona el nuevo archivo
6. Send

### PATCH - Renombrar archivo
1. Método: **PATCH**
2. URL: `http://localhost:5000/api/FileUpload/rename/archivo_viejo.txt`
3. Body → raw → JSON
4. Contenido:
```json
{
  "newFileName": "archivo_nuevo.txt"
}
```
5. Send

---

## 🟢 Respuestas de la API

### Subir archivo exitosamente
```json
{
  "fileName": "documento.pdf",
  "size": 245678,
  "path": "/path/to/UploadedFiles/documento.pdf",
  "message": "Archivo subido exitosamente"
}
```

### Listar archivos
```json
{
  "files": [
    {
      "fileName": "documento.pdf",
      "size": 245678,
      "sizeFormatted": "239.92 KB",
      "uploadDate": "2025-10-15T10:30:00",
      "lastModified": "2025-10-15T10:30:00"
    }
  ],
  "count": 1
}
```

### Error - Archivo no encontrado
```json
{
  "message": "El archivo 'documento.pdf' no existe."
}
```

### Error - Archivo ya existe
```json
{
  "message": "El archivo 'documento.pdf' ya existe. Use PUT para actualizarlo."
}
```
