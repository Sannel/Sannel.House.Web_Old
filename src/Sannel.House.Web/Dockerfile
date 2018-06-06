FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY .nuget src/
COPY src/Sannel.House.Web/Sannel.House.Web.csproj src/Sannel.House.Web/
COPY src/Sannel.House.Web.Models/Sannel.House.Web.Models.csproj src/Sannel.House.Web.Models/
COPY src/Sannel.House.Web.Interfaces/Sannel.House.Web.Interfaces.csproj src/Sannel.House.Web.Interfaces/
RUN dotnet restore src/Sannel.House.Web/Sannel.House.Web.csproj
COPY . .
WORKDIR /src/src/Sannel.House.Web
RUN dotnet build Sannel.House.Web.csproj -c Release -o /app


FROM build AS testrunner
WORKDIR /src/src/Sannel.House.Web.Tests
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS test
WORKDIR /src/src/Sannel.House.Web.Tests
RUN dotnet test

FROM build AS publish
RUN dotnet publish Sannel.House.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sannel.House.Web.dll"]
