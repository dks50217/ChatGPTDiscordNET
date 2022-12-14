FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChatGPTBot/ChatGPTBot.csproj", "ChatGPTBot/"]
RUN dotnet restore "ChatGPTBot/ChatGPTBot.csproj"
COPY . .
WORKDIR "/src/ChatGPTBot"
RUN dotnet build "ChatGPTBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatGPTBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatGPTBot.dll"]
