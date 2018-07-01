FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
#Don't expose the port (that is handled by Heroku)
#EXPOSE 80  
#EXPOSE 443

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY web.csproj web/
RUN dotnet restore web/web.csproj
COPY . ./web
WORKDIR /src/web
RUN dotnet build web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "web.dll"]

# Must specify CMD for heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet web.dll   

#FROM microsoft/aspnetcore
#WORKDIR /app
#COPY . .
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet web.dll