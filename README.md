Contract Monthly Claim System
The Contract Monthly Claim System is a website built to help lecturers submit, approve, and process their claims automatically. Lecturers can submit their claims, and the system helps program coordinators and HR staff approve or reject those claims. The goal is to make everything more efficient and reduce errors.
Features
•	Lecturer View:
o	Submit claims with automatic payment calculations based on the hours worked and the hourly rate.
•	Program Coordinator/Academic Manager View:
o	Automatically checks and approves or rejects claims from lecturers.
•	HR View:
o	HR can process claims once they're approved and create invoices.
o	HR can also manage lecturer personal information.
Technologies Used
•	Backend:
o	ASP.NET Core MVC for building the web app
o	C# for the logic behind the application
o	Entity Framework for database management
•	Frontend:
o	HTML, CSS, JavaScript, and jQuery for the user interface
o	Bootstrap for making the design look good on all devices
•	Database:
o	In-memory database for quick testing (you can switch to a real database like SQL Server later)
Requirements
Before running this project, make sure you have:
•	.NET 6 or later 
o	Get it from here
•	Visual Studio 2022 or another IDE that supports ASP.NET Core
Getting Started
1. Clone the Repository
git clone https://github.com/yourusername/ContractMonthlyClaimSystem.git
2. Install Dependencies
In your project folder, run this command to install everything the project needs:
dotnet restore
3. Run the Application
To start the app, use:
dotnet run
Then, you can open the app in your browser by going to https://localhost:5001.
4. Database Setup (In-Memory Database)
This app uses an in-memory database, which means it stores data temporarily while you're testing. If you want to use a real database later, you can update the connection string in the appsettings.json file and set it up with SQL Server or another database provider.
5. How the App Works
•	Lecturer: Login and submit claims by entering hours worked and hourly rate. The system automatically calculates the total amount to be paid.
•	Program Coordinator/Academic Manager: Review claims submitted by lecturers. The system automatically checks that the claim follows the rules, like making sure the hours and rate are correct. Then, the claims can be approved or rejected.
•	HR: After claims are approved, HR can process them and create invoices for payment. HR can also manage lecturer data, like contact information.
Folder Structure
ContractMonthlyClaimSystem/
│
├── Controllers/                      # Manages requests and responses
│   ├── ClaimsController.cs           # Manages claim submission and processing
│   └── HRController.cs               # Manages HR tasks like generating invoices
│
├── Models/                           # Holds the application's data
│   ├── Claim.cs                      # Represents a lecturer's claim
│   ├── Lecturer.cs                   # Represents lecturer's personal data
│   └── Invoice.cs                    # Represents an invoice for approved claims
│
├── Views/                            # Contains the user interface
│   ├── Home/                         # Home page with general information
│   └── Claims/                       # View for submitting and checking claims
│
├── wwwroot/                          # Static files like images, CSS, and JavaScript
│   └── css/                          # Stylesheets
│   └── js/                           # Custom JavaScript files
│
├── AppDbContext.cs                   # The database context for the application
├── Program.cs                        # The entry point of the application
├── Startup.cs                        # Configures services and app settings
└── appsettings.json                  # Configures app settings like the database connection
User Roles
1. Lecturer
•	Submit claims for work done, including hours and hourly rate.
•	View the status of their claims.
2. Program Coordinator/Academic Manager
•	Review submitted claims.
•	Verify if claims meet the rules (like hours worked and hourly rate).
•	Approve or reject claims.
3. HR
•	Generate invoices for approved claims.
•	View and update lecturer personal data.
API Endpoints
•	GET /Claims/Create: Shows the form for submitting a new claim.
•	POST /Claims/Create: Submits the claim data.
•	GET /HR/GenerateInvoice: Generates an invoice for an approved claim.
•	POST /HR/UpdateLecturerData: Updates a lecturer's personal data.
Testing
•	The app has been tested for basic features like claim submission, approval, and invoice creation.
•	The in-memory database is used for testing, so data is cleared every time the app is restarted.
