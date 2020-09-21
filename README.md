## Általános információk
Az ÓE NIK Üzemménrök-informatikus (BPROF) képzésen található **Haladó Fejlesztési Technikák** tárgyhoz tartozó laboranyagok (csak a saját részeim).

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
    - TODO LATER

##  Repository használata
Minden esetben javasolt jelen repository követése hétről-hétre, mivel az anyagok folyamatosan frissülnek, módosulnak ahogy halad előre a félév.

### Letöltés
Clone gomb mellett a letöltés nyílra katt, majd mentés a kiválaszott állományban. Ha csak egy dedikált mappára van szükséged, lépj bele itt a felületen és ugyan ezen gombra kattintva van lehetőség csak azt az 1 mappát letölteni.

### Git
Windows esetén: töltsd le, telepítsd, indítsd el: https://git-scm.com/downloads

Linux / Mac esetén, CLI-ből:

`sudo apt-get update`\
`sudo apt-get install git`\
ellenőrzés: `git --version`

Utána (Mac / Win / Linux esetén egyaránt): 

`cd ~/Desktop/`\
`mkdir hft-laboranyag`\
`cd hft-laboranyag`\
`git clone https://gitlab.com/siposm/oktatas-hft-20211.git`

Későbbi "frissítések letöltése":\
`git pull` a gyökérmappából

## CLI parancsok

- 01-WEBAPI
    - `dotnet new web`
    - `dotnet new console`
    - `dotnet add package Nancy --version 2.0.0`
    - `dotnet add package Microsoft.AspNetCore.Owin`
    - `dotnet add package Microsoft.AspNetCore.Server.Kestrel`
    - `dotnet add package Newtonsoft.Json`
    - `dotnet restore`

## Letöltések

- VS Code: https://code.visualstudio.com/insiders/
- .Net Core: https://dotnet.microsoft.com/download/dotnet-core/3.1


<br><br>

---

<br><br>

Meglátás / észrevétel / probléma esetén megtalálható vagyok az alábbi elérhetőségen.

**Sipos Miklós**\
Tanszéki Mérnök\
sipos.miklos@nik.uni-obuda.hu\
https://users.nik.uni-obuda.hu/siposm \
Óbudai Egyetem Neumann János Informatikai Kar\
Szoftvertervezés és -fejlesztés Intézet\
2020 - 2021 - 1 félév
