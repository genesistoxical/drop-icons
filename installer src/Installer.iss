#define MyAppName "Drop Icons"
#define MyAppVersion "3.2.0"
#define MyAppPublisher "Génesis Toxical"
#define MyAppURL "https://genesistoxical.github.io/drop-icons/"
#define MyAppExeName "Drop Icons.exe"

[Setup]
AppId={{A072B914-4E3D-4DAD-9F9B-D1D38965482E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
VersionInfoVersion=3.2.0.0
AppPublisher={#MyAppPublisher}
AppCopyright={#MyAppPublisher} © 2022 - 2025
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
LicenseFile=Drop Icons.txt
OutputDir=Output
OutputBaseFilename=Drop-Icons-Installer
SetupIconFile=..\src\DropIcons\Resources\Icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern      
WizardSmallImageFile=Wizard Small Image.bmp
WizardImageFile=Wizard Image File.bmp
WizardSizePercent=110,100 
DisableProgramGroupPage=yes
UninstallDisplayIcon={uninstallexe}
UsedUserAreasWarning=no                                    

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[InstallDelete]
Type: files; Name: "{userappdata}\Drop Icons\Colors.dat";
Type: files; Name: "{app}\AltoControls.dll";
Type: files; Name: "{app}\Docs\AltoControls.txt";
Type: files; Name: "{app}\Docs\Noto Sans\*";
Type: filesandordirs; Name: "{app}\Docs\Noto Sans";

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
Source: "..\src\DropIcons\bin\Release\*"; DestDir: "{app}"; Excludes: "*.ini"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\src\DropIcons\bin\Release\Config.ini*"; DestDir: "{userappdata}\{#MyAppName}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon