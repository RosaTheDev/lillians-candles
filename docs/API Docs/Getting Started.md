## Lillian's Candles - API Development Documentation

### Getting Started 
![Alt Text](https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExMTU1cm1ydWlwZnVsZ3BuY2FlbmpiYXdmbDR4bjdpemE0bXpqOXp2byZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/Yy6GhtIk8l76u8nlIF/giphy.gif)

#### Stage 1: API Development

To set up and run this project, follow these steps:

[ ] Clone the Repository

`git clone git@github.com:RosaTheDev/lillians-candles.git`

`cd lillians-candles`

[ ] Navigate to the Backend API

`cd backend/LilliansCandles.Api`

[ ] Build the Project

`dotnet build`

[ ] Run the API

`dotnet run`

[ ] Access Swagger UI

Once the API is running, the terminal will display a message similar to:

`Now listening on: http://localhost:5212`

Click the provided localhost link.

When redirected, manually add /swagger to the URL:

`http://localhost:5212/swagger`

This will open the Swagger UI, allowing you to interact with the API.

### Project Overview

What Has Been Implemented?

[✅] API Setup: Built an API with an initial small list of candles.

[✅] Swagger Integration: Used Swagger to visualize the API contract, making it the point of truth for API interactions.

[✅] Candle Model: Created a CandleModel as a blueprint for candle objects, defining their structure.

[✅] Candle Controller: Set up HTTP routes in CandleController.cs to handle API requests.

### Next Steps

Implement API Testing with xUnit & RestSharp.

Expand the API to include more endpoints (e.g., POST, PUT, DELETE).

Integrate database storage for candle inventory.

This documentation will continue to evolve as we build out the project. 🚀

