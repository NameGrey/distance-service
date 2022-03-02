# Intro
The current repo is a testing task. Please read the info about the launch and project structure below. 

## !ATTENTION
This project is just PoC and there should be made other improvements in real project which depend a lot on the context.

The task description is the following:

<i>Build a REST service to measure distance in miles between two airports. Airports are identified by 3-letter IATA code.

Sample call to get airport details:
GET https://places-dev.company.com/airports/AMS HTTP/1.1

It's allowed to use any 3-rd party components/frameworks.
Solution has to be based on dotnet core 5+
</i>

# Launch
## Prerequisites:
1. Install Docker Desktop and make required settings - [link](https://www.docker.com/products/docker-desktop)
2. Install .NET 6 - [link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
3. Fetch sources from the repository

## Launch from Visual Studio
1. Be sure you have C# 10 supported
2. Be sure you have Docker tools for Visual Studio
3. Open SomeCompany solution
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
2. Add exceptions handling and return more specific codes in case of errors (now everything is 500)
3. Improve Polly policies for retries
4. Use distributed cache
5. Add Polly Caching Policy with Distributed cache
6. Use kubernetes in order to improve resilience of the service
7. Use NSwag in order to generate Services Clients code using Open API documentation7. 
