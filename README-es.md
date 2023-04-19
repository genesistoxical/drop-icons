<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Drop Icons"/></a></p>
<h1 align="center">Drop Icons</h1>
<p align="center">Drop Icons es una aplicación para convertir imágenes a iconos (.ico) para Windows, con una función simple de arrastrar y soltar.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="https://github.com/genesistoxical/drop-icons/releases/tag/2.0.0"><img src="https://img.shields.io/github/v/release/genesistoxical/drop-icons.svg?color=9280FF&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-9280FF?style=flat-square&labelColor=343B45"/></a> 
 <a href="/installer%20src"><img alt="Installer" src="https://img.shields.io/badge/Installer-ISS-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="Languages" src="https://img.shields.io/badge/Idiomas-2-9280FF?style=flat-square&labelColor=343B45"/></a>
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Características
* Interfaz limpia e intuitiva.
* Convierte rápidamente muchas imágenes en iconos a la vez, con la función de arrastrar y soltar.
* Cambiar entre el idioma English y Español.
* Personalizar el color del tema.
* Número de las imágenes a convertir, restando tres que se muestran como vista previa.
* Guardar los iconos en la misma carpeta (por defecto).
* Guardar los iconos en una carpeta específica.
* Guarda la configuración en un archivo .ini (excepto para los switches).
* Habilitar y deshabilitar Topmost.
* Los iconos generados son de 16 píxeles pero incluyen tamaños de 16, 32, 48, 64, 128, 256 píxeles para un ícono de alta calidad.
* Evita la duplicación de una imagen que se ha añadido previamente.
* Opción para generar un icono mini.
* Esquinas adaptables (redondeadas o simples), dependiendo la versión del sistema operativo. 🆕

## Previa
<a href="#"><img src="docs/assets/Drop-Icons-v2.gif"/></a>

## Uso
Arrastra y suelta tus imágenes en el espacio vacío, obtendrás una vista previa de tres imágenes, excepto si solo arrastras una o dos. Más abajo puedes ver la cantidad total de imágenes para convertir (restando tres de la previa). Si no puedes arrastrar, cliquea en `Agregar`.

Deja el primer switch activado si deseas guardarlos en la misma carpeta, si prefieres elegir una carpeta específica, desactivalo. También puedes generar un icono mini activando el segundo switch. Por último, haz clic en el botón `Convertir`, aparecerá un círculo de carga y una vez que todo esté limpio en la interfaz, tendrás tus iconos creados.

Si necesitas eliminar las imágenes que agregaste por error, haz clic en el icono de las flechas. Recuerda que puedes arrastrar imágenes tantas veces como quieras incluso antes de hacer clic en el botón `Convertir`.

<br>

Dando click en el botón superior de Info, aparecerá una nueva ventana en la que puedes:

- **Cambiar el idioma:** En la sección inferior que dice **Idioma de Drop Icons** haz clic en el icono de las flechitas para cambiar entre Español o English, luego clic en el botón de regresar y se reiniciará con el idioma que hayas elegido.

- **Cambiar el tema:** En la parte inferior, haz clic sobre `Change Theme...` y elige tu color personalizado en la pequeña ventana que aparece (puedes ayudarte con la paleta de colores o escribir un color HEX), después selecciona Aplicar. Para regresar al que venía por defecto repite los pasos anteriores y cliquea el botón morado debajo del selector de tono, finalmente oprime Aplicar.

- **Encontrar información sobre el contenido de terceros:** En la sección izquierda están los nombres de cada librería, proyecto, iconos o tipografías que fueron utilizados, al igual que Drop Icons. Cliquea en uno de ellos para leer su licencia, la cual incluye el autor(a) o autores(as). Puedes leer una corta descripción más abajo o hacer clic sobre el icono del enlace para ir al repositorio o sitio oficial.

<br>

Para elegir que Drop Icons esté encima de todas las ventanas (Topmost) o no, da clic derecho en cualquier lugar de la ventana principal y elige Habilitar Topmost o Deshabilitar Topmost.

## Opciones
<a href="#"><img src="docs/assets/Drop-Icons-Options-v2.gif"/></a>

## Instalador
Para compilar el instalador es necesario [Inno Setup](https://jrsoftware.org/isinfo.php), los archivos se encuentran en la carpeta [installer src](/installer%20src). Solo debes abrir el proyecto (Installer.iss) y compilarlo, a menos que desees hacer una modificación. Al finalizar, en la misma ubicación dejará una carpeta llamada Output.

**Portable.bat** permite comprimir en .zip rápidamente la versión portable y elimina archivos innecesarios. Solo funciona en Windows 11 y 10.

Ambos .iss y .bat obtienen los archivos que son necesarios dentro de su carpeta y/o la carpeta Release (debido a las rutas relativas).

## Contribuciones
* Si haces comentarios en el código, preferiblemente en Español, por favor.
* Los nombres de las variables deben estar en Inglés.
* Si abres un **Issue**, puede ser en Inglés o Español.
* **Pull request** en Inglés, en la descripción puedes agregar detalles en Inglés o Español.

## Configuración
El archivo `Config.ini` almacena información del lenguaje, color del tema y si está activada o no la opción TopMost.

~~~
[Options]
Language = en
Topmost = true

[Theme]
#FF9280FF
~~~

>Nota: las dos opciones de tipo switch no se guardan porque no son opciones que suelan activarse todo el tiempo.

## Esquinas adaptables
<a href="#"><img src="docs/assets/Drop-Icons-Corners-v2.png"/></a>

# Creditos
Drop Icons está basado en [Iconizer](https://github.com/willnode/Iconizer) bajo [MIT License](https://github.com/willnode/Iconizer/blob/master/LICENSE).

* [HandyControls](https://github.com/ghost1372/HandyControls) bajo [MIT License](https://github.com/ghost1372/HandyControls/blob/develop/LICENSE).

* [FolderBrowserEx](https://github.com/evaristocuesta/FolderBrowserEx) library bajo [MIT License](https://github.com/evaristocuesta/FolderBrowserEx/blob/master/LICENSE).

* [Noto Music](https://fonts.google.com/noto/specimen/Noto+Music) bajo [SIL Open Font License](/src/DropIcons/Docs/Noto%20Music/OFL.txt).

* Los iconos son parte de [Teenyicons](https://github.com/teenyicons/teenyicons) bajo [MIT License](https://github.com/teenyicons/teenyicons/blob/master/LICENSE).

* [WinVersion](https://github.com/shaovoon/win_version_detection) detection bajo [MIT License](https://github.com/shaovoon/win_version_detection/blob/main/LICENSE).

*Puedes encontrar todas las licencias [aquí](/src/DropIcons/Docs).*

## ¿Qué es lo nuevo?
`Versión 1.0.0` se creó en Windows Forms. Drop Icons ya no se desarrollará con esa tecnología, sin embargo, todavía puedes encontrar y/o descargar la última versión oficial aquí:
<br>
🏷️ [winforms-v1-final](https://github.com/genesistoxical/drop-icons/tree/winforms-v1-final)

<br>

`Versión 2.0.0` está desarrollada con Windows Presentation Foundation (WPF) para mejorar la interfaz e incluir esquinas redondeadas adaptables, según la versión del sistema operativo.

En esta última versión se ha mejorado la ventana "Acerca de", el archivo Config.ini se ha modificado para usar solo el color del tema en HEX y no en RGB, además que se ha reemplazado el selector de color (para el tema) por uno mucho más moderno.

Debido a este último cambio, se eliminó Colors.dat ya que no existe botón para guardar los personalizados, en su lugar hay una paleta de colores.

## Licencia
**MIT License**

Copyright (c) 2022 - 2023 Génesis Toxical ([read here](LICENSE)).
