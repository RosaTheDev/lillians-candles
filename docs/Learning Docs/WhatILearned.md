# 📌 What I Picked Up While Setting Up a C# Project / API

## 1️⃣ How to Add Swagger (UI) to Visualize and Interact with the API Contract

### 🔹 What is Swagger?

Swagger (also called OpenAPI) is a tool that automatically generates API documentation from our C# code.

✅ It allows developers and testers to see all API endpoints, their parameters, and responses in a web UI.

✅ It provides an interactive API testing tool (so we don’t need Postman).

### 🔹 How Did We Add Swagger?

We enabled it in Program.cs by adding:

```
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```
And then activated the Swagger UI:

```
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```
Now, when we run the API (dotnet run) and go to:

```
http://localhost:5212/swagger
```

We can see all API routes and test them directly! 🚀

## 2️⃣ The Importance of Defining an API Contract Before Writing Business Logic

### 🔹 What is an API Contract?

An API contract defines what the API should do before we write any code. It helps: 

✔ Ensure the frontend and backend agree on data structures.

✔ Prevent confusion when adding new features.

✔ Avoid breaking changes later.

### 🔹 How Did We Define Our API Contract?

#### 1️⃣ We used Swagger to document endpoints before writing full logic.

#### 2️⃣ We created the Candle model to define the structure of candle data:
```
public class Candle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Scent { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
```

#### 3️⃣ We built CandlesController.cs to define API routes before adding database logic.

## 3️⃣ How Program.cs is Used to Configure Middleware, Services, and Routing

### 🔹 What is Program.cs?

Program.cs is the entry point of our .NET API. It sets up: ✅ 
Middleware (like Swagger & logging).

✅ Services (like dependency injection).

✅ Routing (so our controllers work).

### 🔹 Key Sections in Program.cs

Adding Controllers

```
builder.Services.AddControllers();
```

Enabling Swagger

```
builder.Services.AddSwaggerGen();
```

Setting Up Routing

```
app.MapControllers();
```

If we don’t register controllers in Program.cs, the API won’t work!

## 4️⃣ How to Structure a .NET API Project with Controllers, Models, and Documentation

### 🔹 Folder Structure We Used

```
backend/
│── LilliansCandles.Api/
│   ├── Controllers/   # API Logic (CandlesController.cs)
│   ├── Models/        # Data Definitions (Candle.cs)
│   ├── Program.cs     # API Configuration
│   ├── appsettings.json  # Environment Config
│   ├── .gitignore     # Ignored Files
│── docs/              # Documentation (API Setup, Learnings)
│── README.md          # Project Overview
```

### 🔹 Why? This structure keeps the API clean and scalable.

## 5️⃣ How to Use .gitignore to Exclude Unnecessary Files

### 🔹 What Does .gitignore Do?

✔ It prevents unnecessary files from being pushed to GitHub.

✔ Helps keep the repo clean and lightweight.

### 🔹 What Did We Ignore?

✅ Build files:

```
bin/
obj/
```

✅ NuGet packages:

```
*.nuget.*
project.assets.json
```

✅ IDE settings:

```
.vscode/
.idea/
```

This ensures that only the necessary code is tracked.

# 📌 Controllers & Models

6️⃣ How to Create a Candle Model to Define the Data Structure for API Responses

🔹 What is a Model?

A model is a blueprint for our data. In our case, the Candle model represents how candle data is structured.

🔹 What Did We Do?

We created Models/Candle.cs:

```
public class Candle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Scent { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
```

✔ This model ensures that every candle object follows the same structure.

7️⃣ How to Use public ActionResult<T> vs. public async Task<IActionResult>

🔹 ActionResult<T> is used for simple responses.

🔹 Task<IActionResult> is used for async operations (like database calls).

🔹 Example: Synchronous vs. Asynchronous

Synchronous (Simple, No Database)

```
[HttpGet("{id}")]
public ActionResult<Candle> GetCandleById(int id)
{
    return new Candle(id, "Lavender Bliss", "Lavender", 14.99m, 3);
}
```

Asynchronous (Future Database Call)

```
[HttpGet("{id}")]
public async Task<IActionResult> GetCandleById(int id)
{
    var candle = await _dbContext.Candles.FindAsync(id);
    return candle == null ? NotFound() : Ok(candle);
}
```

🔹 In the future, when we add a database, we’ll need to use async (Task<IActionResult>).

📌 Swagger & API Documentation

8️⃣ How Swagger (OpenAPI) Helps Document and Test APIs Easily

✔ Automatically documents API endpoints.

✔ Provides a UI for testing API calls.

🛠 We enabled Swagger by adding this to Program.cs:
```
builder.Services.AddSwaggerGen();
app.UseSwagger();
app.UseSwaggerUI();
```

9️⃣ How NSwag Can Generate TypeScript API Clients

NSwag is a tool that:

✅ Automatically generates TypeScript models for API responses.

✅ Creates TypeScript clients so frontend code can call the API easily.

🛠 We installed NSwag:
```
dotnet add package NSwag.AspNetCore
```
Now, we can generate a TypeScript client from our API!

📌 Git & Documentation

🔟 How to Properly Structure Project Documentation

We created: 

✅ README.md → Quick project setup guide.

✅ docs/API_Setup.md → Detailed API documentation.

✅ docs/What_I_Learned.md → Personal notes on what I learned.

✔ This helps track progress and makes onboarding easier.

1️⃣1️⃣ The Value of Writing What I Learn

🔹 Writing what I learn helps me: 

✅ Reinforce my knowledge.

✅ Quickly reference back when needed.

✅ Share information with teammates.

