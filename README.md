# Setup Instructions
## 1. Initialize the SQL Database

1. **Create the database**:
   - Open **SQL Server Management Studio** (SSMS) or any SQL client connected to your SQL Server.
   - Execute the following SQL query to create a new database:

     ```sql
     CREATE DATABASE ShoppingProj;
     ```

2. **Initialize the database**:
   - copy the `InitDB.sql` script (which contains all the necessary SQL commands to create the tables and insert sample data).
   - connect to the **ShoppingProj** database.
   - Run the `InitDB.sql` script in the context of the **ShoppingProj** database.


   The script will create the necessary tables (`Categories`, `Products`, `Carts`, `CartItems`) and insert sample data into the database.

---

## 2. Build and Run the Backend

1. **Install .NET SDK** (v8):
   - Ensure that you have the **.NET SDK** installed on your machine. You can check this by running:

     ```bash
     dotnet --version
     ```

   If it's not installed, download it from [here](https://dotnet.microsoft.com/download).

2. **Restore the dependencies**:
   - Open a **command prompt** or **terminal** window.
   - Navigate to the backend folder.

   - Restore the required dependencies by running:

     ```bash
     dotnet restore
     ```

3. **Set backend app setting**:
   - In the appsettings.json, you should replace in "ConnectionStrings", the server value to your sql server name:

   ```bash
       "DefaultConnection": "Server=LAPTOP-AAKF8O7S;Database=ShoppingProj;Trusted_Connection=True;TrustServerCertificate=True;"
   ```
   should replace with:

   ```bash
       "DefaultConnection": "Server={Your Server name};Database=ShoppingProj;Trusted_Connection=True;TrustServerCertificate=True;"
   ```

4. **Build the project**:
   - Once the dependencies are restored, build the project to ensure everything is compiled correctly:

     ```bash
     dotnet build
     ```

5. **Run the backend**:
   - Start the backend server with:

     ```bash
     dotnet run
     ```
---

## 3. Run the Frontend

1. **Install Node.js and npm**:
   - Ensure that you have **Node.js (v18)** and **npm** installed. You can verify the installation by running:

     ```bash
     node --version
     npm --version
     ```

   If you don't have them installed, download and install **Node.js** from [here](https://nodejs.org/).

2. **Install frontend dependencies**:
   - Navigate to the frontend folder
   - Install the required dependencies with npm:

     ```bash
     npm install
     ```

3. **Run the frontend**:
   - Start the frontend application with the following command:

     ```bash
     npm run start
     ```

   - This will run the frontend server, and it should be accessible at `http://localhost:3000` (by default).

