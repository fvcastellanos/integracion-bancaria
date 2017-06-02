[![Build Status](https://travis-ci.org/fvcastellanos/integracion-bancaria.svg?branch=master)](https://travis-ci.org/fvcastellanos/integracion-bancaria)

# Integracion bancaria

## Proyecto UMG Ingenieria de Software 

### Descripcion:

El banco de Guatemala a través de sus proyectos de integración bancaria a iniciado una serie de implementaciones de aplicaciones para mejorar la seguridad y fiabilidad del proceso bancario y facilitar a los clientes una mejor atención y personalización de sus acciones.

## Configuracion

Se esta utilizando la herramienta [FlywayDB](https://flywaydb.org/) para la ejecucion de los scripts de migracion de SQL, de esta forma se puede configurar el proyecto para ser ejecutado localmente.

### Configuracion inicial

La base de datos a utilizar es [PostgreSQL](https://www.postgresql.org/) en su version 9.5.6, para poder correr los archivos de migracion se debe hacer lo siguiente:

* Crear un role llamado ```bancos```

```
CREATE ROLE bancos WITH 
	INHERIT
	LOGIN
	ENCRYPTED PASSWORD '********'; (bancos)
```

* Crear en la base de datos ```postgres``` un esquema llamado ```bancos```

```
CREATE SCHEMA bancos;
```

* Convertir al usuario ```bancos``` en el dueño del esquema ```bancos```

```
ALTER SCHEMA bancos OWNER TO bancos;
```

### Migraciones

Luego de configurada la base de datos ya es posible ejecutar las migraciones, para eso debe ingresar a la carpeta ```Migraciones``` y ejecutar los siguientes comandos:

*Windows* 

```.\migrate.bat``` para ejecutar las migraciones
```.\clean.bat``` para limpiar la base de datos

*Linux / OSX*

```./migrate.sh``` para ejecutar las migraciones
```./clean.sh``` para limpiar la base de datos

### Ambiente de desarrollo

El proyecto esta hecho usando el [.NET Core version 1.1](https://www.microsoft.com/net/download/core) el cual es multiplataforma (Windows, OSX, Linux). Para instalarlo pueden seguir las instrucciones del sitio oficial.

IDEs de Desarrollo recomendados:

* [Visual Studio Code](https://code.visualstudio.com/) (multiplataforma)
* [Visual Studio 2017](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15)
* [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)
