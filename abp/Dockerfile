#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["common.props","."]
COPY ["src/Wallee.Boc.DataPlane.Web/Wallee.Boc.DataPlane.Web.csproj", "src/Wallee.Boc.DataPlane.Web/"]
COPY ["src/Wallee.Boc.DataPlane.Application/Wallee.Boc.DataPlane.Application.csproj", "src/Wallee.Boc.DataPlane.Application/"]
COPY ["src/Wallee.Boc.DataPlane.Domain/Wallee.Boc.DataPlane.Domain.csproj", "src/Wallee.Boc.DataPlane.Domain/"]
COPY ["src/Wallee.Boc.DataPlane.Domain.Shared/Wallee.Boc.DataPlane.Domain.Shared.csproj", "src/Wallee.Boc.DataPlane.Domain.Shared/"]
COPY ["src/Wallee.Boc.DataPlane.Application.Contracts/Wallee.Boc.DataPlane.Application.Contracts.csproj", "src/Wallee.Boc.DataPlane.Application.Contracts/"]
COPY ["src/Wallee.Boc.DataPlane.Background/Wallee.Boc.DataPlane.Background.csproj", "src/Wallee.Boc.DataPlane.Background/"]
COPY ["src/Wallee.Boc.DataPlane.EntityFrameworkCore/Wallee.Boc.DataPlane.EntityFrameworkCore.csproj", "src/Wallee.Boc.DataPlane.EntityFrameworkCore/"]
COPY ["src/Wallee.Boc.DataPlane.HttpApi/Wallee.Boc.DataPlane.HttpApi.csproj", "src/Wallee.Boc.DataPlane.HttpApi/"]
COPY ["src/Wallee.Boc.DataPlane.Minio/Wallee.Boc.DataPlane.Minio.csproj", "src/Wallee.Boc.DataPlane.Minio/"]
RUN dotnet restore "src/Wallee.Boc.DataPlane.Web/Wallee.Boc.DataPlane.Web.csproj"
COPY . .
WORKDIR "/src/src/Wallee.Boc.DataPlane.Web"
RUN dotnet build "Wallee.Boc.DataPlane.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wallee.Boc.DataPlane.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo 'Asia/Shanghai' >/etc/timezone
ENTRYPOINT ["dotnet", "Wallee.Boc.DataPlane.Web.dll"]