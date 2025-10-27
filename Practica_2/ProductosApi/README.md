# Práctica 2 - Productos API

## Descripción
API REST en ASP.NET Core 8 que gestiona un catálogo de productos con operaciones CRUD completas, Entity Framework Core y SQL Server.

## Requisitos
- .NET 8 SDK
- SQL Server Express o LocalDB
- Visual Studio 2022 (opcional)

## Configuración inicial

### 1. Instalar dependencias

```bash
dotnet restore
```

### 2. Configurar la base de datos

Editar `appsettings.json` si necesitas cambiar la cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ProductosDb;Trusted_Connection=True;"
}
```

### 3. Crear migraciones (si es necesario)

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Ejecutar la aplicación

```bash
dotnet run
```

La API estará disponible en: `https://localhost:5001` (o la URL que configure)

## Endpoints disponibles

### Obtener todos los productos
```
GET /api/productos
```

### Obtener producto por ID
```
GET /api/productos/{id}
```

### Crear nuevo producto
```
POST /api/productos
Content-Type: application/json

{
  "nombre": "Laptop",
  "descripcion": "Laptop de alto rendimiento",
  "precio": 1299.99,
  "stock": 5
}
```

### Actualizar producto
```
PUT /api/productos/{id}
Content-Type: application/json

{
  "id": 1,
  "nombre": "Laptop actualizada",
  "descripcion": "Nueva descripción",
  "precio": 1199.99,
  "stock": 3
}
```

### Eliminar producto
```
DELETE /api/productos/{id}
```

### Buscar productos
```
GET /api/productos/buscar?nombre=Laptop
```

## Modelo de datos

### Tabla: Productos

| Campo | Tipo | Descripción |
|-------|------|-------------|
| Id | int | Clave primaria |
| Nombre | string(200) | Nombre único del producto |
| Descripcion | string(1000) | Descripción del producto |
| Precio | decimal(18,2) | Precio del producto |
| Stock | int | Cantidad en stock |
| FechaCreacion | datetime | Fecha de creación |
| FechaActualizacion | datetime | Fecha de última actualización |

## Swagger Documentation

Una vez ejecutada la aplicación, puedes acceder a Swagger en:
```
https://localhost:5001/swagger
```

## Validaciones

✓ El nombre es requerido y único  
✓ El precio no puede ser negativo  
✓ El stock no puede ser negativo  
✓ Manejo de excepciones en operaciones de base de datos  

## Características

✓ CRUD completo de productos  
✓ Entity Framework Core con SQL Server  
✓ Validaciones de negocio  
✓ Logging integrado  
✓ CORS habilitado  
✓ Swagger para documentación  
✓ Búsqueda por nombre  
✓ Datos de inicialización automáticos  

## Estructura del proyecto

```
ProductosApi/
├── Controllers/
│   └── ProductosController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── Producto.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── Program.cs
└── ProductosApi.csproj
```

## Notas importantes

- La aplicación crea automáticamente la base de datos si no existe
- Los datos iniciales se cargan al crear la base de datos
- Se requiere tener SQL Server o LocalDB instalado
- El logging se configura para mostrar las consultas de Entity Framework en desarrollo

## Referencias

- [Microsoft Docs - Entity Framework Core](https://docs.microsoft.com/es-es/ef/core/)
- [ASP.NET Core Web API](https://docs.microsoft.com/es-es/aspnet/core/web-api/?view=aspnetcore-8.0)
