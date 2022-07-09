xcopy /E ..\src\DropIcons\bin\Release "Output\Drop Icons\"
del "Output\Drop Icons\*.config" "Output\Drop Icons\*.pdb"
cd Output
"C:\Program Files\7-Zip\7z.exe" a "Drop-Icons.zip" "Drop Icons\"