#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM stellirin/postgres-windows:latest AS prepare
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer
FROM stefanscherer/node-windows:latest AS nodejs 

# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
# Base port Sep-2-2020
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001
EXPOSE 5000

# dotnet Sept-04-2020
ENV DOTNET_USE_POLLING_FILE_WATCHER=true 
ENV NUGET_XMLDOC_MODE=skip
ENV POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetCoreSDK-NanoServer-1909
# In order to set system PATH, ContainerAdministrator must be used
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;C:\Program Files\powershell"
USER ContainerUser
COPY --from=installer ["/Program Files/dotnet", "/Program Files/dotnet"]
COPY --from=installer ["/Program Files/powershell", "/Program Files/powershell"]
# Trigger first run experience by running arbitrary cmd
RUN dotnet help
# end dotnet

# PostgreSQL 12.4 Sep-3-2020 
RUN mkdir "C:\\docker-entrypoint-initdb.d"
#### Copy over PostgreSQL
COPY --from=prepare /pgsql /pgsql
#### In order to set system PATH, ContainerAdministrator must be used
USER ContainerAdministrator
RUN setx /M PATH "C:\\pgsql\\bin;%PATH%"
USER ContainerUser
ENV PGDATA="C:\\pgsql\\data"
EXPOSE 5432
# Ending PostgreSQL

# PowerShell 12.4 Sep-3-2020 
RUN dotnet tool install --global PowerShell
# Ending PowerShell

# PostgreSQL 12.4 Sep-3-2020 
COPY --from=prepare docker-entrypoint.cmd /
SHELL ["pwsh", "-c"]
RUN (Get-Content -path C:\docker-entrypoint.cmd -Raw) -replace 'call :file_env POSTGRES_PASSWORD','call :file_env POSTGRES_PASSWORD admin' | Set-Content -Path C:\docker-entrypoint.cmd
RUN (Get-Content -path C:\docker-entrypoint.cmd -Raw) -replace 'call :file_env POSTGRES_DB !POSTGRES_USER!','call :file_env POSTGRES_DB FEBEPrototype' | Set-Content -Path C:\docker-entrypoint.cmd
SHELL ["CMD", "/S", "/C"]
# Ending PostgreSQL

# Node Sep-3-2020 
COPY --from=nodejs /nodejs /nodejs
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;C:\nodejs"
USER ContainerUser

# USER ContainerAdministrator
# RUN dotnet tool install --global PowerShell
# SHELL ["pwsh", "-c"]
# RUN (New-Object System.Net.WebClient).DownloadFile('https://nodejs.org/dist/v12.18.3/node-v12.18.3-x64.msi', 'C:\node.msi')
# SHELL ["cmd"]
# RUN msiexec.exe /q /i node.msi && timeout /t 300 /nobreak > NUL
# RUN del "C:\\node.msi"
# RUN setx /M PATH "%PATH%;C:\nodejs"
# USER ContainerUser

RUN npm -v
RUN node -v
# Ending Node

# Entity Framework Sep-2-2020
RUN dotnet tool install --global dotnet-ef
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;C:\Users\ContainerUser\.dotnet\tools"
USER ContainerUser
COPY . .
RUN dotnet restore "FEBEPrototype.Web.sln"
RUN dotnet ef migrations script -o "C:\\febe_migrations.sql"
SHELL ["pwsh", "-c"]
RUN (Get-Content -Path C:\febe_migrations.sql -Raw) -replace '^~', '' | Set-Content -Path C:\febe_migrations.sql
SHELL ["CMD", "/S", "/C"]
RUN (echo \c FEBEPrototype;) > "C:\\febe_migrations.sql.new"
RUN type "C:\\febe_migrations.sql" >> "C:\\febe_migrations.sql.new"
RUN move /y "C:\\febe_migrations.sql.new" "C:\\febe_migrations.sql"
# Ending Entity Framework

#increase to 8gb
# SHELL ["pwsh", "-c"]
# RUN set NODE_OPTIONS="--max-old-space-size=8192" 
# RUN (Get-Content -path .\ClientApp\package.json -Raw) -replace 'set NODE_OPTIONS=--max-old-space-size=4096','set NODE_OPTIONS=--max-old-space-size=8192' | Set-Content -Path .\ClientApp\package.json
# SHELL ["CMD", "/S", "/C"]
# RUN type .\ClientApp\package.json 
# RUN del /f/q/s .\ClientApp\node_modules > NUL
# RUN rmdir /q/s .\ClientApp\node_modules
RUN cd .\ClientApp && npm install 
RUN cd \app
RUN dotnet build "FEBEPrototype.Web.sln" 
RUN dotnet publish "FEBEPrototype.Web.sln"

FROM base AS final
WORKDIR /app
EXPOSE 5000
EXPOSE 5001 
EXPOSE 5432

# PostgreSQL 12.4 Sep-3-2020 
RUN move /y "C:\febe_migrations.sql" "C:\docker-entrypoint-initdb.d\febe_migrations.sql"
RUN C:\docker-entrypoint.cmd
# Ending PostgreSQL

ENTRYPOINT pg_ctl -U postgres -D C:\pgsql\data start && psql -U postgres -c "\l" && psql -U postgres -d FEBEPrototype -c "\d" && dotnet watch run
