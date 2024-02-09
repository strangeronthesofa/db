using DbTest1.Services;

namespace DbTest1;

internal class CLI
{

    private readonly ProductService _productService;
    private readonly CustomerService _customerService;
    //private readonly CategoryService _categoryService;

    public CLI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void CreateProduct_UI()
    {
        Console.WriteLine("Create Product");
        Console.Write("Product title: ");
        var title = Console.ReadLine()!;
        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine()!);
        Console.Write("Product category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }
    }

    public void GetProducts_UI()
    {
        var products = _productService.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title}\n {product.Category.CategoryName}\n {product.Price}");
            Console.WriteLine("------------------------------------------------------------------------");
        }
        Console.ReadKey();
    }

    public void UpdateProduct_UI()
    {
        Console.Write("Enter a product ID: ");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductByProductId(id);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} \n {product.Category.CategoryName} \n {product.Price}");
            Console.WriteLine();
            Console.Write("New Product title: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{product.Title} \n {product.Category.CategoryName} \n {product.Price}");
        }
        else
        {
            Console.WriteLine("No product found.");
        }
        Console.ReadKey();
    }

    public void DeleteProduct_UI()
    {
        Console.Write("Enter a product ID: ");
        var id = int.Parse(Console.ReadLine()!);
        
        var product = _productService.GetProductByProductId(id);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Product was deleted");
        }
        else
        {
            Console.WriteLine("No product found.");
        }
        Console.ReadKey();
    }

    public void CreateCustomer_UI()
    {
        Console.WriteLine("Create Customer");
        Console.Write("First name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Role: ");
        var roleName = Console.ReadLine()!;

        Console.Write("Street name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was created.");
            Console.ReadKey();
        }
    }

    public void GetCustomers_UI()
    {
        var customers = _customerService.GetCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}\n{customer.Email}\n{customer.Role.RoleName}");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode }, {customer.Address.City}");
            Console.WriteLine("------------------------------------------------------------------------");
        }
        Console.ReadKey();
    }

    public void UpdateCustomer_UI()
    {
        Console.Write("Enter an email: ");
        var email = Console.ReadLine()!;
        
        var customer = _customerService.GetCustomerByEmail(email);
        if (email != null)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}\n{customer.Email}\n{customer.Role.RoleName}");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Enter new email: ");
            customer.Email = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine("Customer updated to:");
            Console.WriteLine($"{customer.FirstName} {customer.LastName}\n{customer.Email}");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }
        Console.ReadKey();
    }

    public void DeleteCustomer_UI()
    {
        Console.Write("Enter an email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        if (email != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine("Customer was deleted");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }
        Console.ReadKey();
    }
}