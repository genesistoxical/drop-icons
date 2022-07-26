<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Drop Icons"/></a></p>
<h1 align="center">Drop Icons</h1>
<p align="center">Drop Icons is a utility to convert images to icons (.ico) for Windows, with a simple Drag and Drop feature.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="https://github.com/genesistoxical/drop-icons/releases/tag/1.0.0"><img src="https://img.shields.io/github/v/release/genesistoxical/drop-icons.svg?color=9280FF&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-9280FF?style=flat-square&labelColor=343B45"/></a> 
 <a href="/installer%20src"><img alt="Installer" src="https://img.shields.io/badge/Installer-ISS-9280FF?style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="Languages" src="https://img.shields.io/badge/Languages-2-9280FF?style=flat-square&labelColor=343B45"/></a>
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Features
* Clean and intuitive interface.
* Quickly convert multiple images to icons at once, with Drag and Drop feature.
* Switch between English and Spanish language.
* Customize theme color.
* Number of images to convert, subtracting three that are shown as preview.
* Save icons in the same folder (default).
* Save icons in a specific folder.
* Saves the configuration to an .ini file (except for switches).
* Enable and disable TopMost.
* Generated icons are 16px but include 16, 32, 48, 64, 128, 256 pixel sizes for a high quality icon.
* Prevents duplication of an image that has been previously added.
* Option to generate tiny icon.
* Resize to 1:1 without stretching the image.

## Preview
<a href="#"><img src="docs/assets/Drop-Icons.gif"/></a>

## Usage
Drag and drop your images into the empty space, you will preview three images, except if you only drag one or two. Below you can see the total amount of images to convert (subtracting three from preview). If you cannot drag, click on `Add images`.

Leave the first switch on if you want to save them in the same folder, if you prefer to choose a specific folder, turn it off. You can also generate a tiny icon by turning on the second switch. Finally, click on `Convert` button, a loading circle will appear and as soon as everything is cleaned on the interface, you will have your icons created.

If you need to delete the images you have added by mistake, click on the arrows icon. Remember that you can drag images as many times as you want even before clicking the `Convert` button.

<br>

By clicking on the upper Info button, a new window will appear in which you can:

- **Change language:** In the lower section that says Language, click on the little arrows icon to switch between Español or English, then click on the back button and it will restart with the language you have chosen.

- **Change theme:** At the bottom, click on `Change Theme...` and choose your custom color in the small window that appears, you can also add it to your "custom colors" to use later, then select OK. To return to the default one, repeat the previous steps, choose one of the many purples (or don't choose any color) and click OK.

- **Find information about third-party content:** In the upper section are the names of each library, project, icons or fonts that were used, as well as Drop Icons.
Click on one of them to read its license, which includes the author(s). You can read a short description below or click on the link icon to go to the repository or official site.

<br>

To choose whether Drop Icons is on top of all windows (TopMost) or not, right-click anywhere in the main window and choose Enable TopMost or Disable TopMost.

## Options
<a href="#"><img src="docs/assets/Drop-Icons-Options.gif"/></a>

## Installer
To compile the installer you need [Inno Setup](https://jrsoftware.org/isinfo.php), the files are located in the [installer src](/installer%20src) folder. You just need to open the project (Installer.iss) and compile it, unless you want to make a change. When finished, it will leave a folder called Output in the same location.

**Portable with 7zip.bat** allows you to quickly zip the portable version and remove unnecessary files. It only works with [7zip](https://www.7-zip.org/).

Both .iss and .bat get the files that are needed within their folder and/or the Release folder (because of relative paths).

## Contributing
* If you make comments in the code, preferably in Spanish, please.
* Variable names must be in English.
* If you open an **Issue**, it can be in English o Spanish.
* **Pull request** in English, in the description you can add details in English or Spanish.

## Config
`Config.ini` file stores information about the language, theme color, and whether or not the TopMost option is enabled.

~~~
[Options]
Language = en
TopMost = true

[Theme]
146
128
255
~~~

>Note: The two switch-type options are not saved because they are not options that are typically activated all the time.

The custom color palette is saved in the `Colors.dat` file.

Drop Icons first looks for both files in the same folder where the executable is located, so if you had the portable and installable version, there would be no problem.

If it doesn't find the files, that means it's installed and will look in *%AppData%\Drop Icons*

## Controls
If you need to add more or different controls, right-click anywhere in the Toolbox, select Add Tab and type *AltoControls*.

Right-click anywhere inside the tab you created, click `Choose Items...` and select **.NET Framework Components**. Now from `Browse...`, add **AltoControls.dll** which is located in the Lib folder and finally OK.

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

*You can find all licenses [here](/src/DropIcons/Docs).*

## License
**MIT License**

Copyright (c) 2022 Génesis Toxical ([read here](LICENSE)).
