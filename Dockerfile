#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
#ARG NUGET_USERNAME=rizal.rumanda@ag-it.com
#ARG NUGET_PASSWORD=Agit1234


#ENV NUGET_USERNAME=${NUGET_USERNAME}
#ENV NUGET_PASSWORD=${NUGET_PASSWORD}

# Adds this source with basic authentication, other authentication types exist but I'm not sure if they are applicable here in Linux based container
#RUN dotnet nuget add source https://nuget.telerik.com/nuget --name="Telerik Private Nuget" --username ${NUGET_USERNAME} --valid-authentication-types basic --store-password-in-clear-text --password ${NUGET_PASSWORD}

COPY ["./Fish.Export/Fish.Application/Fish.Application.csproj", "Fish.Application/"]
COPY ["./Fish.Export/Fish.Entity/Fish.Infrastructure.csproj", "Fish.Infrastructure/"]
COPY ["./Fish.Export/Fish.Export.Core/Fish.Export.csproj", "Fish.Export.Core/"]
#COPY . .
RUN dotnet nuget disable source "nuget.org"

# Just to see if two lines above work
RUN dotnet nuget list source

RUN dotnet restore ./Fish.Export.Core/Fish.Export.csproj

COPY . .
WORKDIR " /Fish.Export/Fish.Export.Core"
RUN dotnet build "Fish.Export.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fish.Export.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Fish.Export.dll"]
