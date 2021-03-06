using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne(); Completed
            //ProblemTwo(); Completed
            //ProblemThree(); Completed
            //ProblemFour(); Completed
            //ProblemFive(); Completed
            //ProblemSix(); Completed
            //ProblemSeven(); Completed
            //ProblemEight(); Completed
            //ProblemNine(); Completed
            //ProblemTen(); Completed
            //ProblemEleven(); Completed
            //ProblemTwelve(); Completed
            //ProblemThirteen(); Completed
            //ProblemFourteen(); Completed
            //ProblemFifteen(); Completed
            //ProblemSixteen(); Completed
            //ProblemSeventeen(); Completed
            //ProblemEighteen(); Completed
            //ProblemNineteen(); Completed
            //ProblemTwenty(); Completed
            BonusOne();
            //BonusTwo();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count
            var users = _context.Users;
            Console.WriteLine(users.ToList().Count);

        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.
            var products = _context.Products;
            var productPriceQuery = products.Where(p => p.Price > 150);
            foreach (var product in productPriceQuery)
            {
                Console.WriteLine($"{product.Name}, ${product.Price}");
            }

        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            var products = _context.Products;
            var productNameQuery = products.Where(p => p.Name.Contains("s"));
            foreach (var product in productNameQuery)
            {
                Console.WriteLine(product.Name);
            }
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.
            var users = _context.Users;
            var userRegistrationQuery = users.Where(r => r.RegistrationDate.Value.Year < 2016);
            foreach (var user in userRegistrationQuery)
            {
                Console.WriteLine($"{user.Email}, {user.RegistrationDate}");
            }
        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            var users = _context.Users;
            var userRegistrationQuery = users.Where(r => r.RegistrationDate.Value.Year > 2016 && r.RegistrationDate.Value.Year < 2018);
            foreach (var user in userRegistrationQuery)
            {
                Console.WriteLine($"{user.Email}, {user.RegistrationDate}");
            }
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.
            var cartContents = _context.User.Include(up => up.Users).Include(up => up.Product).Where(up => up.Users.Email == "afton@gmail.com");
            foreach (ShoppingCart products in cartContents)
            {
                Console.WriteLine($" Product's Name:{products.Product.Name} Price: {products.Product.Price} Quantity:{products.Quantity}");
            }
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            var cartContents = _context.User.Include(up => up.Users).Include(up => up.Product).Where(up => up.Users.Email == "oda@gmail.com").Select(sc => sc.Product.Price).Sum(); ;
            Console.WriteLine(cartContents);

        }

        private void ProblemTen()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.
            var customerEmployees = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Employee").Select(ur => ur.UserId);
            var cartContents = _context.User.Include(up => up.Users).Include(up => up.Product).Where(up => customerEmployees.Contains(up.UserId));
            foreach (ShoppingCart products in cartContents)
            {
                Console.WriteLine($" User's Email: {products.Users.Email}");
                Console.WriteLine($" Product's Name: {products.Product.Name} Price: ${products.Product.Price} Quantity: {products.Quantity}");
            }
        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "Iphone X",
                Description = "It's an Iphone",
                Price = 1000
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            var productId = _context.Products.Where(p => p.Name == "Iphone X").Select(p => p.Id).SingleOrDefault();
            ShoppingCart newUserProduct = new ShoppingCart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            };
            _context.User.Add(newUserProduct);
            _context.SaveChanges();
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.
            var product = _context.Products.Where(u => u.Price == 1000).SingleOrDefault();
            product.Price = 1800;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.User.Where(sc => sc.Users.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.User.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var user = _context.Users.Where(u => u.Email == "oda@gmail.com");
            foreach (User userId in user)
            {
                _context.Users.Remove(userId);
            }
            _context.SaveChanges();
        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".

            Console.WriteLine($"Enter your email");
            string userEmail = Console.ReadLine();
            Console.WriteLine($"Enter your password");
            string userPassword = Console.ReadLine();

            var userExists = _context.Users.Where(us => us.Email == userEmail).Where(pw => pw.Password == userPassword).Any();
            if (userExists)
            {
                Console.WriteLine($"Signed In");

            }
            else
            {
                Console.WriteLine($"Invalid Email or Password");

            }

        }
    }
}

           
                



