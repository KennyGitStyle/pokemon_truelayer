On first Commit:

Its good practice to create objects with an ID property for identification purposes. Especially if you are going to be using a database. In this case we will be using a database to store our pokemon, with this we will be storing our connection string in development settings as a form of abstraction. Then we will configure our pipeline to accept both our development and production database.

On Second Commit:

Added Interface and implementation (not yet completed)

Added Database Connection string and created context - This is located in the Extension folder

On third Commit:

Added a code first migration.

On forth Commit:

Added a method to seed the database

On Fifth Commit:

Docker configuration added, and Swagger configured data seeded.

to get the file perform a git clone via the url, and cd into the Pokemon.API folder and enter dotnet watch run or dotnet  in the command line, it should run in development. 

Copy the url from the console environment, if it has not opened. Enter the primary key "ch" and you should have your pokemon.