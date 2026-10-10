# School Parking Management System

Web application for managing parking permits and vehicle access
within an educational institution.

## Problem

The current parking management process relies mainly on physical
forms and email communication for parking permit requests and
vehicle registration.

This makes the process difficult to manage, track, and maintain.

## Goal

Create a centralized web platform that improves the management of:

- Parking permit requests
- Parking permits
- Vehicle registration
- Vehicle entries and exits
- Announcements
- Students and staff parking access

## Architecture

The project will be designed following:

- Modular Monolith
- Vertical Slice Architecture
- Object-Oriented Programming (OOP)

The architecture and technology stack will be defined during
the design phase before implementation begins.

## Project Status

🟡 Design and requirements analysis


## Actividad 11 — Test Driven Development (TDD)

### 1. Objetivo

Aplicar la metodología **Test Driven Development (TDD)** en el desarrollo del sistema de estacionamiento escolar, utilizando pruebas unitarias automatizadas para guiar la implementación y mejorar la calidad del código.

La actividad se desarrolla mediante el ciclo **Red-Green-Refactor**, utilizando C#, .NET 10 y xUnit.

### 2. Historia de usuario HU-01

**Nombre:** Validación de solicitudes de estacionamiento.

**Como** alumno, profesor o administrativo,  
**quiero** que el sistema valide los datos de mi solicitud de estacionamiento,  
**para** evitar el envío de solicitudes incompletas.

**Criterio de aceptación CA-01:**

- Una matrícula vacía debe ser rechazada.
- Una matrícula que contenga únicamente espacios debe ser rechazada.
- Una matrícula nula debe ser rechazada.
- Una matrícula con contenido debe ser aceptada.

Esta validación comprueba la presencia de un valor, no el formato oficial de las placas vehiculares.

### 3. Metodología aplicada

#### RED — Prueba fallida

Se creó una prueba unitaria antes de implementar la validación.

**Prueba:** `Validate_WhenLicensePlateIsEmpty_ShouldReturnFalse`

La prueba esperaba que una matrícula vacía produjera `false`. Inicialmente, la implementación provisional devolvía `true`, provocando un fallo de aserción.

**Evidencia en Git:**

`test: add failing test for empty parking license plate`

#### GREEN — Implementación mínima

Se implementó la lógica mínima para satisfacer el criterio de aceptación:

```csharp
public bool Validate(string licensePlate)
{
    return !string.IsNullOrWhiteSpace(licensePlate);
}
```

Se ejecutaron las pruebas y se comprobó que la validación funcionaba correctamente.

**Evidencia en Git:**

`feat: validate required vehicle license plate`

#### REFACTOR — Mejora del código

Se simplificó la implementación utilizando una expresión directa y se explicitó que el parámetro puede recibir valores nulos:

```csharp
public bool Validate(string? licensePlate) =>
    !string.IsNullOrWhiteSpace(licensePlate);
```

La refactorización conservó el comportamiento de la validación. Posteriormente, se ejecutaron nuevamente las pruebas para comprobar que no se introdujeron regresiones.

**Evidencia en Git:**

`refactor: simplify parking license plate validation`

### 4. Pruebas unitarias

Se utilizó **xUnit** para verificar el comportamiento de la validación.

| Escenario | Entrada | Resultado esperado |
|---|---|---|
| Matrícula vacía | `""` | `false` |
| Matrícula con espacios | `"   "` | `false` |
| Matrícula nula | `null` | `false` |
| Matrícula con contenido | `"ABC-123"` | `true` |

Las pruebas se encuentran en:

`tests/DevelopmentCeti.Tests/Parking/ParkingRequestValidatorTests.cs`

### 5. Estructura del proyecto

```text
DevelopmentCeti/
├── src/
│   └── DevelopmentCeti.Core/
│       └── Parking/
│           └── ParkingRequestValidator.cs
├── tests/
│   └── DevelopmentCeti.Tests/
│       └── Parking/
│           └── ParkingRequestValidatorTests.cs
└── README.md
```

### 6. Ejecución de las pruebas

**Requisitos:**

- .NET 10 SDK
- Acceso a las dependencias NuGet del proyecto

Desde la raíz del repositorio, ejecutar:

```powershell
dotnet test tests/DevelopmentCeti.Tests/DevelopmentCeti.Tests.csproj
```

El comando compila los proyectos y ejecuta las pruebas unitarias, mostrando los resultados en la terminal.

### 7. Evidencia del proceso TDD

El historial de Git permite revisar la secuencia de desarrollo:

1. **RED:** creación de la prueba fallida.
2. **GREEN:** implementación mínima para superar la prueba.
3. **REFACTOR:** mejora del código y verificación de las pruebas.

Para consultar el historial:

```powershell
git log --oneline
```

### 8. Conclusión

La implementación de TDD permitió desarrollar una regla de validación mediante pruebas automatizadas, comenzando por definir el comportamiento esperado antes de escribir la solución funcional.

El ciclo Red-Green-Refactor proporcionó evidencia de cómo las pruebas pueden guiar el desarrollo, facilitar mejoras en la estructura del código y ayudar a prevenir regresiones.

Esta actividad demuestra la aplicación inicial de TDD en una funcionalidad del sistema de estacionamiento escolar.
