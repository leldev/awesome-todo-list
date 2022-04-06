# docker build -t leldev/awesome.todo.publisher .
# docker run -p 8080:80 -d leldev/awesome.todo.publisher
# docker ps
# docker push leldev/awesome.todo.publisher

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Awesome.Todo.Api.dll" ]