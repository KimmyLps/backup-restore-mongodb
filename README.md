# Backup and restore database

## Backup the data

- ### Script to backup data
```bash
docker exec -i <container name> /usr/bin/mongodump --uri="<URL of mongodb>" --archive=/<directory>/<file name>.gz --gzip
```

- ### Example script to backup data
```bash
docker exec -i example-mongodb /usr/bin/mongodump --uri="mongodb://root:123456@example-mongodb:27017" --archive=/backup-mongo/backup-mongo.gz --gzip
```

- ### explain the script code
    > In this section, the script, when called, will execute into a container named `example-mongodb` (This must match the container name in docker-compose.mongo.yml that we have built) 
    - and use the command mongodump with uri `mongodb://root:123456@example-mongodb:27017`
    - `root`: `MONGO_INITDB_ROOT_USERNAME` in docker-compose.mongo.yml
    - `123456`: is `MONGO_INITDB_ROOT_PASSWORD` in docker-compose.mongo.yml
    - `example-mongodb`: is the service name in docker-compose.mongo.yml
    - `/backup-mongo`: At the end is the directory where the files we want to backup.

- ### Let's open up another terminal and use the command cd into our project, then use the command.

```bash
sh backup.sh
```


## Restore the data

- ### Script to restore data
```bash
docker exec -i <container name> /usr/bin/mongorestore --uri="<URL of mongodb>" --drop --archive=/<directory>/<file name>.gz --gzip
```

- ### Example script to restore data
```bash
docker exec -i example-mongodb /usr/bin/mongorestore --uri="mongodb://root:123456@example-mongodb:27017/?authSource=admin" --drop --archive=/backup-mongo/backup-mongo.gz --gzip
```

- ### explain the script code
    > In this section, the script, when called, will execute into a container named `example-mongodb` (This must match the container name in docker-compose.mongo.yml that we have built) 
    - and use the command mongodump with uri `mongodb://root:123456@example-mongodb:27017`
    - `root`: `MONGO_INITDB_ROOT_USERNAME` in docker-compose.mongo.yml
    - `123456`: is `MONGO_INITDB_ROOT_PASSWORD` in docker-compose.mongo.yml
    - `example-mongodb`: is the service name in docker-compose.mongo.yml
    - `/backup-mongo`: At the end is the directory where the files we want to backup.

- ### Let's open up another terminal and use the command cd into our project, then use the command.

```bash
sh restore.sh
```