# Práctica 1 - SOAP Service Consumer

## Descripción
Aplicación Console App en .NET 8 que demuestra cómo consumir servicios SOAP (Simple Object Access Protocol) utilizando herramientas de .NET.

## Requisitos
- .NET 8 SDK o superior
- `dotnet-svcutil` (herramienta para generar clases proxy)

## Instalación de dotnet-svcutil

Ejecuta el siguiente comando para instalar la herramienta globalmente:

```bash
dotnet tool install --global dotnet-svcutil
```

## Pasos para consumir un servicio SOAP

### 1. Generar clases proxy desde WSDL

Una vez tengas la URL de un servicio SOAP con su archivo WSDL, usa:

```bash
dotnet-svcutil https://ejemplo.com/service.wsdl -o ServiceProxy
```

Esto generará un archivo `ServiceProxy.cs` con todas las clases necesarias.

### 2. Usar las clases generadas

Dentro del proyecto, puedes crear un cliente así:

```csharp
var client = new ServicioClient(new System.ServiceModel.BasicHttpBinding(), 
    new System.ServiceModel.EndpointAddress("https://ejemplo.com/service"));
var resultado = await client.MetodoAsync(parametros);
Console.WriteLine(resultado);
```

### 3. Manejar configuración (app.config)

Si el servicio requiere configuración especial, se puede agregar en `app.config`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name="BasicHttpBinding_IServicio">
          <security mode="None" />
        </binding>
      </basicHttpBinding>
    </bindings>
    <client>
      <endpoint address="http://ejemplo.com/service" binding="basicHttpBinding"
                bindingConfiguration="BasicHttpBinding_IServicio" contract="IServicio"
                name="BasicHttpBinding_IServicio" />
    </client>
  </system.serviceModel>
</configuration>
```

## Ejecución

Para ejecutar la aplicación:

```bash
dotnet run
```

## Características principales

✓ Consumo de servicios SOAP  
✓ Generación de clases proxy desde WSDL  
✓ Manejo de excepciones  
✓ Ejemplo de llamada asincrónica a servicio remoto  

## Notas importantes

- Los servicios SOAP requieren una URL WSDL válida
- Es posible que necesites agregar referencias a `System.ServiceModel`
- Los servicios pueden requerir autenticación o certificados SSL
- Se pueden capturar excepciones de conexión y serialización

## Referencias

- [Documentación de dotnet-svcutil](https://github.com/dotnet/wcf/tree/main/src/System.ServiceModel.ServiceClient)
- [SOAP en .NET](https://docs.microsoft.com/es-es/dotnet/fundamentals/networking/http/http-overview)
