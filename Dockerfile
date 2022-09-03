#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build
WORKDIR /source
#Copy things from the actual folder to working directory
COPY . . 
RUN dotnet restore "./JWTAuthentication/JWTAuthentication.csproj" --disable-parallel
RUN dotnet publish "./JWTAuthentication/JWTAuthentication.csproj" -c release -o /app --no-restore


#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal 
WORKDIR /app 
#Copy from build stage to the app folde rof this stage
COPY --from=build /app ./
EXPOSE 5000
#ENTRYPOINT ["dotnet","JWTAuthentication.dll"]
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet JWTAuthentication.dll