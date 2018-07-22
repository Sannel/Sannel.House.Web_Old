#   Copyright 2018 Sannel Software, L.L.C.
#   Licensed under the Apache License, Version 2.0 (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#       http://www.apache.org/licenses/LICENSE-2.0
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58792
EXPOSE 44346

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Sannel.House.Web.Users/Sannel.House.Web.Users.csproj Sannel.House.Web.Users/
COPY Sannel.House.Web.Users.Data/Sannel.House.Web.Users.Data.csproj Sannel.House.Web.Users.Data/
COPY Sannel.House.Web.Users.Data.SqlServer/Sannel.House.Web.Users.Data.SqlServer.csproj Sannel.House.Web.Users.Data.SqlServer/
COPY Sannel.House.Web.Users.Data.Sqlite/Sannel.House.Web.Users.Data.Sqlite.csproj Sannel.House.Web.Users.Data.Sqlite/
RUN dotnet restore Sannel.House.Web.Users/Sannel.House.Web.Users.csproj
COPY . .
WORKDIR /src/Sannel.House.Web.Users
RUN dotnet build Sannel.House.Web.Users.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Sannel.House.Web.Users.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sannel.House.Web.Users.dll"]
