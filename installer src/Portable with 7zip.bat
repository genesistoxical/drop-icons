cd "..\src\DropIcons\bin\"
ren "Release" "Drop Icons"
"C:\Program Files\7-Zip\7z.exe" a "..\..\..\installer src\Output\Drop-Icons.zip" "Drop Icons\" -r -x!*.config -x!*.pdb -x!*.xml
ren "Drop Icons" "Release"