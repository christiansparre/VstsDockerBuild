# Building Docker images using Visual Studio Team Services
_and running unit- and integrationtests using docker-compose_

## The solution
The solution consist of multiple projects
* A WebApp project
* A Shared library project
* A "Service" project
* A project with a few empty unit tests
* And a project with a few integration test

## The repository contains
I wanted to explore how to setup a complete build pipeline in VSTS for building multi image solutions. The examples I have been able to find were all very simple, as "getting" started guides tend to be. This is ok, but I wanted to take it just a little bit further.

So here I have set up a more complete sample solution that

1. Builds multiple projects into docker images.
1. Runs a number of empty unit tests
1. Runs a few integration tests

These blog posts talks about the different parts of the sample

Post 1: https://medium.com/@christiansparre/building-a-multi-docker-image-solution-using-visual-studio-team-services-and-docker-compose-42fa196b6cd2

Post 2: https://medium.com/@christiansparre/running-your-unit-tests-with-visual-studio-team-services-and-docker-compose-3f82c9b95bf

I think the most interesting thing and one of the huge value propositions for docker, besides the general awesomeness, is how easy it actually is to setup integration tests of a complete solution. It does not involve deployment, it can easily run as part of your build pipeline and it can include everything from your own application to database servers etc.

Take a look
