xcopy /E ..\src\DropIcons\bin\Release "Output\Drop Icons\"
del "Output\Drop Icons\*.config" "Output\Drop Icons\*.pdb" "Output\Drop Icons\*.xml"
cd Output
tar cf "Drop-Icons.zip" "Drop Icons"