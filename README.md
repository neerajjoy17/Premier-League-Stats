Premier League Stats ⚽
====================

A full-stack web application for exploring English Premier League data.
This project focuses on collecting, structuring, and presenting football statistics in a clear and meaningful way.

I built this project mainly for learning purposes, with a strong focus on backend development, data modeling,
and understanding how everything works behind the scenes. The UI is intentionally simple — functionality and
correctness were the priority.

📦 Technologies
------------

- .NET (C#)
- ASP.NET Core
- Entity Framework Core
- SQL Database
- HTML
- CSS
- JavaScript
- Docker

🦄 Features
--------

Here's what you can do with Premier League Stats:

League Data  
View Premier League information including teams, matches, and overall league structure.

Team Statistics  
Explore team-level performance data across matches and seasons.

Player Statistics  
View player information such as appearances, goals, and other key metrics.

Backend API  
All data is exposed through clean and structured API endpoints.

Database Integration  
Football data is stored using Entity Framework Core with clear relationships between teams, players, and matches.

Docker Support  
The project includes Docker configuration for easy setup and consistent execution across environments.

👩🏽‍🍳 The Process
-----------

I started by designing the database schema to represent real-world football data accurately.
This required carefully thinking through how teams, players, matches, and statistics relate to each other.

Once the data models were ready, I built the backend using ASP.NET Core.
I focused on creating clean API endpoints that return structured and meaningful data.

After that, I connected the backend to a simple frontend using HTML, CSS, and JavaScript.
The goal here wasn’t advanced styling, but making sure the data flowed correctly from the database to the UI.

To make the project easier to run and deploy, I added Docker support.
This helped me understand how applications can be packaged and run consistently across different environments.

Throughout the project, I regularly refactored the code and reviewed my implementation
to make sure I truly understood what I was building.

📚 What I Learned
--------------

During this project, I gained a stronger understanding of backend systems
and working with structured, real-world data.

Backend Architecture  
I learned how to structure an ASP.NET Core application using controllers, services, and a data layer.

Database Design  
Modeling football data improved my ability to design relational schemas and manage entity relationships.

API Design  
I gained experience creating RESTful endpoints and returning well-structured responses.

Docker Fundamentals  
Adding Docker helped me understand containerization and environment-agnostic deployments.

Working With Real Data  
Handling sports statistics required careful thinking about accuracy, consistency, and edge cases.

💭 How Can It Be Improved?
-----------------------

- Add charts and visualizations for statistics and trends
- Make the UI fully responsive
- Add advanced filtering and sorting
- Improve performance with caching
- Add authentication and personalization
- Document the API using Swagger / OpenAPI

🚦 Running the Project
-------------------

To run the project in your local environment, follow these steps:

Clone the repository
```bash
git clone https://github.com/neerajjoy17/Premier-League-Stats.git
cd Premier-League-Stats
dotnet restore
dotnet ef database update
dotnet run
```
Open the application in your browser using the URL shown in the console, usually:
```
https://localhost:5001
```

🍿 Video
-----------------------
Here is a short demo showing the main features of the application:


