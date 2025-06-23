rd /s /q ..\src\obj
dotnet publish ..\src\LibWindPop.csproj /p:NativeLib=Shared;PublishAot=true -c Release -f net8.0 -r win-x64 -o ..\build\publish\nativeaot\shared\win-x64
copy ..\src\bin\Release\net8.0\win-x64\native\LibWindPop.lib ..\build\publish\nativeaot\shared\win-x64\LibWindPop.lib
copy ..\src\bin\Release\net8.0\win-x64\native\LibWindPop.exp ..\build\publish\nativeaot\shared\win-x64\LibWindPop.exp
copy ..\src\libwindpop.h ..\build\publish\nativeaot\shared\win-x64\LibWindPop.h
rem Convert header to CRLF line endings to avoid MSVC parse errors
powershell -Command "Get-Content ..\build\publish\nativeaot\shared\win-x64\LibWindPop.h | Out-File -Encoding ASCII ..\build\publish\nativeaot\shared\win-x64\LibWindPop.h"
