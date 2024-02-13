#!/bin/bash

# drops existing database
yes | dotnet ef database drop --startup-project Librista.Api/ --project Librista.Data/

# removes existing migration
dotnet ef migrations remove --startup-project Librista.Api/ --project Librista.Data/

# adds new migration
echo "enter the name of the migration: "
read migration_name
dotnet ef migrations add "$migration_name" --startup-project Librista.Api/ --project Librista.Data/

# updates database
dotnet ef database update --startup-project Librista.Api/ --project Librista.Data/