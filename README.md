# EmployeeApp
## Installation and Setup

#### 1. Clone the repository:
```
git clone https://github.com/nazbez/EmployeeApp.git
```

#### 2. Backend Setup:
1. Install the latest version of [.NET Core SDK](https://dotnet.microsoft.com/download)
2. Open the solution file `EmployeeApp.Backend.sln` in your IDE
3. Restore the NuGet packages by right-clicking on the solution file and selecting "Restore NuGet Packages" or using a command specific to your IDE.
4. Update the database connection string in the `appsettings.json` or `secrets.json` files with your database configuration.
5. Build the backend project to ensure all dependencies are resolved and the project compiles successfully.

#### 3. Frontend Setup:
1. Open a command prompt and navigate to the `EmployeeApp.Frontend\src\employee-app-client\` folder.
2. Install the latest version of [Node.js](https://nodejs.org/uk).
3. Install the dependencies:
   ```
   npm install
   ```
4. Start the Angular development server:
   ```
   npm run start
   ```

## SQL Tasks

Solutions to sql tasks can be found in [folder](https://github.com/nazbez/EmployeeApp/tree/main/EmployeeApp.Backend/src/EmployeeApp.Backend.Infrastructure/Persistence/SqlQueries).

## Demo

A demonstration of the application can be viewed at [link](https://drive.google.com/file/d/1jm2fE_6cIFZ6rdg3ZHBA77cN0gj_zp0s/view?usp=drive_link).
