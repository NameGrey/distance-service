# Intro
The current repo is a testing task. Please read the info about the launch and project structure below.

# Launch
## Prerequisites:
1. Install Docker Desktop and make required settings - [link](https://www.docker.com/products/docker-desktop)
2. Install .NET 6 - [link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
3. Fetch sources from the repository

## Launch from Visual Studio
1. Be sure you have C# 10 supported
2. Be sure you have Docker tools for Visual Studio
3. Open CTeleport solution
4. Choose "Docker" configuration to start the application

# Project structure
<b>src</b>
- <b>Services</b> (All solution services go there)
  - <b>Distance</b> (distance service projects)
    - <b>Distance.API</b>      (all API related logic goes there)
    - <b>Distance.Business</b> (Business logic)
    - <b>Distance.Client</b>   (All services should have client projects for easy communication and testing)
    - <b>Distance.Domain</b>   (Domain models)
  - <b>Places</b>
    - <b>Places.Client</b>     (Places service client despite we do not have its code )

<b>tests</b> 
 - <b>Services</b> (Place for folders with integration/functional tests for different services)
   - <b>Distance</b> (Tests for Distance service)
     - <b>Distance.IntegrationTests</b> (Integration Tests for Distance service)


# Next steps
The service can fully function in the current condition, but there can be made other improvements:
1. Add Logging
2. Use distributed cache
3. Add Polly Caching Policy with Distributed cache
4. Use kubernetes in order to improve resilience of the service
5. Use NSwag in order to generate Services Clients code using Open API documentation
