### Portfolio API - README

---

### **Overview**
The Portfolio API is a backend service designed to manage portfolio content and handle user interactions. It provides CRUD (Create, Read, Update, Delete) operations for portfolio items such as projects, skills, and achievements, along with a contact form API to process user submissions. 

---

### **Features**
- **Projects**: Manage project entries with full CRUD functionality.
- **Skills**: Manage skills with full CRUD functionality.
- **Achievements**: Manage achievements with full CRUD functionality.
- **Contact Form**: Handle contact form submissions.
- **Authentication**: Secure access to management endpoints.
- **Validation**: Input validation and sanitization to prevent security issues.
- **Frontend Integration**: Designed for seamless integration with dynamic frontend applications.

---

### **Technologies Used**
- **ASP.NET Core 6**
- **Entity Framework Core** for database access
- **Microsoft Identity** for authentication and user management
- **JWT (JSON Web Tokens)** for secure API access
- **SQL Server** as the database

---

### **Getting Started**

#### **1. Prerequisites**
- .NET 6 SDK or later installed
- SQL Server instance running
- Postman or any API testing tool for testing endpoints

#### **2. Clone the Repository**
```bash
git clone https://github.com/your-repo/portfolio-api.git
cd portfolio-api
```

#### **3. Configure the Database**
Update the `appsettings.json` file with your SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=PortfolioDB;Trusted_Connection=True;"
}
```

#### **4. Run Database Migrations**
Run the following commands to create the database and seed initial data:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### **5. Run the Application**
Start the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.

---

### **Authentication**

#### **Endpoints**
1. **Register**: `POST /api/account/register`
   - **Request Body**:
     ```json
     {
       "username": "john_doe",
       "email": "john.doe@example.com",
       "password": "Password123!",
       "fullName": "John Doe"
     }
     ```
   - **Response**:
     ```json
     {
       "token": "your-jwt-token"
     }
     ```

2. **Login**: `POST /api/account/login`
   - **Request Body**:
     ```json
     {
       "usernameOrEmail": "john.doe@example.com",
       "password": "Password123!"
     }
     ```
   - **Response**:
     ```json
     {
       "token": "your-jwt-token"
     }
     ```

---

### **Endpoints**

#### **Projects**
- **Get All Projects**: `GET /api/projects`
- **Get Project by ID**: `GET /api/projects/{id}`
- **Create Project**: `POST /api/projects`
  - **Body**:
    ```json
    {
      "name": "Project Name",
      "description": "Project Description",
      "imageUrl": "http://example.com/image.jpg",
      "gitHubUrl": "https://github.com/example",
      "liveDemoUrl": "https://example.com"
    }
    ```
- **Update Project**: `PUT /api/projects/{id}`
- **Delete Project**: `DELETE /api/projects/{id}`

#### **Skills**
- **Get All Skills**: `GET /api/skills`
- **Get Skill by ID**: `GET /api/skills/{id}`
- **Create Skill**: `POST /api/skills`
  - **Body**:
    ```json
    {
      "name": "Skill Name",
      "proficiencyLevel": "Expert"
    }
    ```
- **Update Skill**: `PUT /api/skills/{id}`
- **Delete Skill**: `DELETE /api/skills/{id}`

#### **Achievements**
- **Get All Achievements**: `GET /api/achievements`
- **Get Achievement by ID**: `GET /api/achievements/{id}`
- **Create Achievement**: `POST /api/achievements`
  - **Body**:
    ```json
    {
      "title": "Achievement Title",
      "description": "Achievement Description",
      "dateAchieved": "2023-12-01"
    }
    ```
- **Update Achievement**: `PUT /api/achievements/{id}`
- **Delete Achievement**: `DELETE /api/achievements/{id}`

#### **Contact Form**
- **Submit Contact Form**: `POST /api/contact`
  - **Body**:
    ```json
    {
      "name": "John Doe",
      "email": "john.doe@example.com",
      "subject": "Portfolio Inquiry",
      "message": "I would like to discuss your projects."
    }
    ```

---

### **Security**

1. **JWT Authentication**
   - Every management endpoint requires a valid JWT token.
   - Include the token in the `Authorization` header:
     ```
     Authorization: Bearer your-jwt-token
     ```

2. **Input Validation**
   - All input is validated using **Data Annotations** to ensure data integrity.
   - Validation errors return `400 Bad Request` with detailed error messages.

---

### **Error Handling**

- **400 Bad Request**: Returned for validation errors or malformed requests.
- **401 Unauthorized**: Returned when a valid token is not provided.
- **404 Not Found**: Returned when a resource (project, skill, or achievement) is not found.
- **500 Internal Server Error**: Returned for unhandled server errors.

---

### **Development**

#### **Run Tests**
Ensure all tests pass before deploying:
```bash
dotnet test
```

#### **Project Structure**
```
PortfolioAPI/
├── Controllers/
│   ├── ProjectsController.cs
│   ├── SkillsController.cs
│   ├── AchievementsController.cs
│   ├── ContactController.cs
├── Models/
│   ├── Project.cs
│   ├── Skill.cs
│   ├── Achievement.cs
│   ├── ContactMessage.cs
├── DTOs/
│   ├── ProjectDto.cs
│   ├── SkillDto.cs
│   ├── AchievementDto.cs
│   ├── ContactMessageDto.cs
├── Services/
│   ├── IRepository.cs
│   ├── Repository.cs
├── AppDbContext.cs
├── Program.cs
```

---

### **Future Enhancements**
- Add support for file uploads (e.g., project images).
- Implement pagination for large datasets.
- Add email notifications for contact form submissions.
- Expand logging for better debugging and monitoring.

---

### **License**
This project is open-source and available under the MIT License.
 
