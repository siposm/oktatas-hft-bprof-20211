## Általános információk
Az ÓE NIK Üzemmérnök-informatikus (BPROF) képzésen található **Haladó Fejlesztési Technikák** tárgyhoz tartozó laboranyagok (csak a saját részeim).

<br><br>

## Mappaszerkezet magyarázó
- **01-WEBAPI**
    - `jsonHandler`
        - végpontról való letöltés (WebClient)
        - JSON állományok kezelése (Newtonsoft JSON.NET serlialize / deserialize)
    - `nancyWebApi` 
        - saját API-k létrehozása Nancy segítségével
    - `consoleClientNancy`
        - console kliens ami a Nancy-ben létrehozott API végpontot használja
- **02-PROCESS**
    - `README.md`
        - link egy mérnökinfós régi repóra, ahol különböző mintapéldák vannak
- **03-THREAD**
    - `01-basics`
        - alapvető thread szintaktika és műveletek bemutatása
    - `02-textdata-processing`
        - txt szöveges állomány feldolgozása párhuzamosan
        - szinkronizációs pont használata
    - `03-webstat`
        - weboldal letöltés sebességének mérése thread segítségével
        - szinkronizációs pont használata
    - `04-lock`
        - lock-olás bemutatása egy rövid mintakódon keresztül
    - `05-interlocked`
        - interlock-olás bemutatása egy rövid mintakódon keresztül
- **04-TASK**
     - `01-basics`
        - alapvető task szintaktika és műveletek bemutatása
    - `02-rss-reader`
        - rss állományok letöltése és feldolgozása task segítségével
        - process felhasználásával firefox indítása az RSS-ben található link megnyitására
        - cancellation alkalmazása token segítségével
    - `03-cancellation-demo`
        - task cancellation rövid példakód
- **05-ASYNC-AWAIT**
    - `root`
        - async-await működést szemléltető példakód

<br><br>

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

<br><br>

## CLI parancsok
- `dotnet new web`
- `dotnet new console`
- `dotnet add package Nancy --version 2.0.0`
- `dotnet add package Microsoft.AspNetCore.Owin`
- `dotnet add package Microsoft.AspNetCore.Server.Kestrel`
- `dotnet add package Newtonsoft.Json`
- `dotnet restore`

<br><br>

## Hasznos linkek
- A tárgyhoz tartozó oktatói aloldalam: https://users.nik.uni-obuda.hu/siposm/hft-bprof
- YouTube csatorna, ahol a gyakorlati videók publikálásra kerülnek: https://www.youtube.com/siposm

<br><br>

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
