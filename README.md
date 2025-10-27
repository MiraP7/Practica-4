# Ingeniería de Servicios Web - Práctica 4: Migración a .NET 9

Proyecto académico de migración de tres aplicaciones .NET 8 a .NET 9 como parte de la asignatura de Ingeniería de Servicios Web.

## 📚 Descripción General

Este repositorio contiene tres prácticas que han sido reconstruidas y documentadas:

### Práctica 1: SOAP Service Consumer
Aplicación Console App que demuestra cómo consumir servicios SOAP externos utilizando `dotnet-svcutil`.

**Ubicación:** `/Practica_1/SoapConsumer/`

**Características:**
- Generación de proxies desde WSDL
- Llamadas asincrónicas a servicios remotos
- Manejo de errores de conexión
- Documentación completa

### Práctica 2: Productos API
API REST en ASP.NET Core para gestionar catálogo de productos con operaciones CRUD.

**Ubicación:** `/Practica_2/ProductosApi/`

**Características:**
- Entity Framework Core con SQL Server
- CRUD completo (GET, POST, PUT, DELETE)
- Validaciones de negocio
- Swagger integrado
- CORS habilitado
- Búsqueda por nombre
- Logging estructurado

### Práctica 3: File Upload API
API REST para carga y gestión de archivos con validaciones.

**Ubicación:** `/Practica_3/FileUploadApi/`

**Características:**
- Carga de archivos en servidor
- Validación de tipos permitidos
- Descarga de archivos
- Actualización y renombrado
- Eliminación de archivos
- Listado con metadatos

## 🛠️ Tecnologías

- **.NET 8** (actual)
- **C# 12**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server / LocalDB**
- **Swagger/OpenAPI**
- **Visual Studio 2022**

## 📋 Requisitos Previos

- .NET 8 SDK instalado
- SQL Server Express o LocalDB
- Visual Studio 2022 o código editor compatible
- Git para control de versiones

## 🚀 Inicio Rápido

### Práctica 1 - SOAP Consumer
```bash
cd Practica_1/SoapConsumer
dotnet build
dotnet run
```

### Práctica 2 - Productos API
```bash
cd Practica_2/ProductosApi
dotnet build
dotnet run
# La API estará disponible en https://localhost:5001/swagger
```

### Práctica 3 - File Upload API
```bash
cd Practica_3/FileUploadApi
dotnet build
dotnet run
# La API estará disponible en http://localhost:5000/swagger
```

## 📁 Estructura del Repositorio

```
.
├── Practica_1/
│   ├── Intrucciones-de-a-practica-1.txt
│   └── SoapConsumer/
│       ├── Program.cs
│       ├── README.md
│       └── SoapConsumer.csproj
│
├── Practica_2/
│   ├── Intrucciones-de-la-practica-2.txt
│   └── ProductosApi/
│       ├── Controllers/
│       ├── Data/
│       ├── Models/
│       ├── Program.cs
│       ├── README.md
│       ├── appsettings.json
│       └── ProductosApi.csproj
│
├── Practica_3/
│   ├── Instrucciones-de-la-practica -3
│   └── FileUploadApi/
│       ├── Controllers/
│       ├── Program.cs
│       ├── README.md
│       └── FileUploadApi.csproj
│
├── .gitignore
├── CHANGELOG.md
└── README.md
```

## 🔗 Endpoints Principales

### Productos API (Práctica 2)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/productos` | Listar todos |
| GET | `/api/productos/{id}` | Obtener por ID |
| POST | `/api/productos` | Crear nuevo |
| PUT | `/api/productos/{id}` | Actualizar |
| DELETE | `/api/productos/{id}` | Eliminar |
| GET | `/api/productos/buscar?nombre=X` | Buscar por nombre |

### File Upload API (Práctica 3)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/fileupload/upload` | Subir archivo |
| GET | `/api/fileupload/files` | Listar todos |
| GET | `/api/fileupload/files/{fileName}` | Obtener info |
| GET | `/api/fileupload/download/{fileName}` | Descargar |
| PUT | `/api/fileupload/update/{fileName}` | Actualizar |
| DELETE | `/api/fileupload/delete/{fileName}` | Eliminar |

## 📊 Estado de las Prácticas

- ✅ **Práctica 1:** Funcional - Compilación exitosa
- ✅ **Práctica 2:** Funcional - Compilación exitosa
- ✅ **Práctica 3:** Funcional - Compilación exitosa

## 📝 Control de Versiones

### Commits Principales

1. `feat(practica-1): Implementar SOAP Service Consumer` - Proyecto SOAP reconstruido
2. `feat(practica-2): Implementar Productos API REST` - API de productos implementada
3. `docs(practica-3): Verificar FileUploadApi` - Validación de API de archivos
4. `chore: Agregar configuración base del repositorio` - Configuración inicial

Ver [CHANGELOG.md](./CHANGELOG.md) para detalles completos.

## 🔄 Próximos Pasos

1. **Pruebas completas** de cada práctica
2. **Migración a .NET 9** de las tres aplicaciones
3. **Documentación** de cambios en la migración
4. **Validación** de compatibilidad en .NET 9

## 📚 Referencias

- [Microsoft Learn - Entity Framework Core](https://learn.microsoft.com/es-es/ef/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/es-es/aspnet/core/)
- [.NET 9 Release Notes](https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-9)

## 👥 Autor

- **Desarrollador:** Estudiante de Ingeniería de Servicios Web
- **Institución:** UNICDA
- **Asignatura:** Ingeniería de Servicios Web 2

## 📄 Licencia

Este proyecto es de naturaleza educativa y forma parte de las actividades académicas.

---

**Última actualización:** 27 de Octubre de 2025

Para consultas o problemas, revisa la documentación individual en cada carpeta de práctica.
