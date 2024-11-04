# NATOUR API WITH .NET

## Run mongosh with credentials inside docker
bash
```
docker exec -it natour mongosh -u root -p 123 --authenticationDatabase admin
```

### Check user in mongosh
bash 
```
show dbs

use admin

db.getUsers()
```

## Run bash inside docker
bash 
```
docker exec -it mongo-container bash
```

## Run MongoShell Without Credentials in docker
bash
```
docker exec -it natour mongosh
```

## Shutdown docker
bash
```
docker-compose down -v
```

## Start docker compose
bash
```
docker compose up -d
```

