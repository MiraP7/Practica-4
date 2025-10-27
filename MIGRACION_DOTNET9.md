# Guía de Migración a .NET 9

## Requisitos Previos

Antes de comenzar la migración, asegúrate de que tienes:

- ✅ .NET 9 SDK instalado ([Descargar](https://dotnet.microsoft.com/en-us/download/dotnet/9.0))
- ✅ Visual Studio 2022 actualizado (versión 17.10 o superior) O VS Code
- ✅ Todos los proyectos compilando correctamente en .NET 8
- ✅ Repositorio Git con todos los cambios commiteados

## Pasos de Migración

### Paso 1: Respaldar el Código Actual

```bash
# Crear rama de backup en git
git checkout -b backup/net8-before-migration

# Volver a master
git checkout master
```

### Paso 2: Actualizar Target Framework

Edita cada archivo `.csproj` y cambia el `TargetFramework`:

#### Para Práctica 1: SoapConsumer.csproj
```xml
<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>  <!-- Cambiar de net8.0 a net9.0 -->
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

#### Para Práctica 2: ProductosApi.csproj
```xml
<PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>  <!-- Cambiar de net8.0 a net9.0 -->
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>

<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.0" />
</ItemGroup>
```

#### Para Práctica 3: FileUploadApi.csproj
```xml
<PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>  <!-- Cambiar de net8.0 a net9.0 -->
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>

<ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="7.0.0" />
</ItemGroup>
```

### Paso 3: Restaurar Dependencias

Para cada proyecto, ejecuta:

```bash
# Práctica 1
cd Practica_1/SoapConsumer
dotnet clean
dotnet restore

# Práctica 2
cd ../../Practica_2/ProductosApi
dotnet clean
dotnet restore

# Práctica 3
cd ../../Practica_3/FileUploadApi
dotnet clean
dotnet restore
```

### Paso 4: Compilar Proyectos

```bash
# Práctica 1
cd Practica_1/SoapConsumer
dotnet build

# Práctica 2
cd ../../Practica_2/ProductosApi
dotnet build

# Práctica 3
cd ../../Practica_3/FileUploadApi
dotnet build
```

### Paso 5: Validar Cambios en el Código

#### Cambios Comunes entre .NET 8 y .NET 9:

1. **Mejoras en Performance** - No requiere cambios de código
2. **Soporte para Async** - Ya está implementado
3. **C# 13** - Compatible con código existente

#### Validaciones Específicas por Práctica:

**Práctica 1 - SOAP Consumer:**
- Verificar que `System.ServiceModel` es compatible
- No se requieren cambios de código

**Práctica 2 - Productos API:**
- Entity Framework Core 9.0 es totalmente compatible
- Validar que las migraciones funcionan correctamente
- No se requieren cambios de código

**Práctica 3 - File Upload API:**
- ASP.NET Core 9.0 es compatible con el código existente
- No se requieren cambios de código

### Paso 6: Ejecutar Tests

```bash
# Práctica 1
cd Practica_1/SoapConsumer
dotnet run

# Práctica 2 (en otra terminal)
cd Practica_2/ProductosApi
dotnet run
# Probar: curl http://localhost:5016/api/productos

# Práctica 3 (en otra terminal)
cd Practica_3/FileUploadApi
dotnet run
# Probar: curl http://localhost:5000/api/fileupload/files
```

### Paso 7: Hacer Commit de la Migración

```bash
cd path/to/Practica-4

# Adicionar cambios
git add .

# Hacer commit
git commit -m "chore: Migrar de .NET 8 a .NET 9

- Actualizar target framework a net9.0 en los 3 proyectos
- Actualizar paquetes NuGet a versión 9.0.0
- Swashbuckle.AspNetCore actualizado a 7.0.0
- Validar compilación exitosa sin errores
- Todas las prácticas compiladas y funcionando
- Cambios backwards-compatible"
```

## Cambios de Versión por Paquete

| Paquete | .NET 8 | .NET 9 |
|---------|--------|--------|
| Microsoft.AspNetCore.OpenApi | 8.0.21 | 9.0.0 |
| Swashbuckle.AspNetCore | 6.6.2 / 6.5.0 | 7.0.0 |
| Microsoft.EntityFrameworkCore | 8.0.11 | 9.0.0 |
| Microsoft.EntityFrameworkCore.Sqlite | 8.0.11 | 9.0.0 |
| Microsoft.EntityFrameworkCore.Tools | 8.0.11 | 9.0.0 |

## Posibles Problemas y Soluciones

### Problema: "NETSDK1045: El SDK de .NET actual no admite el destino .NET 9.0"

**Solución:**
```bash
# Verificar versión instalada
dotnet --version

# Descargar .NET 9 SDK desde https://dotnet.microsoft.com/download/dotnet/9.0
# O instalar vía package manager:

# Windows (Chocolatey)
choco install dotnet

# Linux (Ubuntu/Debian)
sudo apt-get update
sudo apt-get install dotnet-sdk-9.0

# macOS (Homebrew)
brew install dotnet
```

### Problema: Errores de compatibilidad con Entity Framework

**Solución:**
```bash
# Limpiar caché NuGet
dotnet nuget locals all --clear

# Restaurar paquetes nuevamente
dotnet restore
```

### Problema: Migraciones de EF Core no funcionan

**Solución:**
```bash
# Eliminar migraciones antiguas si existen
rm -rf Migrations/

# Crear nueva migración base
dotnet ef migrations add InitialCreate

# Actualizar base de datos
dotnet ef database update
```

## Cambios Importantes en .NET 9

### 1. Mejoras de Performance
- Mejor garbage collection
- Optimizaciones JIT
- Mejor manejo de memoria

**Impacto:** Positivo - Las aplicaciones se ejecutarán más rápido

### 2. Soporte para C# 13
- Nuevas características de lenguaje
- Mejor pattern matching
- Compatible con código .NET 8

**Impacto:** Compatible - El código actual seguirá funcionando

### 3. Mejoras en ASP.NET Core 9
- Mejoras en middleware
- OpenAPI mejorado
- Mejor manejo de async/await

**Impacto:** Compatible - Todas las características existentes son compatibles

### 4. Entity Framework Core 9
- Mejoras en consultas
- Mejor soporte para migraciones
- Mejor performance

**Impacto:** Compatible - Las migraciones existentes seguirán funcionando

## Validación Post-Migración

Ejecuta estas pruebas para validar que todo funciona:

```bash
# Compilación sin errores
dotnet build

# Ejecución sin excepciones
dotnet run

# CRUD operations funcionales (Práctica 2)
curl -X GET http://localhost:5016/api/productos
curl -X POST http://localhost:5016/api/productos \
  -H "Content-Type: application/json" \
  -d '{"nombre":"Producto Test","descripcion":"Test","precio":99.99,"stock":1}'

# File operations funcionales (Práctica 3)
curl http://localhost:5000/api/fileupload/files
```

## Rollback en Caso de Problemas

Si algo falla durante la migración:

```bash
# Volver a la rama anterior
git checkout backup/net8-before-migration

# O hacer reset hard
git reset --hard HEAD~1
```

## Documentación de Referencia

- [.NET 9 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [ASP.NET Core 9 Breaking Changes](https://learn.microsoft.com/en-us/dotnet/core/compatibility/9.0)
- [Entity Framework Core 9](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-9.0/overview)
- [Migrating from .NET 8 to .NET 9](https://learn.microsoft.com/en-us/dotnet/core/upgrade)

## Estimación de Tiempo

- Actualizar archivos .csproj: **5 minutos**
- Restaurar dependencias: **5-10 minutos**
- Compilación: **10-15 minutos**
- Pruebas: **10 minutos**
- Documentación: **5 minutos**

**Total estimado: 35-45 minutos**

---

**Generado por:** Asistente de Migración
**Fecha:** 27 de Octubre de 2025
**Versión:** 1.0
