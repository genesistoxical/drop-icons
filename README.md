<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Drop Icons"/></a></p>
<h1 align="center">Drop Icons</h1>
<p align="center">Drop Icons is a utility to convert images to icons (.ico) for Windows, with a simple Drag and Drop feature.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="releases/latest"><img src="https://img.shields.io/github/v/release/genesistoxical/release-prueba.svg?color=9280FF&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-9280FF?style=flat-square&labelColor=343B45"/></a> 
 <a href="Installer-src"><img alt="Installer" src="https://img.shields.io/badge/Installer-ISS-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="Languages" src="https://img.shields.io/badge/Languages-2-9280FF?style=flat-square&labelColor=343B45"/></a>
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Features
* Clean and intuitive interface.
* Allows you to quickly convert many images to icons at once, with the Drag and Drop feature.
* Switch between English and Spanish language.
* Shows a preview with three images and the total amount to convert (subtracting three from the preview).
* Save icons in the same folder (default).
* Save icons in a specific folder.
* Enable and disable TopMost.
* Generated icons are 16px but include sizes of 16, 32, 48, 64, 128, 256 pixels for a high quality icon.
* Prevents duplication of an image that has been previously added.
* Option to generate tiny icon.

## Preview
<a href="#"><img src="docs/assets/Drop-Icons.gif"/></a>

## Usage
Drag and drop your images into the empty space, you will preview three images, except if you only drag one or two. Below you can see the total amount of images to convert (subtracting three from preview). If you cannot drag, click on `Add images`.

Leave the first switch on if you want to save them in the same folder, if you prefer to choose a specific folder, turn it off. You can also generate a tiny icon by turning on the second switch. Finally, click on `Convert` button, a loading circle will appear and as soon as everything is cleaned on the interface, you will have your icons created.

If you need to delete the images you have added by mistake, click on the arrows icon. Remember that you can drag images as many times as you want even before clicking the `Convert` button.

You can disable or enable the **TopMost** option (Drop Icons on top of all windows) from the context menu, by right clicking anywhere and `Enable TopMost` or `Disable TopMost`.

To change the language you must click on the top Info button, a new window will appear. In the lower section that says **Drop Icons Language** click on the little arrows icon to switch between Español or English, then click on the back button and it will restart with the language you have chosen.

## Options
<a href="#"><img src="docs/assets/Drop-Icons-Options.gif"/></a>

## Installer
To compile the installer you need [Inno Setup](https://jrsoftware.org/isinfo.php), the files are located in the [Installer src](Installer-src) folder.

You just need to open the .iss project and compile it, unless you want to make a change; it automatically gets the files it needs into its folder and the **Release** folder (because of the relative paths), but it is recommended not to move the folders or rename them.

When finished, where the project is, it will leave a folder called **Output**.

## Contributing
* If you make comments in the code, preferably in Spanish, please.
* Variable names must be in English.
* If you open an **Issue**, it can be in English o Spanish.
* **Pull request** in English, in the description you can add details in English or Spanish.

## Controls
If you need to add more or different controls, right click anywhere in the Toolbox, click on `Add Tab` and type **AltoControls**.

Right click anywhere inside the AltoControls tab and click `Choose Items...`. Select **.NET Framework Components**, press `Browse...` add **AltoControls.dll** which is located in the Lib folder and then `OK`.
## Credits
Drop Icons is based on [Iconizer](https://github.com/willnode/Iconizer) under [MIT License](https://github.com/willnode/Iconizer/blob/master/LICENSE), and as an acknowledgment, it keeps a file with that name.

Includes a compiled version of [AltoControls](https://github.com/aalitor/AltoControls) under [MIT License](https://github.com/aalitor/AltoControls/blob/on-development/license.txt), with two modified files:
* **SlideButton**: Border and colors to give it an even more modern style.
* **AltoButton**: Replacing DrawString with a Label, so that it would detect the font used without being installed.

*You can find the modified files [here](https://github.com/genesistoxical/modified-files/tree/main/AltoControls).*
~~~
SwitchButton.cs
AltoButton.cs
~~~

[FolderBrowserEx](https://github.com/evaristocuesta/FolderBrowserEx) library under [MIT License](https://github.com/evaristocuesta/FolderBrowserEx/blob/master/LICENSE).

Contains the entire family of [Noto Sans](https://fonts.google.com/noto/specimen/Noto+Sans) under [SIL Open Font License](#), although it only uses the Regular version.

Icons are part of [Teenyicons](https://github.com/teenyicons/teenyicons) under [MIT License](https://github.com/teenyicons/teenyicons/blob/master/LICENSE).

*You can find all licenses here.*

## License
**MIT License**

Copyright (c) 2022 Génesis Toxical ([read here](https://github.com/genesistoxical/DropIcons/LICENSE)).
