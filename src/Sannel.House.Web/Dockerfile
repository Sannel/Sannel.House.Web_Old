FROM microsoft/aspnetcore:2.0.5-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/aspnetcore-build:2.0.5-2.1.4 AS build
WORKDIR /src
COPY *.sln ./
COPY .nuget/ ./
COPY src/Sannel.House.Web/Sannel.House.Web.csproj src/Sannel.House.Web/
COPY src/Sannel.House.Web.Data/Sannel.House.Web.Data.csproj src/Sannel.House.Web.Data/
COPY src/Sannel.House.Web.Base/Sannel.House.Web.Base.csproj src/Sannel.House.Web.Base/
COPY src/Sannel.House.Web.Data.SqlServer/Sannel.House.Web.Data.SqlServer.csproj src/Sannel.House.Web.Data.SqlServer/
COPY src/Sannel.House.Web.Data.Sqlite/Sannel.House.Web.Data.Sqlite.csproj src/Sannel.House.Web.Data.Sqlite/
RUN dotnet restore
COPY . .
WORKDIR /src/src/Sannel.House.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app
COPY /src/Sannel.House.Web/ssl.pfx /app/

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sannel.House.Web.dll"]
