# Manual de Ejecución y Pruebas del Sistema

Este manual guía a los desarrolladores y testers a través del proceso de puesta en marcha de la Web API desarrollada en .NET, la realización de pruebas utilizando Postman y la ejecución de la aplicación web desarrollada con Angular.

## Pre-requisitos

Antes de comenzar, asegúrate de tener instalado lo siguiente:

- **Visual Studio** (con soporte para .NET)
- **Node.js y npm** (para Angular y sus dependencias)
- **Postman** (para probar la API)
- **SQL Server** (u otro sistema de gestión de bases de datos compatible, si se utiliza)

## Paso 1: Ejecución de la Web API

### Abrir la Solución en Visual Studio

1. Abre Visual Studio.
2. Selecciona `"Archivo" > "Abrir" > "Proyecto/Solución"`.
3. Navega a la carpeta donde está el archivo de solución de la Web API y selecciónalo.

### Configurar la Cadena de Conexión

Asegúrate de que la cadena de conexión en el archivo `appsettings.json` esté correctamente configurada para apuntar a tu instancia de SQL Server.

### Iniciar la API

1. Asegúrate de que el proyecto de la API esté configurado como proyecto de inicio.
2. Presiona `Ctrl+F5` o selecciona `"Depurar" > "Iniciar sin depurar"` para ejecutar la API.

## Paso 2: Probar la API con Postman

### Abrir Postman

1. Inicia la aplicación Postman.
2. Puedes importarla utilizando la opción `"Importar"` en Postman.

### Importar Colección `"APIs Requeridas.postman_collection"`

### Configurar y Enviar Solicitudes

1. Configura las solicitudes HTTP según los endpoints de la API. Esto puede incluir configurar parámetros, cuerpo de la solicitud y encabezados.
2. Envía las solicitudes para verificar las respuestas de la API. Asegúrate de probar todos los métodos como `GET`, `POST`.

## Paso 3: Iniciar la Aplicación Web Angular

### Abrir la Terminal o CMD

Navega a la carpeta del proyecto Angular usando `cd ruta/a/tu/proyecto`.

### Instalar Dependencias

Ejecuta `npm install` para instalar todas las dependencias necesarias listadas en el archivo `package.json`.

### Servir la Aplicación

Ejecuta `ng serve` para iniciar el servidor de desarrollo de Angular.

Accede a la aplicación en un navegador web navegando a `http://localhost:4200/`.

## Paso 4: Pruebas en la Aplicación Web

### Realizar Pruebas Funcionales

1. Navega a través de la aplicación web para asegurarte de que todas las funciones y flujos de trabajo están trabajando como se espera.
2. Comprueba la integración con la API verificando que los datos se cargan y se pueden enviar nuevas solicitudes a través de la interfaz de usuario de la aplicación Angular.
