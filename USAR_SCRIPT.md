# 🚀 Script de Ejecución de las 3 Prácticas en .NET 9

## Descripción

`run_all_practices.sh` es un script Bash que ejecuta automáticamente las **3 prácticas simultáneamente** en puertos diferentes, garantizando que:

✅ Las prácticas se mantienen en ejecución (sin timeout)  
✅ Swagger está disponible en cada una  
✅ Los logs se guardan para debugging  
✅ Los procesos se pueden monitorear fácilmente  

---

## 🎯 Uso Rápido

### Opción 1: Ejecutar el Script (Recomendado)

```bash
bash /home/miranda/Documentos/UNICDA\ -\ Asignaciones\ -\ Soft/ingenieria-de-servicios-web2/Practica-4/run_all_practices.sh
```

O desde el directorio de Práctica-4:

```bash
./run_all_practices.sh
```

### Opción 2: Ejecutar Manualmente (3 Terminales)

**Terminal 1:**
```bash
cd Practica_1/SoapConsumer && dotnet run
```

**Terminal 2:**
```bash
cd Practica_2/ProductosApi && dotnet run
```

**Terminal 3:**
```bash
cd Practica_3/FileUploadApi && dotnet run
```

---

## 📋 Lo Que Hace el Script

1. **Limpia procesos anteriores** - Mata cualquier instancia previa de `dotnet run`
2. **Inicia Práctica 1** - SOAP Consumer en puerto 5001
3. **Inicia Práctica 2** - Productos API en puerto 5016
4. **Inicia Práctica 3** - File Upload API en puerto 5000
5. **Verifica los puertos** - Confirma que están escuchando
6. **Muestra información** - URLs, PIDs, instrucciones de logs
7. **Mantiene monitoreo** - Verifica que los procesos sigan activos

---

## 🌐 Acceso desde Navegador

Después de ejecutar el script, abre en tu navegador:

| Práctica | URL | Puerto |
|----------|-----|--------|
| SOAP Consumer | http://localhost:5001/swagger/index.html | 5001 |
| Productos API | http://localhost:5016/swagger/index.html | 5016 |
| File Upload API | http://localhost:5000/swagger/index.html | 5000 |

---

## 📊 Información de Procesos

El script muestra los **PIDs (Process IDs)** de cada práctica:

```
Práctica 1 PID: 61012
Práctica 2 PID: 61013
Práctica 3 PID: 61014
```

### Ver Logs en Tiempo Real

```bash
# Práctica 1
tail -f /tmp/practica-logs/practica1.log

# Práctica 2
tail -f /tmp/practica-logs/practica2.log

# Práctica 3
tail -f /tmp/practica-logs/practica3.log
```

### Ver Todos los Logs Juntos

```bash
tail -f /tmp/practica-logs/*.log
```

---

## 🛑 Detener los Servicios

### Opción 1: Detener Todos los Servicios

```bash
pkill -f 'dotnet run'
```

### Opción 2: Detener un Servicio Específico

```bash
# Detener por PID
kill 61012  # Práctica 1
kill 61013  # Práctica 2
kill 61014  # Práctica 3

# O detener por nombre
pkill -f "SoapConsumer"
pkill -f "ProductosApi"
pkill -f "FileUploadApi"
```

---

## 🧪 Pruebas Rápidas desde Terminal

### Práctica 1: Información SOAP

```bash
curl -s http://localhost:5001/api/soap/info | python3 -m json.tool
```

### Práctica 1: Generar Proxy

```bash
curl -X POST http://localhost:5001/api/soap/generate-proxy \
  -H "Content-Type: application/json" \
  -d '{"wsdlUrl": "https://ejemplo.com/servicio.wsdl"}'
```

### Práctica 2: Listar Productos

```bash
curl -s http://localhost:5016/api/productos | python3 -m json.tool
```

### Práctica 2: Crear Producto

```bash
curl -X POST http://localhost:5016/api/productos \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Nuevo Producto",
    "descripcion": "Descripción",
    "precio": 99.99,
    "stock": 10
  }'
```

### Práctica 3: Listar Archivos

```bash
curl -s http://localhost:5000/api/fileupload/files | python3 -m json.tool
```

---

## 📁 Ubicación del Script

```
/home/miranda/Documentos/UNICDA - Asignaciones - Soft/
ingenieria-de-servicios-web2/Practica-4/
└── run_all_practices.sh
```

---

## ⚙️ Requisitos

- **Bash** (shell por defecto en Linux/Mac)
- **dotnet CLI** (comando `dotnet`)
- **Puertos disponibles**: 5000, 5001, 5016
- **.NET 9 SDK** instalado

---

## 🔧 Solución de Problemas

### "Port already in use"

Si algún puerto está ocupado:

```bash
# Encontrar qué está usando el puerto
lsof -ti:5001   # Puerto 5001
lsof -ti:5016   # Puerto 5016
lsof -ti:5000   # Puerto 5000

# Matar el proceso
kill -9 <PID>
```

### Script no tiene permisos de ejecución

```bash
chmod +x run_all_practices.sh
```

### "bash: run_all_practices.sh: No such file or directory"

Asegúrate de estar en el directorio correcto:

```bash
cd /home/miranda/Documentos/UNICDA\ -\ Asignaciones\ -\ Soft/ingenieria-de-servicios-web2/Practica-4/
./run_all_practices.sh
```

### Los logs están vacíos

```bash
# Ver el archivo de log
cat /tmp/practica-logs/practica1.log

# O esperar un poco más
sleep 5 && tail -f /tmp/practica-logs/practica1.log
```

---

## 📝 Notas Importantes

- El script usa `nohup` para que los procesos persistan si cierras el shell
- Los logs se guardan en `/tmp/practica-logs/` (se pierden al reiniciar)
- El script verifica periódicamente que los procesos sigan activos
- Puedes presionar Ctrl+C para detener el monitoreo del script (los servicios seguirán corriendo)
- Para una limpieza completa, usa `pkill -f 'dotnet run'`

---

## 🎯 Flujo Típico de Uso

1. Abre una terminal en el directorio `Practica-4`
2. Ejecuta `./run_all_practices.sh`
3. Espera el mensaje "✅ TODAS LAS PRÁCTICAS INICIADAS CORRECTAMENTE"
4. Abre en tu navegador los 3 links de Swagger
5. ¡Comienza a probar los APIs!
6. Cuando termines, presiona Ctrl+C y luego `pkill -f 'dotnet run'`

---

## 📊 Arquitectura del Script

```
run_all_practices.sh
├── Limpia procesos anteriores
├── Inicia Práctica 1 (PID en variable $PROC_1)
├── Inicia Práctica 2 (PID en variable $PROC_2)
├── Inicia Práctica 3 (PID en variable $PROC_3)
├── Verifica puertos con netstat/ss
├── Muestra información de acceso
└── Monitorea continuamente los procesos
    └── Alerta si alguno se detiene
```

---

## 🚀 Próximos Pasos

1. ✅ Ejecuta el script
2. ✅ Abre los links en tu navegador
3. ✅ Prueba los endpoints en Swagger
4. ✅ Usa los curl commands para testing automatizado
5. ✅ Revisa los logs si hay problemas

¡Listo para usar! 🎉

---

**Última actualización:** 27 de octubre de 2025  
**Versión .NET:** 9.0.306  
**Ambiente:** Linux  
**Estado:** ✅ Completamente funcional
