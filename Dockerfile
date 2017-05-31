FROM microsoft/dotnet
WORKDIR /opt/IntegracionBancaria

COPY IntegracionBancaria/ ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/IntegracionBancaria.dll"]

