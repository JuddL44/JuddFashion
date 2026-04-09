## **Judd Fashion - Full-Stack E-Commerce Application**
A modern e-commerce platform built with Angular and ASP.NET Core, featuring user authentication,
shopping cart functionality, and real-time inventory management.

🌐 [Live Demo](https://purple-rock-0b231a60f.1.azurestaticapps.net) | 🎬 [Watch the showcase video](https://youtu.be/4-zndD6ErkE)
> ⚠️ **Heads up:** The API is hosted on Azure's free tier which spins down after inactivity. 
> If products don't load on first visit, wait 30-60 seconds and refresh. It's just waking up!

## **Tech Stack**
### Frontend
Angular 20, TypeScript, SCSS, RxJS

### Backend
ASP.NET Core 8, Entity Framework Core, Azure SQL Database, JWT Authentication

### Cloud
Microsoft Azure (App Service, Static Web Apps, Azure SQL)

## **Features**
- User authentication with JWT tokens
- Shopping cart with database persistence
- Checkout system with inventory validation
- Product browsing with category filtering
- Responsive design with glassmorphism UI
- Real-time cart updates
- Deployed to Azure with CI/CD via GitHub Actions

## **Live Deployment**
The application is fully deployed to Microsoft Azure with a live database:
- **Frontend**: Azure Static Web Apps
- **Backend API**: Azure App Service (.NET 8)
- **Database**: Azure SQL Database (cloud-hosted SQL Server)

All data is persisted in a live Azure SQL Database — registered accounts, cart items, and inventory are all real and stored in the cloud.

🌐 [Live Demo](https://purple-rock-0b231a60f.1.azurestaticapps.net) | ⚙️ [Live API](https://juddfashion-api-bghydwbue2hff8b9.centralus-01.azurewebsites.net/api/products)
> ⚠️ **Heads up:** The API is hosted on Azure's free tier which spins down after inactivity. 
> If products don't load on first visit, wait 30-60 seconds and refresh. It's just waking up!

## **Prerequisites** (for running locally)
- Node.js (v18+)
- .NET 8 SDK
- Angular CLI: `npm install -g @angular/cli`
- SQL Server LocalDB (included with Visual Studio)

## **Local Setup**
### Backend
```bash
cd JuddFashion.API/JuddFashion.API
dotnet restore
dotnet ef database update
dotnet run
```
The API will run on `http://localhost:5191/`. The database will be automatically seeded with sample products.

### Frontend
```bash
cd JuddFashion.CLIENT
npm install
ng serve
```
Navigate to `http://localhost:4200` in your browser.

## **Using the Application**
- **Register/Login:** Click the user icon in the navbar to create an account
- **Browse Products:** View featured items on the home page or browse all products in the Shop
- **Filter by Category:** Use category buttons to filter products (Hoodies, Tops, Accessories, etc.)
- **Add to Cart:** Select size and color on product pages, then add to cart
- **Checkout:** Review cart, adjust quantities, and complete your purchase

Note: This is a portfolio project — checkout simulates a purchase by validating stock and updating inventory without processing real payments.

## **API Endpoints**
### Products:
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/category/{category}` - Filter by category

### Authentication:
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login (returns JWT token)

### Cart (requires authentication)
- `GET /api/cart` - Get user's cart
- `POST /api/cart` - Add item to cart
- `POST /api/cart/checkout` - Process checkout
- `PUT /api/cart/{cartItemId}?quantity={qty}` - Update quantity
- `DELETE /api/cart/{cartItemId}` - Remove item

## **Key Implementation Details**
**Authentication**: Passwords are hashed with BCrypt. JWT tokens are stored in localStorage and sent via Authorization headers.

**Shopping Cart**: Cart data persists in the database, linked to user accounts. Adding duplicate items increments quantity rather than creating duplicates.

**Checkout System**: Validates stock availability before processing. If any item is out of stock, the entire checkout fails and returns affected items. On success, inventory is adjusted and the cart is cleared.

## **Troubleshooting**
### Module Errors in Angular:
- Delete `.angular` folder and `node_modules`, then run `npm install`

### Database connection issues (local)
- Ensure SQL Server LocalDB is running
- Default connection string: `Server=(localdb)\\mssqllocaldb;Database=JuddFashionDb;Trusted_Connection=true`

### Port conflicts
- API: port 5191 (change in `launchSettings.json`)
- Frontend: port 4200 (change in `angular.json`)

## **Final Remarks**
Built to demonstrate modern full-stack development practices including RESTful API design, JWT authentication, state management, responsive UI, and cloud deployment to Microsoft Azure.
