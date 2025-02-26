# 📝 Testing Documentation

## 📌 Overview

This project implements API testing for the Lillian’s Candles backend, ensuring the reliability and accuracy of our endpoints. We utilize a combination of xUnit, RestSharp, Fluent Assertions, and Allure to build a robust testing framework.

### 🛠 Frameworks & Tools Used

#### 1️⃣ xUnit (Test Framework)
Why xUnit?

xUnit is a widely used unit testing framework for .NET, providing lightweight and extensible test capabilities.

Pros:

- Built-in support for dependency injection.
Parallel test execution by default.

- Highly customizable through attributes like ```[Fact]```, ```[Theory]```, and ```[Trait]```.

Cons:

- Lacks built-in support for mocking (requires third-party libraries).

- May require additional setup for integration tests.

#### 2️⃣ RestSharp (API Testing Client)

Why RestSharp?

RestSharp simplifies HTTP client interactions for testing REST APIs.

Pros:

- Provides fluent syntax for making API requests.

- Supports async/await for non-blocking API calls.

- Easy serialization and deserialization of JSON.

Cons:

- No built-in assertions, requiring another assertion library (like Fluent Assertions).

- Some advanced HTTP features may require additional configuration.

#### 3️⃣ Fluent Assertions (Assertion Library)

Why Fluent Assertions?

This library enhances readability and debugging by allowing human-readable test assertions.

Pros:

- Clear and expressive syntax (e.g., response.StatusCode.Should().Be(HttpStatusCode.OK);).

- Supports rich comparisons (e.g., deep object equality, exception assertions).

Cons:

- Commercial licensing restrictions for business use.
- Can introduce breaking changes in updates.

#### 4️⃣ Allure (Test Reporting)

Why Allure?

Allure provides rich visual test reports with detailed step execution logs.

Pros:

- Generates interactive, structured test reports.

- Supports step-based test execution visualization.

- Works well with xUnit and RestSharp.

Cons:

- Requires additional setup to integrate with xUnit.

- Patching issues with HarmonyLib in .NET 9.0 (causes warnings).

### ⚙️ Setting Up Testing

#### 1️⃣ Installing Dependencies

To install the necessary testing packages, use:

```
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package RestSharp
dotnet add package FluentAssertions
dotnet add package Allure.Xunit
```

Then, restore dependencies:

```
dotnet restore
```

#### 2️⃣ Writing Tests

Example API test using RestSharp, xUnit, Fluent Assertions, and Allure:

```
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Xunit;
using FluentAssertions;
using Allure.Xunit.Attributes;
using Allure.Net.Commons;

namespace LilliansCandles.Tests
{
    [AllureParentSuite("Lillian's Candles API Testing")]
    public class ApiTests
    {
        private readonly RestClient _client = new RestClient("http://localhost:5124/api");

        [Fact(DisplayName = "GET /api/candles returns HTTP 200")]
        [AllureFeature("Get All Candles")]
        [AllureDescription("Verifies that the Get Candles endpoint returns a valid response.")]
        public async Task Get_Candles_ShouldReturn200()
        {
            // Arrange
            RestRequest request = new RestRequest("/candles", Method.Get);

            // Act
            RestResponse response = await _client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
    }
}
````
### 🚀 Running Tests

#### 1️⃣ Standard Test Execution
Run all tests:

```dotnet test```

Generate a detailed test report with Allure:

```dotnet test --logger:trx```

### 🐛 Troubleshooting & Issues Encountered

#### 1️⃣ Fluent Assertions License Warning

Error Message:

```
The component "Fluent Assertions" is governed by the rules defined in the Xceed License Agreement.
Solution:
```

Can be ignored for non-commercial use.

Consider replacing Fluent Assertions with xUnit’s built-in assertions.

#### 2️⃣ Allure.Xunit & HarmonyLib Incompatibility with .NET 9
Error Message:

```
Unable to patch XunitTestRunner's Void .ctor(...): System.MemberAccessException.
Issue:

Allure.Xunit uses HarmonyLib, which is not fully compatible with .NET 9.0.
Tests still pass, but Allure reports may be incomplete.
```

Solution Attempts: 

✅ Tried setting:
```
export ALLURE_PATCH_XUNIT=false
```
✅ Added:

```
Environment.SetEnvironmentVariable("ALLURE_PATCH_XUNIT", "false");
```
🚨 None of these fully resolved the issue, so we’re ignoring the warning for now.

## 📌 Summary

What We Accomplished

✅ Set up xUnit, RestSharp, Fluent Assertions, and Allure for API testing.

✅ Wrote test cases to validate API responses.

✅ Integrated Allure for reporting, despite warnings.

✅ Documented known issues with Fluent Assertions licensing & HarmonyLib in .NET 9.
