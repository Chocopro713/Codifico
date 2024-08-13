# Manual Técnico de la Web API

## Introducción
Este manual describe la arquitectura y organización de la Web API diseñada para la predicción de la siguiente venta. Se utilizan prácticas y patrones de diseño modernos para asegurar una base de código mantenible, escalable y eficiente.

## Arquitectura de la Aplicación
La aplicación utiliza una arquitectura basada en principios de **Clean Architecture**, que permite desacoplar el dominio y la lógica de negocio de las interfaces de usuario y otras tecnologías de soporte. Los principales beneficios de esta arquitectura incluyen:

- Independencia del framework
- Testabilidad
- Independencia de la UI y la base de datos

## Estructura de Carpetas
La solución está organizada en varias capas y proyectos:

- **Api**: Contiene los controladores y el punto de entrada de la API. Maneja las solicitudes HTTP y las delega a la capa de aplicación.
- **Application**: Encargada de la lógica de negocio, implementa CQRS (Command Query Responsibility Segregation) para separar las consultas de las operaciones de modificación del estado.
- **Domain**: Define las entidades, interfaces de repositorios y objetos de dominio esenciales.
- **Infrastructure**: Implementa las interfaces definidas en el dominio, manejo de bases de datos, y otras operaciones que interactúan con tecnologías externas.
- **Contracts**: Incluye los DTOs (Data Transfer Objects), interfaces para servicios externos y otras abstracciones necesarias para las capas superiores.

## CQRS y MediatR
**CQRS** es un patrón que separa la lectura de los datos (consultas) de las modificaciones del estado (comandos), lo que permite optimizar cada una de estas operaciones de manera independiente. Utilizamos **MediatR** como un mediador para implementar este patrón, delegando las responsabilidades de manejo de comandos y consultas a los manejadores correspondientes.

## Inyección de Dependencias
La API utiliza **inyección de dependencias** para desacoplar la creación de objetos de su uso. Esto facilita la gestión de dependencias y mejora la testabilidad del código. La configuración de las dependencias se realiza en el startup de la aplicación, asegurando que cada componente reciba las dependencias necesarias para su operación.

## Documentación y Comentarios
El código está ampliamente documentado con comentarios que explican el propósito y funcionamiento de cada clase y método. Esto incluye comentarios en los modelos, servicios, controladores y cualquier lógica de negocio, asegurando que el código sea fácil de entender y mantener.

## Conclusión
La Web API está diseñada para ser robusta, fácil de mantener y expandir. Gracias a la utilización de patrones de diseño como **CQRS** y **Clean Architecture**, junto con prácticas como la inyección de dependencias y una adecuada documentación, la API se mantiene limpia y clara, facilitando futuras mejoras y mantenimientos.

---

# Manual Técnico de la Web App

## Introducción
Este manual técnico describe la estructura y las características de la aplicación web desarrollada utilizando **Angular** y **Axios** para realizar solicitudes HTTP a una Web API. Esta aplicación facilita la interfaz de usuario para la predicción de la siguiente venta.

## Arquitectura de la Aplicación
La aplicación está construida sobre el framework **Angular**, que proporciona una plataforma robusta para desarrollar aplicaciones web de una sola página (SPA). Angular organiza el código en módulos y componentes, lo que facilita la escalabilidad y mantenibilidad.

## Componentes y Servicios
Cada componente en Angular maneja una parte específica de la interfaz de usuario y se comunica con los servicios para obtener datos o realizar acciones. Los servicios utilizan **Axios** para realizar llamadas HTTP a la Web API, manejando la interacción con el backend de forma eficiente.

## Conclusión
La aplicación web Angular está diseñada para ser modular, escalable y fácil de mantener. Utiliza tecnologías modernas como **Angular**, **Axios** y **RxJS** para asegurar una experiencia de usuario fluida y eficiente. La estructura del proyecto y la documentación detallada permiten que el equipo de desarrollo gestione y expanda la aplicación eficazmente.
