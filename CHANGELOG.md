# CHANGELOG

Registro de todos los cambios realizados en el proyecto de migraciones a .NET 9

## [Inicial - Pruebas Exitosas] - 27 de Octubre de 2025

### ✅ Pruebas Completadas

#### Práctica 1: SOAP Consumer
- ✅ Compilación: 0 errores, 0 advertencias
- ✅ Ejecución: Funciona correctamente
- ✅ Demuestra consumo de servicios SOAP
- ✅ Listo para migración

#### Práctica 2: Productos API
- ✅ Compilación: 0 errores, 0 advertencias
- ✅ Base de datos SQLite creada automáticamente
- ✅ 3 productos iniciales cargados correctamente
- ✅ Endpoint GET /api/productos funcional
- ✅ Endpoint POST /api/productos funcional
- ✅ Validaciones implementadas y funcionando
- ✅ Listo para migración

#### Práctica 3: FileUploadApi
- ✅ Compilación: 0 errores, 0 advertencias
- ✅ Servidor iniciado correctamente
- ✅ Endpoint GET /api/fileupload/files funcional
- ✅ Archivo de prueba accesible
- ✅ Listo para migración

### 🔧 Cambios Técnicos

#### Práctica 2: Adaptación a Linux
- Cambio de SQL Server a SQLite
- Actualización de paquetes NuGet
- Modificación de Program.cs para UseSqlite()
- Actualización de cadena de conexión

### 📝 Documentación Agregada

- `README.md` - Guía completa del proyecto
- `PRUEBAS.md` - Reporte detallado de pruebas
- `.gitignore` - Configuración de git
- Múltiples README.md en cada carpeta de práctica

### 📊 Repositorio Git

Commits realizados:
1. `feb6e8c` - feat(practica-1): Implementar SOAP Service Consumer
2. `15b2d29` - feat(practica-2): Implementar Productos API REST
3. `9db2ed1` - docs(practica-3): Verificar FileUploadApi
4. `01f3c68` - chore: Agregar configuración base del repositorio
5. `0f36eba` - docs: Agregar README principal
6. `51d0823` - fix(practica-2): Cambiar de SQL Server a SQLite para compatibilidad Linux
7. `00620e3` - test: Documentar pruebas exitosas de las 3 prácticas

---

## ✅ Estado Final Pre-Migración

Todas las 3 prácticas han sido:
- ✅ Reconstruidas según especificaciones originales
- ✅ Compiladas exitosamente
- ✅ Probadas funcionalmente
- ✅ Documentadas completamente
- ✅ Registradas en Git

### Próximos Pasos

- [ ] Migración a .NET 9
- [ ] Pruebas post-migración
- [ ] Documentación de cambios de migración
- [ ] Commits finales

---

## Adiciones - Práctica 2: SOAP Consumer

- ✅ Creado proyecto Console App (.NET 8)
- ✅ Implementado ejemplo funcional de consumo SOAP
- ✅ Documentación completa con instrucciones de dotnet-svcutil
- **Archivos principales:**
  - `SoapConsumer/Program.cs` - Aplicación principal con ejemplos
  - `SoapConsumer/README.md` - Guía completa de uso

### Adiciones - Práctica 2: Productos API

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
- ✅ Entity Framework Core con SQLite
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

