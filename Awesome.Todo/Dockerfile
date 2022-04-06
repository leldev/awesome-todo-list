# docker build -t leldev/awesome.todo.publisher .
# docker run -p 8080:80 -d leldev/awesome.todo.publisher
# docker ps
# docker push leldev/awesome.todo.publisher

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Awesome.Todo.Api/*.csproj ./Awesome.Todo.Api/
COPY Awesome.Todo.Domain/*.csproj ./Awesome.Todo.Domain/

RUN dotnet restore 

# copy everything else and build app
COPY Awesome.Todo.Api/. ./Awesome.Todo.Api/
COPY Awesome.Todo.Domain/. ./Awesome.Todo.Domain/

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Awesome.Todo.Api.dll" ]