#  Patient API

A simple **.NET 8 Web API** that provides patient information by ID using an in-memory data source.  
This project demonstrates **clean architecture**, **dependency injection**, and **unit testing** for a scalable and maintainable codebase.

---

##  Technologies

- **.NET 8**
- **C#**
- **xUnit**
- **Moq**
- **Swagger / Swashbuckle**

---

## Features

- Retrieve patient details by ID (`GET /api/patients/{id}`)
- Handles missing patient scenarios (`404 Not Found`)
- Detects and handles duplicate patient records (`e.g., Id = 3`)
- Exception handling in controllers for various error types
- Fully in-memory repository (no database required)
- Built-in **Dependency Injection**
- Includes **unit tests** for the service layer
- Interactive **Swagger UI** documentation
  


---

##  Getting Started

### 1️⃣ Clone the repository

git clone https://github.com/subinscariya2/PatientPortal.git

cd PatientPortal

### 2️⃣ Build the project
dotnet build

### 3️⃣ Run the API
dotnet run --project NHSPatientPortal

### Once the project starts running, it will automatically redirect to the Swagger UI, where the API endpoints can be tested.

## API Endpoints

| Method | Endpoint            | Description              |
|:-------|:--------------------|:--------------------------|
| GET    | `/api/patient/{id}` | Retrieves a patient by ID |

---

## Project Structure

- **Controllers** – API endpoints  
- **Models** – Domain models (Patient)  
- **Repositories** – Data access layer (mocked in-memory)  
- **Services** – Business logic layer (optional abstraction)  
- **PatientPortalTest** – Unit tests using xUnit  

---

## Notes

- The API is designed for demonstration purposes and uses an in-memory data store.  
- Adding a real database would only require swapping the repository implementation.  
- **Dependency Injection** is used to ensure testable and maintainable code.
- Unit tests are implemented using **xUnit** and **Moq** for mocking dependencies. 
- Follows **RESTful API best practices** and proper HTTP status code conventions.  
- Can be extended to include **authentication and authorization** (e.g., JWT or OAuth).
- Consistent **naming conventions** and **layered architecture** improve readability and maintainability.
- Can be incorporated into **CI/CD pipelines** for automated builds and testing.


