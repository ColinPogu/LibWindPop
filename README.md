# LibWindPop

LibWindPop provides tools and native libraries for unpacking and repacking PAK and RSB archives used in PopCap titles.

## Requirements
- .NET 8 SDK
- Visual Studio 2022 or newer with Desktop C++ tools

## Building the shared library
Run `build/win-x64-shared-library.bat` from a Developer Command Prompt. The script builds a NativeAOT DLL and places the outputs in `build/publish/nativeaot/shared/win-x64`.

## Running the C sample
1. Open `samples/cpp/PakAndPtxCoder/PakAndPtxCoder.vcxproj` in Visual Studio.
2. Choose the **Release | x64** configuration and build the project.
3. Edit `samples/cpp/PakAndPtxCoder/main.c` to point to your own PAK file locations:

```c
const char rawPakPath[]  = "D:\\main.pak";
const char newPakPath[]  = "D:\\main_new.pak";
const char unpackPath[]  = "D:\\main_unpack_pak";
```

Running the compiled executable will unpack `rawPakPath` to `unpackPath` and then repack the contents to `newPakPath`.
