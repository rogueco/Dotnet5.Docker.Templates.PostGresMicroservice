## Whats the purpose
Essentially, I'm going to put together a collection of small Docker contained Microservices for a reference or quickstart guide

![image](https://user-images.githubusercontent.com/38529232/121787722-bcb36e80-cbbf-11eb-8ec7-fe0bc399b21c.png)


## Run Project
Just run from the root directory & the applicaiton will build

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```


## Database Connection
To look at the database you can use the following connections (Please note that you'll need to have the image running to connect)

```bash
Username: admin
Password: admin1234
Port: 5432
```


### Docker Image

If you don't want to pull down a PostGRES SQL database, you can just copy the following to create a docker image

```bash
docker run --name some-postgres -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin1234 -p 5432:5432 -d postgres:latest
```

These credentials will give you access to the DB

## Add Migration

Navigate to the base of the solution

```bash
dotnet-ef migrations add MigrationName
```

## Update Database

Any migration that are pending are handled automatically by the process in `Program.cs`

```c#
var context = services.GetRequiredService<DataContext>();
await context.Database.MigrateAsync();
await TodoSeedDataContext.SeedData(context);
```
