# Contact Hub

Welcome to the Contact Hub. A simple web application for managing your contacts:

![image](https://user-images.githubusercontent.com/14106031/212625987-9e46170f-6adc-4c8a-9dff-fabbc6dbb253.png)

## Setup

1. Setup a new database server on Docker using the `setup-db-server` command.
2. Wait until the server is completely started, this could take ~30 seconds. You can run `docker container logs localsql` to see the logs.
3. Setup a database using `setup-db` commands.
2. To run the application run `dotnet run` in `src/ContactHub.Web`.

## Design

Here is an example of the original intended functionality. The red part indicates functionality that is
already implemented in the backend.

![CRM Design - Page 1](https://user-images.githubusercontent.com/14106031/212358135-3b4ce901-bdb7-4764-8bdc-bf5f5e318b8e.png)

## Hosting
This project is publically hosted on Azure:
![image](https://user-images.githubusercontent.com/14106031/212625441-f68c6d42-7de1-432a-8d09-a535d7bab6db.png)

You can access it via the following URL: https://contacthub-web.azurewebsites.net
