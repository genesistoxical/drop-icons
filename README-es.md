<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Drop Icons"/></a></p>
<h1 align="center">Drop Icons</h1>
<p align="center">Drop Icons es una aplicación para convertir imágenes a iconos (.ico) para Windows, con una función simple de arrastrar y soltar.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="releases/latest"><img src="https://img.shields.io/github/v/release/genesistoxical/release-prueba.svg?color=9280FF&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-9280FF?style=flat-square&labelColor=343B45"/></a> 
 <a href="Installer-src"><img alt="Installer" src="https://img.shields.io/badge/Installer-ISS-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="Languages" src="https://img.shields.io/badge/Idiomas-2-9280FF?style=flat-square&labelColor=343B45"/></a>
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Características
* Interfaz limpia e intuitiva.
* Permite convertir rápidamente muchas imágenes en iconos a la vez, con la función de arrastrar y soltar.
* Cambia entre el idioma English y Español.
* Muestra una vista previa con tres imágenes y la cantidad total a convertir (restando tres de la previa).
* Guardar los iconos en la misma carpeta (por defecto).
* Guardar los iconos en una carpeta específica.
* Habilitar y deshabilitar TopMost.
* Los iconos generados son de 16 píxeles pero incluyen tamaños de 16, 32, 48, 64, 128, 256 píxeles para un icono de alta calidad.
* Evita la duplicación de una imagen que se ha añadido previamente.
* Opción para generar un icono mini.

## Previa
<a href="#"><img src="docs/assets/Drop-Icons.gif"/></a>

## Uso
Arrastra y suelta tus imágenes en el espacio vacío, obtendrás una vista previa de tres imágenes, excepto si solo arrastras una o dos. Más abajo puedes ver la cantidad total de imágenes para convertir (restando tres de la previa). Si no puedes arrastrar, cliquea en `Agregar`.

Deja el primer switch activado si deseas guardarlos en la misma carpeta, si prefieres elegir una carpeta específica, desactivalo. También puedes generar un icono mini activando el segundo switch. Por último, haz clic en el botón `Convertir`, aparecerá un círculo de carga y una vez que todo esté limpio en la interfaz, tendrás tus iconos creados.

Si necesitas eliminar las imágenes que agregaste por error, haz clic en el icono de las flechas. Recuerda que puedes arrastrar imágenes tantas veces como quieras incluso antes de hacer clic en el botón `Convertir`.

Puede deshabilitar o habilitar la opción **TopMost** (Drop Icons sobre todas las ventanas) desde el menú contextual, haciendo clic derecho en cualquier lugar y `Habilitar TopMost` o `Deshabilitar TopMost`.

Para cambiar el idioma debes cliquear el botón superior de Info, aparecerá una nueva ventana. En la sección inferior que dice **Idioma de Drop Icons** haz clic en el icono de las flechitas para cambiar entre Español o English, luego clic en el botón de regresar y se reiniciará con el idioma que hayas elegido.

## Opciones
<a href="#"><img src="docs/assets/Drop-Icons-Options.gif"/></a>

## Instalador
Para compilar el instalador es necesario [Inno Setup](https://jrsoftware.org/isinfo.php), los archivos se encuentran en la carpeta [Installer src](Installer-src).

Solo es necesario abrir el proyecto .iss y compilarlo, a menos que desees hacer una modificación; éste automáticamente obtiene los archivos que necesita dentro de su carpeta y la carpeta **Release** (debido a las rutas relativas), pero se recomienda no mover las carpetas o reenombrarlas.

Al finalizar, donde se encuentra el proyecto dejará una carpeta llamada **Output**.

## Contribuciones
* Si haces comentarios en el código, preferiblemente en Español, por favor.
* Los nombres de las variables deben estar en Inglés.
* Si abres un **Issue**, puede ser en Inglés o Español.
* **Pull request** en Inglés, en la descripción puedes agregar detalles en Inglés o Español.

## Controles
Si necesitas agregar más o diferentes controles, haz clic derecho en cualquier parte del **Cuadro de herramientas**, cliquea en `Agregar pestaña` y escribe **AltoControls**.

Haz clic derecho en cualquier lugar dentro de la pestaña AltoControls y cliquea en `Elegir elementos...`. Selecciona **Componentes de .NET Framework**, presiona `Examinar...`, agrega **AltoControls.dll** que se ubica en la carpeta Lib y luego `Aceptar`.

## Creditos
Drop Icons está basado en [Iconizer](https://github.com/willnode/Iconizer) bajo [MIT License](https://github.com/willnode/Iconizer/blob/master/LICENSE), y como un reconocimiento, mantiene un archivo con ese nombre.

Incluye una version compilada de [AltoControls](https://github.com/aalitor/AltoControls) bajo [MIT License](https://github.com/aalitor/AltoControls/blob/on-development/license.txt), con dos archivos modificados:
* **SlideButton**: Borde y colores para darle un estilo aún más moderno.
* **AltoButton**: Reemplazo de DrawString con una Label, para que detecte la fuente utilizada sin estar instalada.

*Puedes encontrar los archivos modificados [aquí](https://github.com/genesistoxical/modified-files/tree/main/AltoControls).*
~~~
SwitchButton.cs
AltoButton.cs
~~~

[FolderBrowserEx](https://github.com/evaristocuesta/FolderBrowserEx) library bajo [MIT License](https://github.com/evaristocuesta/FolderBrowserEx/blob/master/LICENSE).

Contiene toda la familia de [Noto Sans](https://fonts.google.com/noto/specimen/Noto+Sans) bajo [SIL Open Font License](#), aunque solo utiliza la versión Regular.

Los iconos son parte de [Teenyicons](https://github.com/teenyicons/teenyicons) bajo [MIT License](https://github.com/teenyicons/teenyicons/blob/master/LICENSE).

*Puedes encontrar todas las licencias aquí.*

## Licencia
**MIT License**

Copyright (c) 2022 Génesis Toxical ([read here](https://github.com/genesistoxical/DropIcons/LICENSE)).
