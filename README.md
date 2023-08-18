# .Net8 SDL2

The project is using the bindings from here:
https://github.com/flibitijibibo/SDL2-CS/blob/f8c6fc407fbb22072fdafcda918aec52b2102519/src/SDL2.cs

To build for the web:
```
dotnet publish -r browser-wasm -c Debug /p:TargetArchitecture=wasm /p:PlatformTarget=AnyCPU /p:MSBuildEnableWorkloadResolver=false --self-contained
```
