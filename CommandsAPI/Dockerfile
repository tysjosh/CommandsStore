#Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

#Copy the project file and build our release
COPY . ./
RUN dotnet publish -c Release -o out

#Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CommandsAPI.dll"]