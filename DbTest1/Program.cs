using DbTest1.Contexts;
using DbTest1.Repositories;
using DbTest1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DbTest1;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\ECWin23\C-Sharp\DbTest1\DbTest1\Data\db_test.mdf;Integrated Security=True;Connect Timeout=30"));

                services.AddScoped<AddressRepository>();
                services.AddScoped<CategoryRepository>();
                services.AddScoped<CustomerRepository>();
                services.AddScoped<ProductRepository>();
                services.AddScoped<RoleRepository>();

                services.AddScoped<AddressService>();
                services.AddScoped<CategoryService>();
                services.AddScoped<CustomerService>();
                services.AddScoped<ProductService>();
                services.AddScoped<RoleService>();

                services.AddSingleton<CLI>();
        }).Build();

        var CLI = builder.Services.GetRequiredService<CLI>();
        CLI.CreateProduct_UI();
        //CLI.GetProducts_UI();
        //CLI.UpdateProduct_UI();
        //CLI.DeleteProduct_UI();
        //CLI.CreateCustomer_UI();
        //CLI.GetCustomers_UI();
        //CLI.UpdateCustomer_UI();
        //CLI.DeleteCustomer_UI();
    }
}
