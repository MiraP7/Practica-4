# CHANGELOG

Registro de todos los cambios realizados en el proyecto de migraciones a .NET 9

## [Inicial] - 27 de Octubre de 2025

### Adicionado - Práctica 1: SOAP Consumer

- ✅ Creado proyecto Console App (.NET 8)
- ✅ Implementado ejemplo de consumo de servicios SOAP
- ✅ Documentación completa con instrucciones de dotnet-svcutil
- ✅ Estructura lista para generar proxies desde WSDL
- **Archivos principales:**
  - `SoapConsumer/Program.cs` - Aplicación principal con ejemplos
  - `SoapConsumer/README.md` - Guía completa de uso

### Adicionado - Práctica 2: Productos API

- ✅ Creado proyecto ASP.NET Core Web API (.NET 8)
- ✅ Modelo de datos: Tabla Productos con propiedades completas
- ✅ DbContext configurado con validaciones
- ✅ CRUD completo implementado en ProductosController
- ✅ Operaciones soportadas:
  - GET /api/productos - Listar todos
  - GET /api/productos/{id} - Obtener por ID
  - POST /api/productos - Crear nuevo
  - PUT /api/productos/{id} - Actualizar
  - DELETE /api/productos/{id} - Eliminar
  - GET /api/productos/buscar - Búsqueda por nombre
- ✅ Entity Framework Core con SQL Server
- ✅ Validaciones de negocio (precio y stock no negativos, nombre único)
- ✅ Swagger integrado para documentación
- ✅ CORS habilitado
- ✅ Logging configurado
- ✅ Datos iniciales automáticos
- **Archivos principales:**
  - `ProductosApi/Models/Producto.cs` - Modelo de datos
  - `ProductosApi/Data/AppDbContext.cs` - Contexto de BD
  - `ProductosApi/Controllers/ProductosController.cs` - Controlador CRUD
  - `ProductosApi/Program.cs` - Configuración de servicios
  - `ProductosApi/appsettings.json` - Cadena de conexión

### Verificado - Práctica 3: FileUploadApi

- ✅ Verificado cumplimiento de especificaciones
- ✅ Validaciones de tipo y tamaño de archivo
- ✅ Carga de archivos en carpeta UploadedFiles
- ✅ Respuestas JSON completas
- ✅ Endpoints adicionales (listar, descargar, actualizar, renombrar, eliminar)
- ✅ Swagger documentado
- ✅ El proyecto ya cumple con los requisitos

### Cambios Técnicos

- Compilación exitosa de los tres proyectos
- Configuración de paquetes NuGet necesarios
- Estructura de carpetas organizada

---

## Próximos Pasos

- [ ] Pruebas completas de funcionalidad en cada práctica
- [ ] Migración a .NET 9
- [ ] Documentación de cambios en migración
- [ ] Commits finales con documentación de la migración
