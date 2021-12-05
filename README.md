# RoamlerLocationApp

## Technologies used in the project
- .NET Core 5.0 Web API
- xUnit

## Requirements

Make sure you have installed the following to run the project:
- .Net core 5.0
- Visual Studio 2019
or
- Docker


## Run the project

With Visual Studio 2019 you can run the Api Project, It will redirect you to Swagger UI. If it doesn't, you can use https://localhost:44328/swagger 
![Ekran Alıntısı2](https://user-images.githubusercontent.com/12534220/144768606-7743519a-cc3f-41b8-a7bf-943862a22be6.JPG)

With Docker, You can run create a docker container:
`docker build -t roamler .`

and run it:
`docker run -d -p 8080:80 roamler`

You can test it with postman
GET http://localhost:8080/Location?latitude=40&longitude=55&maxDistance=2000000&maxResults=25

![Ekran Alıntısı](https://user-images.githubusercontent.com/12534220/144768479-ad595819-6451-471c-84b3-69494d939dac.JPG)

## What could I add more if I had more time:

- I could use cache memory for locations or use Redis to save datas for faster results.
- I could create a basic UI.
