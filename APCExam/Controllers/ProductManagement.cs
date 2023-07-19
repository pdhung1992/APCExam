using APCExam.Contexts;
using Microsoft.EntityFrameworkCore;

namespace APCExam;

public class ProductManagement
{
    private ProductDBContext productDbContext;
    public ProductManagement()
    {
        var productOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseSqlServer("Data Source=localhost;Initial Catalog=APC;Persist Security Info=True;User ID=sa;Password=Pdhung92@;Encrypt=False")
            .Options;
        this.productDbContext = new ProductDBContext(productOptions);
    }
    public void AddProduct()
    {
        Console.Write("Enter Product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        var newProduct = new Product
        {
            Name = name,
            Price = price
        };

        try
        {
            productDbContext.Products.Add(newProduct);
            productDbContext.SaveChanges();
            Console.WriteLine("Product added!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DisplayAllProduct()
    {
        var products = productDbContext.Products.ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}$");
        }
    }

    public void DeleteProductById()
    {
        Console.Write("Enter product ID to remove: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var deleteProduct = productDbContext.Products.FirstOrDefault(p => p.Id == findId);
        if (deleteProduct != null)
        {
            Console.WriteLine("Product found: {0}", deleteProduct.Name);

            productDbContext.Products.Remove(deleteProduct);
            productDbContext.SaveChanges();
            Console.WriteLine("Product Deleted!");
        }
        else
        {
            Console.WriteLine("Can not find the product has ID = {0}", findId);
        }
    }
}