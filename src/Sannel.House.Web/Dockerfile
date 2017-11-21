FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 443 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Sannel.House.Web.dll"]
