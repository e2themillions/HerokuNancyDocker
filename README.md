# Heroku + Nancy + Docker + React + Redux

An adjusted version of the Visual Studio template project for __Microsoft .NET Core 2.0 solution with React + Redux__ that is ready for deployment directly to __Heroku__ using Heroku's container deployment with a __Docker container__. Also, the server-side ASP.NET MVC stuff has been replaced with the __Nancy__ framework. Nancy has then been configured to support the sample __React + Redux__ client-side single page app (SPA) to conform to Nancy's super-duper-happy-path! :)

# The Heroku 2-step approach to deploy your Nancy app to Heroku.
To build, package and deploy your app, simply execute the two following commands in a command shell (or other terminal like bash etc.)

     1: heroku container:push web -a <heroku_app_name>
     2: heroku container:release web -a <heroku_app_name>
  
The "-a <heroku_app_name>" argument, is because the solution is prepared for more than one application (in other words, the subdirectory holding the "web"-project belongs to the solution's git repository.

The first step builds and publishes your app (i.e. like dotnet publish -c Release), builds the Docker container (based on the web/Dockerfile) and pushes the docker container to Heroku's repository. The second command releases the docker container, in effect deploying it and restarting the Heroku dyno.

# Requirements.
To be able to get that far, you will need to have (at least) the following installed:
   - .Net Core 2.0 SDK
   - Docker for windows / linux (and enabled virtualization support in bios etc.)
   - Git
   - Heroku CLI / Toolbelt