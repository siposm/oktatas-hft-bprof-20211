## Mappaszerkezet magyarázó

- 01-WEBAPI
    - `jsonHandler`
        - végpontról való letöltés (WebClient)
        - JSON állományok kezelése (Newtonsoft JSON.NET serlialize / deserialize)
    - `nancydemo` 
        - saját API-k létrehozása Nancy segítségével
    - `consoleClientNancy`
        - console kliens ami a Nancy-ben létrehozott API végpontot használja
- 02-PARALLELPROG
    - TODO
    - TODO
    - TODO
    - TODO

## CLI parancsok

- 01-WEBAPI
    - `dotnet new web`
    - `dotnet add package Nancy --version 2.0.0`
    - `dotnet add package Microsoft.AspNetCore.Owin`
    - `dotnet add package Microsoft.AspNetCore.Server.Kestrel`
    - `dotnet add package Newtonsoft.Json`

## Letöltések

VS Code: https://code.visualstudio.com/insiders/
.Net Core: https://dotnet.microsoft.com/download/dotnet-core/3.1