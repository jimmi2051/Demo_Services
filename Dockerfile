FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Demo_Services.csproj", "./"]
RUN dotnet restore "./Demo_Services.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Demo_Services.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Demo_Services.csproj" -c Release -o /app

FROM base AS final
LABEL deftnt="deftnt"
ENV ASPNETCORE_ENVIRONMENT development
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Demo_Services.dll"]
