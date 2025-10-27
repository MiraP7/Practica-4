# 🚀 Guía para Ejecutar los 3 Proyectos Migrados a .NET 9

## ✅ Estado Actual

✅ **Todos los proyectos compilados exitosamente en .NET 9.0.306**  
✅ **Interfaces Swagger disponibles en navegador**  
✅ **APIs funcionales y respondiendo correctamente**  

---

## 📋 Tabla de Contenidos

1. [Información de Proyectos](#información-de-proyectos)
2. [Ejecución Individual](#ejecución-individual)
3. [Ejecución Simultánea](#ejecución-simultánea)
4. [Acceso desde Navegador](#acceso-desde-navegador)
5. [Pruebas de API](#pruebas-de-api)
6. [Solución de Problemas](#solución-de-problemas)

---

## 📊 Información de Proyectos

| Práctica | Nombre | Puerto | Tipo | Descripción |
|----------|--------|--------|------|-------------|
| **1** | SoapConsumer | N/A | Consola | Consumidor de servicios SOAP |
| **2** | ProductosApi | **5016** | Web API | API REST para gestión de productos |
| **3** | FileUploadApi | **5000** | Web API | API para carga/descarga de archivos |

---

## 🏃 Ejecución Individual

### Práctica 1: SOAP Consumer (Aplicación de Consola)

```bash
cd Practica_1/SoapConsumer
dotnet run
```

**Salida esperada:**
```
=== SOAP Service Consumer ===
Esta aplicación demuestra cómo consumir un servicio SOAP...
```

**Tiempo de ejecución:** ~2-3 segundos

---

### Práctica 2: Productos API (Web API - Puerto 5016)

```bash
cd Practica_2/ProductosApi
dotnet run
```

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5016
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

**Acceso:** http://localhost:5016/swagger/index.html

---

### Práctica 3: File Upload API (Web API - Puerto 5000)

```bash
cd Practica_3/FileUploadApi
dotnet run
```

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

**Acceso:** http://localhost:5000/swagger/index.html

---

## 🔄 Ejecución Simultánea

Para ejecutar las 3 prácticas **al mismo tiempo**, necesitas **3 terminales diferentes**.

### Opción 1: Usando 3 Terminales Separadas (Recomendado)

**Terminal 1 - Práctica 1 (Consola - Se ejecuta una sola vez):**
```bash
cd Practica_1/SoapConsumer
dotnet run
```

**Terminal 2 - Práctica 2 (Web API en puerto 5016):**
```bash
cd Practica_2/ProductosApi
dotnet run
```

**Terminal 3 - Práctica 3 (Web API en puerto 5000):**
```bash
cd Practica_3/FileUploadApi
dotnet run
```

### Opción 2: Usando Script en Background

```bash
# Limpiar procesos anteriores
pkill -f "dotnet run"

# Iniciar Práctica 2 en background
cd Practica_2/ProductosApi && dotnet run > /tmp/practica2.log 2>&1 &

# Iniciar Práctica 3 en background  
cd Practica_3/FileUploadApi && dotnet run > /tmp/practica3.log 2>&1 &

# Esperar a que inicialicen
sleep 5

# Ver logs
echo "=== LOG PRÁCTICA 2 ===" && tail -20 /tmp/practica2.log
echo -e "\n=== LOG PRÁCTICA 3 ===" && tail -20 /tmp/practica3.log
```

### Opción 3: Script Automatizado (Bash)

Crea un archivo `run_all.sh`:

```bash
#!/bin/bash

# Colores para terminal
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${YELLOW}🚀 Iniciando todos los proyectos .NET 9...${NC}\n"

# Matar procesos previos
echo "Limpiando procesos anteriores..."
pkill -f "dotnet run" 2>/dev/null

# Esperar
sleep 2

# Crear directorio de logs
mkdir -p /tmp/practica-logs

# Iniciar Práctica 2
echo -e "${BLUE}[1/2]${NC} Iniciando Práctica 2 (ProductosApi) en puerto 5016..."
cd Practica_2/ProductosApi && dotnet run > /tmp/practica-logs/practica2.log 2>&1 &
PROC_2=$!
echo -e "${GREEN}✓ PID: $PROC_2${NC}\n"

# Iniciar Práctica 3
echo -e "${BLUE}[2/2]${NC} Iniciando Práctica 3 (FileUploadApi) en puerto 5000..."
cd Practica_3/FileUploadApi && dotnet run > /tmp/practica-logs/practica3.log 2>&1 &
PROC_3=$!
echo -e "${GREEN}✓ PID: $PROC_3${NC}\n"

# Esperar a que los servicios inicialicen
echo "Esperando inicialización de servicios (5 segundos)..."
sleep 5

# Verificar puertos
echo -e "\n${YELLOW}Verificando puertos activos:${NC}"
netstat -tuln 2>/dev/null | grep -E "5016|5000" || ss -tuln 2>/dev/null | grep -E "5016|5000"

echo -e "\n${GREEN}✅ SERVICIOS INICIADOS CORRECTAMENTE${NC}\n"
echo -e "📱 ${BLUE}Práctica 2 (Productos API):${NC}"
echo "   URL: http://localhost:5016/swagger/index.html"
echo "   Logs: tail -f /tmp/practica-logs/practica2.log"
echo ""
echo -e "📁 ${BLUE}Práctica 3 (File Upload API):${NC}"
echo "   URL: http://localhost:5000/swagger/index.html"
echo "   Logs: tail -f /tmp/practica-logs/practica3.log"
echo ""
echo -e "${YELLOW}Para detener los servicios:${NC}"
echo "   pkill -f 'dotnet run'"
```

Dale permisos de ejecución:
```bash
chmod +x run_all.sh
./run_all.sh
```

---

## 🌐 Acceso desde Navegador

### Interfaz Swagger (Documentación Interactiva)

Abre en tu navegador:

- **Práctica 2 - Productos API:**  
  http://localhost:5016/swagger/index.html

- **Práctica 3 - File Upload API:**  
  http://localhost:5000/swagger/index.html

### Pruebas Directas

- **API de Productos:**  
  http://localhost:5016/api/productos

- **API de Archivos:**  
  http://localhost:5000/api/fileupload/files

---

## 🧪 Pruebas de API

### Práctica 2: Productos API

#### Obtener todos los productos
```bash
curl -s http://localhost:5016/api/productos | python3 -m json.tool
```

#### Obtener producto por ID
```bash
curl -s http://localhost:5016/api/productos/1 | python3 -m json.tool
```

#### Crear nuevo producto
```bash
curl -X POST http://localhost:5016/api/productos \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Mouse Inalámbrico",
    "descripcion": "Mouse inalámbrico 2.4GHz",
    "precio": 29.99,
    "stock": 50
  }' | python3 -m json.tool
```

#### Actualizar producto
```bash
curl -X PUT http://localhost:5016/api/productos/1 \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Laptop Dell XPS 15 - Actualizada",
    "descripcion": "Laptop de alta performance",
    "precio": 1399.99,
    "stock": 4
  }' | python3 -m json.tool
```

#### Eliminar producto
```bash
curl -X DELETE http://localhost:5016/api/productos/5
```

#### Buscar productos
```bash
curl -s "http://localhost:5016/api/productos/buscar?termino=laptop" | python3 -m json.tool
```

### Práctica 3: File Upload API

#### Listar archivos
```bash
curl -s http://localhost:5000/api/fileupload/files | python3 -m json.tool
```

#### Subir archivo
```bash
curl -X POST -F "file=@/ruta/al/archivo.pdf" \
  http://localhost:5000/api/fileupload/upload
```

#### Descargar archivo
```bash
curl -O http://localhost:5000/api/fileupload/download/nombrearchivo.pdf
```

#### Eliminar archivo
```bash
curl -X DELETE http://localhost:5000/api/fileupload/delete/nombrearchivo.pdf
```

---

## 🛠️ Solución de Problemas

### Puerto ya en uso

Si ves el error "Address already in use":

```bash
# Encontrar qué proceso está usando el puerto
lsof -ti:5016 | xargs kill -9  # Para puerto 5016
lsof -ti:5000 | xargs kill -9  # Para puerto 5000
```

### Los cambios en el código no se reflejan

Limpia y reconstruye:

```bash
cd [Practica_X]/[NombreApi]
dotnet clean
rm -rf obj bin
dotnet restore
dotnet build
dotnet run
```

### Swagger no carga

1. Asegúrate que el ambiente está en `Development`:
   ```bash
   echo $ASPNETCORE_ENVIRONMENT  # Debe ser Development
   ```

2. Si no está, configúralo:
   ```bash
   export ASPNETCORE_ENVIRONMENT=Development
   ```

### Error de base de datos (Práctica 2)

Si falta `ProductosDb.db`:

```bash
cd Practica_2/ProductosApi
# La base de datos se creará automáticamente al ejecutar dotnet run
dotnet run
```

### No puedo acceder desde otra máquina

Por defecto, solo escucha en localhost. Para escuchar en todas las interfaces:

**Edita `launchSettings.json`:**

```json
"applicationUrl": "http://0.0.0.0:5016"
```

---

## 📈 Comandos Útiles

### Ver todos los procesos dotnet
```bash
ps aux | grep dotnet
```

### Monitorear uso de recursos
```bash
watch -n 1 'ps aux | grep dotnet'
```

### Ver logs en tiempo real
```bash
tail -f /tmp/practica-logs/practica2.log
tail -f /tmp/practica-logs/practica3.log
```

### Detener todos los servicios
```bash
pkill -f "dotnet run"
```

### Verificar estado de puertos
```bash
netstat -tuln | grep -E "5016|5000"
# o
ss -tuln | grep -E "5016|5000"
```

---

## 📝 Notas Importantes

✅ **Los 3 proyectos están compilados en .NET 9.0.306**

✅ **Base de datos SQLite (compatible con Linux)**

✅ **Swagger UI habilitado en desarrollo**

✅ **CORS permitido para todas las solicitudes**

✅ **Migraciones automáticas en Práctica 2**

⚠️ **Práctica 1 es una aplicación de consola - Se ejecuta y termina**

⚠️ **Prácticas 2 y 3 son Web APIs - Corren continuamente**

---

## 🔗 Enlaces Rápidos

| Recurso | URL |
|---------|-----|
| Swagger Productos | http://localhost:5016/swagger/index.html |
| Swagger File Upload | http://localhost:5000/swagger/index.html |
| API Productos | http://localhost:5016/api/productos |
| API Files | http://localhost:5000/api/fileupload/files |
| .NET 9 Docs | https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-9 |

---

**Última actualización:** 27 de octubre de 2025  
**Versión .NET:** 9.0.306  
**Ambiente:** Linux  
**Estado:** ✅ Completamente funcional
