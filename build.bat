dotnet publish -r browser-wasm -c Debug /p:TargetArchitecture=wasm /p:PlatformTarget=AnyCPU /p:MSBuildEnableWorkloadResolver=false --self-contained
