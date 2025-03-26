# Etapa 1: Build da aplicaçãoo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out ./

# Expõe a porta padrão da aplicação
EXPOSE 80
EXPOSE 443

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "EmprestimoLivros.dll"]