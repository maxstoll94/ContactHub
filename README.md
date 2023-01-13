# Contacter

Welcome to the Contactor. A simple web application for managing your contacts.

## Setup

1. Setup a new database server on Docker using the `setup-db-server` command.
2. Wait until the server is completely started, this could take ~30 seconds. You can run `docker container logs localsql` to see the logs.
3. Setup a database using `setup-db` commands.
2. To run the application run `dotnet run` in `src/Contacter.Web`.

## Design

Here is an example of the original intended functionality. The red part indicates functionality that is
already implemented in the backend.

![CRM Design - Page 1](https://user-images.githubusercontent.com/14106031/212358135-3b4ce901-bdb7-4764-8bdc-bf5f5e318b8e.png)
