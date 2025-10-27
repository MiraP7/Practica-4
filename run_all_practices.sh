#!/bin/bash

# ============================================================================
# SCRIPT: run_all_practices.sh
# Ejecuta las 3 prácticas simultáneamente en .NET 9
# ============================================================================

set -e

# Colores para terminal
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Configuración
BASE_DIR="/home/miranda/Documentos/UNICDA - Asignaciones - Soft/ingenieria-de-servicios-web2/Practica-4"
LOG_DIR="/tmp/practica-logs"

echo -e "${YELLOW}╔═══════════════════════════════════════════════════════════════╗${NC}"
echo -e "${YELLOW}║${NC}${GREEN}   Iniciando las 3 Prácticas en .NET 9${NC}${YELLOW}                      ║${NC}"
echo -e "${YELLOW}╚═══════════════════════════════════════════════════════════════╝${NC}\n"

# Crear directorio de logs
mkdir -p "$LOG_DIR"

echo -e "${YELLOW}Limpiando procesos anteriores...${NC}"
pkill -f "dotnet run" 2>/dev/null || true
sleep 2

echo -e "${GREEN}✓ Procesos limpios${NC}\n"

# ============================================================================
# PRÁCTICA 1: SOAP Consumer
# ============================================================================
echo -e "${BLUE}[1/3]${NC} Iniciando Práctica 1 (SOAP Service Consumer)"
echo -e "     Puerto: ${YELLOW}5001${NC}"
echo -e "     URL: ${YELLOW}http://localhost:5001/swagger/index.html${NC}"

cd "$BASE_DIR/Practica_1/SoapConsumer"
nohup dotnet run > "$LOG_DIR/practica1.log" 2>&1 &
PROC_1=$!
echo -e "${GREEN}✓ PID: $PROC_1${NC}\n"

# ============================================================================
# PRÁCTICA 2: Productos API
# ============================================================================
echo -e "${BLUE}[2/3]${NC} Iniciando Práctica 2 (Productos API)"
echo -e "     Puerto: ${YELLOW}5016${NC}"
echo -e "     URL: ${YELLOW}http://localhost:5016/swagger/index.html${NC}"

cd "$BASE_DIR/Practica_2/ProductosApi"
nohup dotnet run > "$LOG_DIR/practica2.log" 2>&1 &
PROC_2=$!
echo -e "${GREEN}✓ PID: $PROC_2${NC}\n"

# ============================================================================
# PRÁCTICA 3: File Upload API
# ============================================================================
echo -e "${BLUE}[3/3]${NC} Iniciando Práctica 3 (File Upload API)"
echo -e "     Puerto: ${YELLOW}5000${NC}"
echo -e "     URL: ${YELLOW}http://localhost:5000/swagger/index.html${NC}"

cd "$BASE_DIR/Practica_3/FileUploadApi"
nohup dotnet run > "$LOG_DIR/practica3.log" 2>&1 &
PROC_3=$!
echo -e "${GREEN}✓ PID: $PROC_3${NC}\n"

# ============================================================================
# ESPERAR INICIALIZACIÓN
# ============================================================================
echo -e "${YELLOW}Esperando inicialización de servicios (5 segundos)...${NC}"
sleep 5

# ============================================================================
# VERIFICAR PUERTOS
# ============================================================================
echo -e "\n${YELLOW}Verificando puertos activos:${NC}"
netstat -tuln 2>/dev/null | grep -E "5001|5016|5000" || ss -tuln 2>/dev/null | grep -E "5001|5016|5000"

# ============================================================================
# RESUMEN FINAL
# ============================================================================
echo -e "\n${GREEN}╔═══════════════════════════════════════════════════════════════╗${NC}"
echo -e "${GREEN}║${NC}${YELLOW}  ✅ TODAS LAS PRÁCTICAS INICIADAS CORRECTAMENTE${NC}${GREEN}               ║${NC}"
echo -e "${GREEN}╚═══════════════════════════════════════════════════════════════╝${NC}\n"

echo -e "${BLUE}📱 ACCESO DESDE NAVEGADOR:${NC}\n"
echo -e "  ${YELLOW}Práctica 1 (SOAP Consumer):${NC}"
echo -e "    🔗 http://localhost:5001/swagger/index.html\n"

echo -e "  ${YELLOW}Práctica 2 (Productos API):${NC}"
echo -e "    🔗 http://localhost:5016/swagger/index.html\n"

echo -e "  ${YELLOW}Práctica 3 (File Upload API):${NC}"
echo -e "    🔗 http://localhost:5000/swagger/index.html\n"

echo -e "${BLUE}📊 INFORMACIÓN DE PROCESOS:${NC}\n"
echo -e "  Práctica 1 PID: $PROC_1"
echo -e "  Práctica 2 PID: $PROC_2"
echo -e "  Práctica 3 PID: $PROC_3\n"

echo -e "${BLUE}📋 LOGS EN TIEMPO REAL:${NC}\n"
echo -e "  tail -f $LOG_DIR/practica1.log"
echo -e "  tail -f $LOG_DIR/practica2.log"
echo -e "  tail -f $LOG_DIR/practica3.log\n"

echo -e "${BLUE}🛑 PARA DETENER LOS SERVICIOS:${NC}\n"
echo -e "  pkill -f 'dotnet run'\n"

echo -e "${YELLOW}═══════════════════════════════════════════════════════════════${NC}"
echo -e "${GREEN}✨ Servicios listos para usar - ¡Abre los links en tu navegador!${NC}"
echo -e "${YELLOW}═══════════════════════════════════════════════════════════════${NC}\n"

# Mantener el script activo
while true; do
    sleep 1
    # Verificar si los procesos siguen activos
    if ! ps -p $PROC_1 > /dev/null 2>&1; then
        echo -e "${RED}⚠️  Práctica 1 se detuvo${NC}"
    fi
    if ! ps -p $PROC_2 > /dev/null 2>&1; then
        echo -e "${RED}⚠️  Práctica 2 se detuvo${NC}"
    fi
    if ! ps -p $PROC_3 > /dev/null 2>&1; then
        echo -e "${RED}⚠️  Práctica 3 se detuvo${NC}"
    fi
done
